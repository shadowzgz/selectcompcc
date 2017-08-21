using Selectcomp.CORE;
using Selectcomp.DAL;
using Selectcomp.APP;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
namespace Selectcomp.WEB.User
{
    public partial class Cart : System.Web.UI.Page
    {

        public void Page_Load(Object sender, EventArgs e)
        {

            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/AccessDenied.aspx");
            }

            try
            {
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex);
               lblWarnings.Text = "No se ha encontrado ningún carrito. Intente crear uno nuevo.";
                    lblWarnings.BorderColor = Color.Red;
            }
        }

        /// <summary>
        /// Cargamos los carritos hechos por el usuario.
        /// </summary>
        /// <returns></returns>
        /********** Acabar el catch **************/
        public List<Order> GetData()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            OrderManager orderManager = new OrderManager(context);

            try
            {
                var carts = orderManager.GetByUserId(User.Identity.GetUserId()).ToList()
                    .Select(i => new Order()
                    {
                        OrderId = i.OrderId,
                        CreateDate = DateTime.Now,
                        OrderName = i.OrderName

                    });
                return carts.ToList();
            }
            catch (Exception ex)
            {
                // Aqui mnostramos mensaje de que él usuario no tiene ningún carrito creado.
                lblWarnings.Text = ex.ToString();

                return null;
            }
            

        }

        protected void btnCreateCart_Click(object sender, EventArgs e)
        {
            try
            {


                /*Instanciamos el contexto de datos*/
                ApplicationDbContext context = new ApplicationDbContext();
                /*Instanciamos el manejador del tipo Product*/
                OrderManager orderManager = new OrderManager(context);

                /*Añadimos los datos de los controles de la página al objeto productAdd*/
                Order orderCreate = new Order()
                {
                    OrderName = tbNombreCarrito.Text,
                    User_Id = User.Identity.GetUserId(),
                    CreateDate = DateTime.Now,
                };

                /* Añadimos el objeto con los datos que hemos recopilado de los controles del webform*/
                orderManager.Add(orderCreate);
                /*Guardamos los datos del con texto en la base de datos*/
                context.SaveChanges();
                btnCreateCart.Enabled = false;

                Response.Redirect(Request.RawUrl);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                lblCreateCart.Text = "Error al crear un nuevo carrito";
                lblCreateCart.ForeColor = Color.Red;
            }



        }

        protected void btnOpenPanel_Click(object sender, EventArgs e)
        {
            pnlCreateCart.Visible = true;
        }
    }
}