using Selectcomp.APP;
using Selectcomp.CORE;
using Selectcomp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace Selectcomp.WEB.User
{
    public partial class IncidenceDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadIncidenceData();
            LoadIncidenceMessages();
            if (User.Identity.GetUserName() == "Administrador")
                LoadAdminData();

        }

        public void LoadAdminData()
        {
            try
            {
                pnlAdminDetails.Visible = true;
                ApplicationDbContext context = new ApplicationDbContext();
                IncidenceManager incidenceManager = new IncidenceManager(context);
                Incidence incidence = new Incidence();
                incidence = incidenceManager.GetById(Int32.Parse(Request.QueryString["IncidenceId"]));
                tbInternalNote.Text = incidence.InternalNote;

                /*** Rellenamos el ddl de estado ***/
                ddlStatus.DataSource = null;
                Dictionary<string, string> valuesEnum = new Dictionary<string, string>();
                var values = Enum.GetValues(typeof(IncidenceStatus));
                foreach (var value in values)
                {
                    valuesEnum.Add(((int)value).ToString(), value.ToString());
                }
                ddlStatus.DataTextField = "Value";
                ddlStatus.DataValueField = "Key";
                ddlStatus.DataSource = valuesEnum;
                ddlStatus.DataBind();

                /*** Rellenamos el ddl de prioridad ***/
                ddlIncidencePriority.DataSource = null;
                Dictionary<string, string> valuesEnum2 = new Dictionary<string, string>();
                var values2 = Enum.GetValues(typeof(Priority));
                foreach (var value in values2)
                {
                    valuesEnum2.Add(((int)value).ToString(), value.ToString());
                }
                ddlIncidencePriority.DataTextField = "Value";
                ddlIncidencePriority.DataValueField = "Key";
                ddlIncidencePriority.DataSource = valuesEnum2;
                ddlIncidencePriority.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }



        }

        public void LoadIncidenceData()
        {
            try
            {
                ApplicationDbContext context = new ApplicationDbContext();
                IncidenceManager incidenceManager = new IncidenceManager(context);
                Incidence incidence = new Incidence();
                incidence = incidenceManager.GetById(Int32.Parse(Request.QueryString["IncidenceId"]));
                lblSubject.Text = incidence.IncidenceTitle;
                lblCreateDate.Text = incidence.CreateDate.ToString();
                lblCloseDate.Text = incidence.CloseDate.ToString();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);

            }
        }

        public void LoadIncidenceMessages()
        {
            try
            {
                ApplicationDbContext context = new ApplicationDbContext();
                MessageManager messageManager = new MessageManager(context);
                IQueryable<Message> messages = messageManager.GetByIncidenceId(Int32.Parse(Request.QueryString["IncidenceId"]));

                foreach (Message msg in messages)
                {
                    ///**** Panel ****/
                    //var panel = new Panel();
                    //panel.ID = "pnlMessage" + msg.MessageId;
                    //Controls.Add(panel);
                    /**** Label ****/
                    var label = new Label();
                    label.ID = "lblMessage" + msg.MessageId;
                    label.Text = "Usuario: " + msg.MessageUserName + "  ";
                    label.Visible = true;
                    pnlMessages.Controls.Add(label);
                    /**** TextBox ****/
                    var textBox = new TextBox();
                    textBox.ID = "tbMessage" + msg.MessageId;
                    textBox.ReadOnly = true;
                    textBox.Height = 164;
                    textBox.Width = 400;
                    textBox.TextMode = TextBoxMode.MultiLine;
                    textBox.Text = msg.MessageText;
                    textBox.Visible = true;
                    pnlMessages.Controls.Add(textBox);


                    /**** Literal (para los espacios) ****/
                    Literal c = new Literal();
                    c.Text = "<hr />";
                    pnlMessages.Controls.Add(c);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }


        }

        protected void btnSaveNewMessage_Click(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            MessageManager messageManager = new MessageManager(context);
            Message msg = new Message()
            {
                MessageCreateDate = DateTime.Now,
                Incidence_Id = Int32.Parse(Request.QueryString["IncidenceId"]),
                MessageUserName = User.Identity.Name,
                MessageText = tbNewMessage.Text,
                User_Id = User.Identity.GetUserId()

            };

            messageManager.Add(msg);
            context.SaveChanges();
            Response.Redirect(Request.RawUrl);
        }

        protected void btnSaveAdminDetails_Click(object sender, EventArgs e)
        {

            try
            {
                ApplicationDbContext context = new ApplicationDbContext();
                IncidenceManager incidenceManager = new IncidenceManager(context);
                Incidence oldIncidence = incidenceManager.GetById(Int32.Parse(Request.QueryString["IncidenceId"]));               
                Incidence newIncidence = oldIncidence;

                newIncidence.Status = (IncidenceStatus)Enum.Parse(typeof(IncidenceStatus), ddlStatus.SelectedValue);
                newIncidence.Priority = (Priority)Enum.Parse(typeof(Priority), ddlIncidencePriority.SelectedValue);
                newIncidence.InternalNote = tbInternalNote.Text;

                incidenceManager.Update(oldIncidence, newIncidence);
                context.SaveChanges();
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

    }
}