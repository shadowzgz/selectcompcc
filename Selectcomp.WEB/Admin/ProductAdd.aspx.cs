using Selectcomp.APP;
using Selectcomp.CORE;
using Selectcomp.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace Selectcomp.WEB.Admin
{
    public partial class ProductAdd : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.GetUserName() != "Administrador")
            {
                Response.Redirect("~/AccessDenied.aspx");
            }
            // Añadimos los datos en el ddl
            if (!Page.IsPostBack)
            {
                ddlType.DataSource = null;
                Dictionary<string, string> valuesEnum = new Dictionary<string, string>();
                var values = Enum.GetValues(typeof(ProductType));
                foreach (var value in values)
                {
                    valuesEnum.Add(((int)value).ToString(), value.ToString());
                }
                ddlType.DataTextField = "Value";
                ddlType.DataValueField = "Key";
                ddlType.DataSource = valuesEnum;
                ddlType.DataBind();

            }
        }
        

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                /*Instanciamos el contexto de datos*/
                ApplicationDbContext context = new ApplicationDbContext();
                /*Instanciamos el manejador del tipo Product*/
                ProductManager productManager = new ProductManager(context);

                /*Añadimos los datos de los controles de la página al objeto productAdd*/
                Product productAdd = new Product()
                {
                    Name = tbName.Text,
                    Brand = tbBrand.Text,
                    Price = Decimal.Parse(tbPrice.Text),
                    Image = tbImage.Text,
                    Description = tbDescription.Text,
                    Stock = cbStock.Checked,
                    Amount = Int32.Parse(tbAmount.Text),
                    ProductType = (ProductType)Enum.Parse(typeof(ProductType), ddlType.SelectedValue),
                };

                /* Añadimos el objeto con los datos que hemos recopilado de los controles del webform*/
                productManager.Add(productAdd);
                /*Guardamos los datos del con texto en la base de datos*/
                context.SaveChanges();
                btnSave.Enabled = false;
                lblSave.Text = "Se ha guardado el producto correctamente";
                lblSave.ForeColor = Color.Green;
            }
            catch(Exception ex)
            {

                lblSave.Text = "Se ha producido un problema al guardar los datos: " + ex;
                lblSave.ForeColor = Color.Red;
                Console.WriteLine(ex);

            }
        }
    }
}