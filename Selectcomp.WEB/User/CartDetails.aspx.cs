using Microsoft.AspNet.Identity;
using Selectcomp.APP;
using Selectcomp.CORE;
using Selectcomp.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Selectcomp.WEB.User
{
    public partial class CartDetails : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ///*Título*/
            //if (!Page.IsPostBack)
            addTitle();
            calculateTotalPrice();

            try
            {
                GridView1.UseAccessibleHeader = true;
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }

        /// <summary>
        /// Cargamos los carritos hechos por el usuario.
        /// </summary>
        /// <returns></returns>
        ///
        /*public List<OrderLine> GetData()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            OrderLineManager orderLineManager = new OrderLineManager(context);

            try
            {
                var cartLines = orderLineManager.GetByCartId(Int32.Parse(Request.QueryString["orderId"])).ToList()
                    .Select(i => new OrderLine()
                    {
                        OrderLineName = i.OrderLineName,
                        units = i.units,
                        OrderLineProductPrice = i.OrderLineProductPrice
                    });
                return cartLines.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar las líneas de carrito" + ex);
                lblNull.Text = "No se ha detectado ningún producto en este carrito.";
                return null;
            }
        }
        */
        /// <summary>
        /// Este método recoge el nombre del carrito del cual estamos viendo sus artículos
        /// </summary>
        public void addTitle()
        {
            try
            {
                ApplicationDbContext context = new ApplicationDbContext();
                OrderManager orderManager = new OrderManager(context);
                Order order = new Order();
                order = orderManager.GetByOrderId(Int32.Parse(Request.QueryString["orderId"]));

                lblTitle.Text = "Nombre del carrito: " + order.OrderName;
            }
            catch (Exception ex)
            {
                lblTitle.Text = "Error al mostrar el título.";
                Console.WriteLine("Error al mostrar el título: " + ex);
            }
        }

        /// <summary>
        /// Este método calcula el precio total de un carrito. Para ello multiplicamos el
        /// precio por el número de unidades de cada línea de carritos y lo vamos sumando
        /// en la variable totalPrice.
        /// </summary>
        public void calculateTotalPrice()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            OrderLineManager orderLineManager = new OrderLineManager(context);
            decimal totalPrice = 0;

            try
            {
                var cartLines = orderLineManager.GetByCartId(Int32.Parse(Request.QueryString["orderId"])).ToList()
                     .Select(i => new OrderLine()
                     {
                         OrderLineName = i.OrderLineName,
                         units = i.units,
                         OrderLineProductPrice = i.OrderLineProductPrice
                     });

                foreach (OrderLine item in cartLines)
                {
                    totalPrice = totalPrice + (item.OrderLineProductPrice * item.units);
                    Console.WriteLine(totalPrice);
                }

                lblTotalPrice.Text = "El precio total es: " + totalPrice;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al calcular el precio total: " + ex);
                Console.WriteLine("El precio total es: 0€");
            }
        }

        /// <summary>
        /// Mostramos el panel cuando le damos al botón de comprar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnPurchase_Click(object sender, ImageClickEventArgs e)
        {
            pnlPurchase.Visible = true;
        }


        /// <summary>
        /// Este método se ejecuta cuando vamos a realizar la compra de nuestro carrito.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCompletePurchase_Click(object sender, EventArgs e)
        {

            try
            {
                /**********HAY QUE RESTAR LAS UNIDADES PERTINENTES AL COMPRAR**********/
                ApplicationDbContext context = new ApplicationDbContext();
                PurchaseManager purchaseManager = new PurchaseManager(context);

                Purchase purchase = new Purchase()
                {
                    User_Id = User.Identity.GetUserId(),
                    OrderId = Int32.Parse(Request.QueryString["orderId"]),
                    PurchaseUserName = tbPurchaseName.Text,
                    PurchaseUserSurname = tbPurchaseSurname.Text,
                    PurchasePrice = lblTotalPrice.Text,
                    PurchaseDate = DateTime.Now,
                    PurchaseCardNumber = Int64.Parse(tbPurchaseCreditCard.Text),
                    PurchaseAddress = tbPurchaseAddress.Text,
                    PurchaseCity = tbPurchaseCity.Text,
                    PurchaseCountry = tbPurchaseCountry.Text,
                    PurchasePostalCode = Int32.Parse(tbPurchasePostalCode.Text),
                    PurchaseTlfNumber1 = Int64.Parse(tbPurchaseTlf1.Text),
                    PurchaseTlfNumber2 = Int64.Parse(tbPurchaseTlf2.Text),
                    PurchaseEmail = tbPurchaseEmail.Text

                };
                substractUnitsFromProducts();
                sendEmail();
                purchaseManager.Add(purchase);
                context.SaveChanges();
                lblInfoPurchase.ForeColor = System.Drawing.Color.Green;
                lblInfoPurchase.Text = "El proceso de compra se ha realizado satisfactoriamente. Recibirá un correo electrónico en los próiximos minutos.";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                lblInfoPurchase.ForeColor = System.Drawing.Color.Red;
                lblInfoPurchase.Text = "Se ha producido al realizar el proceso de compra. Por favor, contacte con el administrador.";
            }



        }

        /// <summary>
        /// Este método resta las unidades que hemos comprado al stock de los productos.
        /// </summary>
        public void substractUnitsFromProducts()
        {
            #region Pruebas
            //foreach (GridViewRow row in GridView1.Rows)
            //{

            //    GridViewRow prueba = GridView1.Rows[row.RowIndex];

            //    if (row.DataItem != null)
            //    {
            //        try
            //        {
            //            /*Cojemos las unidades y el id de producto de la linea de carrito del gridview*/
            //            int unitsToSubstract = 0;
            //            int productIdtoModify = 0;
            //            OrderLine oLine = new OrderLine();
            //            oLine = (OrderLine)row.DataItem;
            //            oLine.units = unitsToSubstract;
            //            oLine.ProductId = productIdtoModify;

            //            /*Traemos el producto que queremos modificar mediante su id*/
            //            ApplicationDbContext context = new ApplicationDbContext();
            //            ProductManager productManager = new ProductManager(context);
            //            Product oldProduct = new Product();
            //            oldProduct = productManager.GetById(productIdtoModify);

            //            /*Creamos un nuevo producto y le damos todos los datos del anterior producto. Después le restamos las unidades que se han comprado*/
            //            Product newProduct = new Product();
            //            newProduct = oldProduct;
            //            newProduct.Amount -= unitsToSubstract;

            //            /*Por último hacemos el update*/
            //            productManager.Update(oldProduct, newProduct);
            //            context.SaveChanges();
            //        }
            //        catch (Exception ex)
            //        {
            //            Debug.WriteLine("Error al tratar de restar las unidades compradas: " + ex);
            //        }
            //    }
            //}

            #endregion
            /*Traemos los datos del carrito para poder cojer los id de productos y sus respectivas unidades que vamos a restar*/
            ApplicationDbContext context = new ApplicationDbContext();
            OrderLineManager orderLine = new OrderLineManager(context);
            IQueryable<OrderLine> orderLines = orderLine.GetByCartId(Int32.Parse(Request.QueryString["OrderId"]));

            /*Por cada linea de carrito traeremos su respectivo producto para updatearlo*/
            foreach (OrderLine oL in orderLines)
            {
                /*Traemos el producto que vamos a actualizar*/
                ApplicationDbContext context2 = new ApplicationDbContext();
                ProductManager productManager = new ProductManager(context2);
                Product oldProduct = productManager.GetById(oL.ProductId);
                /*Creamos un nuevo producto con los mismos datos y le restamos las unidades del carrito*/
                Product newProduct = oldProduct;
                newProduct.Amount = newProduct.Amount - oL.units;
                /*Updateamos y guardamos cambios*/
                productManager.Update(oldProduct, newProduct);
                context2.SaveChanges();

            }

        }


        /// <summary>
        /// Con este método eliminamos el carrito actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnRemoveCart_Click(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            OrderManager orderManager = new OrderManager(context);
            Order removeThisOrder = new Order();
            removeThisOrder = orderManager.GetByOrderId(Int32.Parse(Request.QueryString["OrderId"]));


            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                orderManager.Delete(removeThisOrder);
                context.SaveChanges();
                Response.Redirect("UserProductList.aspx");
            }

            else
            {
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Recargando la página...')", true);
            }
        }

        public void sendEmail()
        {

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(tbPurchaseEmail.Text);
            mail.From = new MailAddress("selectcompweb@gmail.com", "Selectcomp", System.Text.Encoding.UTF8);
            mail.Subject = "Su compra se ha realizado con éxito.";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Su compra se ha completado satisfactoriamente. Su paquete llegará en unos días.";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("selectcompweb@gmail.com", "jorge11garcia");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
                //Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                // Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
            }




        }
    }
}