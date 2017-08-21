using Selectcomp.APP;
using Selectcomp.CORE;
using Selectcomp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace Selectcomp.WEB.Admin
{
    public partial class AdminProductDetails : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUserID.Text = User.Identity.GetUserId();
            if (User.Identity.GetUserName() != "Administrador")
            {
                Response.Redirect("~/AccessDenied.aspx");
            }

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

        /// <summary>
        /// Método que se acciona pulsando el botón btnDeleteProduct, mediante el cual se elimina el producto actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDeleteProduct_Click1(object sender, EventArgs e)
        {
            try
            {
                //Instanciamos el manager y le pasamos el contexto
                ApplicationDbContext context = new ApplicationDbContext();
                ProductManager productManager = new ProductManager(context);
                //Producto que vamos a eliminar
                Product deleteThisProduct = new Product();
                //Recogemos el ID del producto que vamos a eliminar
                int ID = Int32.Parse(Request.QueryString["ProductID"]);
                //Rellenamos "deleteThisProduct" con los datos del producto que queremos eliminar
                deleteThisProduct = productManager.GetById(ID);
                //Se lo pasamos al productManager
                productManager.Delete(deleteThisProduct);
                context.SaveChanges();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se ha eliminado el producto correctamente.')", true);
                Server.Transfer("AdminProductList.aspx", true);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error al eliminar el producto.')", true);
            }
        }

        
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            pnlCarts.Visible = true;
        }

        /// <summary>
        /// Método que añade el producto actual en el carrito que sea seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try{
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
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                

                
            }


        }



        
    }
}