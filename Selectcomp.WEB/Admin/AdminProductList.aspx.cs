using Selectcomp.APP;
using Selectcomp.CORE;
using Selectcomp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Selectcomp.WEB.Admin
{
    public partial class AdminProductList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(User.Identity.GetUserName() != "Administrador")
            {
                Response.Redirect("~/AccessDenied.aspx");
            }


        }


        public IQueryable<Product> lvProducts_GetData()
        {
            /*Instanciamos el contexto*/
            ApplicationDbContext context = new ApplicationDbContext();
            /*Instanciamos el manejador de los productos y le pasamos el contexto con el que va a trabajar*/
            ProductManager productManager = new ProductManager(context);

            IQueryable<Product> queryProducts = productManager.GetAll();

            return queryProducts;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ProductAdd.aspx");
        }
    }
}