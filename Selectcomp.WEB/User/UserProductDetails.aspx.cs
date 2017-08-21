using Microsoft.AspNet.Identity;
using Selectcomp.APP;
using Selectcomp.CORE;
using Selectcomp.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Selectcomp.WEB.User
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUserID.Text = User.Identity.GetUserId();
            

        }

        /// <summary>
        /// Este método trae los productos de la base de datos y selecciona aquel cuyo Id coincide con el que trae la URL
        /// </summary>
        /// <param name="productId">Identificador que trae la url Ejemplo: http://localhost:1716/User/ProductDetails?productID=3, este caso trae el 3 </param>
        /// <returns></returns>
        public IQueryable<Product> GetProduct([QueryString("productID")] int? productId)
        {
            //Instanciamos el manager y le pasamos el contexto
            ApplicationDbContext context = new ApplicationDbContext();
            ProductManager productManager = new ProductManager(context);

            //Le pasamos todos los productos a la variable query
            IQueryable<Product> query = productManager.GetAll();
            //Si la Url trae un Id y es mayor que 0, buscaremos dentro de query el producto que coincida con el Id que trae la URL. En caso contrario query sera null.
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.Id == productId);
            }
            else
            {
                query = null;
            }

            //Devolvemos query
            return query;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {


            try
            {
                if (!User.Identity.IsAuthenticated)
                { 
                    Response.Redirect("~/AccessDenied.aspx");
                }
                int productID = Int32.Parse(Request.QueryString["ProductID"]);
                ApplicationDbContext context = new ApplicationDbContext();
                OrderManager orderManager = new OrderManager(context);
                OrderLineManager orderLineManager = new OrderLineManager(context);
                //Traemos el producto que queremos para obtener su nombre
                ProductManager productManager = new ProductManager(context);
                Product product = new Product();
                product = productManager.GetById(productID);

                //Añadimos los datos a la linea de carrito.
                OrderLine AddToCart = new OrderLine()
                {
                    OrderId = Int32.Parse(DropDownList1.SelectedValue),
                    ProductId = productID,
                    units = Int32.Parse(tbNumberUnits.Text),
                    OrderLineName = product.Name,
                    OrderLineProductPrice = product.Price

                };

                orderLineManager.Add(AddToCart);
                context.SaveChanges();
                lblSave.ForeColor = Color.Green;
                lblSave.Text = "El producto se ha guardado correctamente";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                lblSave.ForeColor = Color.Red;
                lblSave.Text = "Se ha producido un error al guardar el producto. Por favor, contacte con el administrador.";
            }



        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            pnlCarts.Visible = true;
        }
    }
}