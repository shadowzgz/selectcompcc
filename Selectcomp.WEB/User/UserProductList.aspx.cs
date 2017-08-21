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

namespace Selectcomp.WEB.User
{
    public partial class PruebasLista : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            



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






        
    }
}