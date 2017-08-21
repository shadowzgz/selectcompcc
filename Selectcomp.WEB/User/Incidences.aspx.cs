using Microsoft.AspNet.Identity;
using Selectcomp.APP;
using Selectcomp.CORE;
using Selectcomp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Selectcomp.WEB.User
{
    public partial class Incidences : System.Web.UI.Page
    {

        /// <summary>
        /// Cargamos los datos del enum "IncidenceType" en el dropdownlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/AccessDenied.aspx");
            }
            lblUserId.Text = User.Identity.GetUserId();
            GridView1.UseAccessibleHeader = true;
            if(GridView1.HeaderRow != null)
            {
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (!Page.IsPostBack)
            {
                ddlIncidenceType.DataSource = null;
                Dictionary<string, string> valuesEnum = new Dictionary<string, string>();
                var values = Enum.GetValues(typeof(IncidenceType));
                foreach (var value in values)
                {
                    valuesEnum.Add(((int)value).ToString(), value.ToString());
                }
                ddlIncidenceType.DataTextField = "Value";
                ddlIncidenceType.DataValueField = "Key";
                ddlIncidenceType.DataSource = valuesEnum;
                ddlIncidenceType.DataBind();

            }
        }

        /// <summary>
        /// Método que se activa cuando pulsamos el botón "btnCreateIncidence", que hace visible el panel que continene los controles para crear una nueva incidencia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreateIncidence_Click(object sender, EventArgs e)
        {
            pnlCreateIncidence.Visible = true;
        }

        /// <summary>
        /// Método que se dispara al clicar el botón "Save new incidence", que crea una nueva incidencia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveNewIncidence_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationDbContext context = new ApplicationDbContext();
                IncidenceManager incidenceManager = new IncidenceManager(context);

                Incidence incidence = new Incidence()
                {
                    IncidenceTitle = tbIncidenceName.Text,
                    CloseDate = null,
                    CreateDate = DateTime.Now,
                    Messages = new List<Message>(),
                    Status = IncidenceStatus.Abierto,
                    User_Id = User.Identity.GetUserId(),
                    IncidenceType = (IncidenceType)Enum.Parse(typeof(IncidenceType), ddlIncidenceType.SelectedValue),
                };
                incidence.Messages.Add(new Message()
                {
                    MessageCreateDate = DateTime.Now,
                    Incidence = incidence,
                    MessageUserName = User.Identity.Name,
                    MessageText = tbIncidenceText.Text,
                    User_Id = User.Identity.GetUserId()

                });

                incidenceManager.Add(incidence);
                context.SaveChanges();

                lblResult.Text = "El registro se ha guardado correctamente";
                Response.Redirect(Request.RawUrl);
            }

            catch (Exception ex)
            {
                //TO DO: Guardar en el log el error, y anajo s emostraria que simplmenete se ha ocurrido un error, sin poner el mensaje de error entero.
                lblResult.Text = "Se ha producido el siguiente error: " + ex.Message;

            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public List<Incidence> GridView1_GetData()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            IncidenceManager incidenceManager = new IncidenceManager(context);
           


            var incidences = incidenceManager.GetByUserId(User.Identity.GetUserId()).ToList()
                                .Select(i => new Incidence()
                                {
                                    IncidenceId = i.IncidenceId,
                                    IncidenceTitle = i.IncidenceTitle,
                                    IncidenceType = i.IncidenceType,
                                    Status = i.Status,
                                });
            return incidences.ToList() ;
        }
    }
}