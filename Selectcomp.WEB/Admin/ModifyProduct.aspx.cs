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
using Microsoft.AspNet.Identity;

namespace Selectcomp.WEB.Admin
{
    public partial class ModifyProduct : System.Web.UI.Page
    {
        /*Instanciamos el contexto de datos a null*/
        ApplicationDbContext context = new ApplicationDbContext();
        /*Instanciamos el manejador del tipo Product a null*/
        ProductManager productManager = null;
        /*Instanciamos el producto con el que vamos a trabajar*/
        Product product = new Product();

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.GetUserName() != "Administrador")
            {
                Response.Redirect("~/AccessDenied.aspx");
            }
            context = new ApplicationDbContext();
            productManager = new ProductManager(context);

            // Añadimos los datos en el ddl
            if (!Page.IsPostBack)
            {
                if (User.Identity.GetUserName() != "Administrador")
            {
                Response.Redirect("~/AccessDenied.aspx");
            }
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

                try
                {
                    /* Recogemos el Id de la url y buscamos en la base de datos el producto cuyo id es igual al que nos trae dicha Url*/
                    int ID = Int32.Parse(Request.QueryString["ProductID"]);
                    Product product = new Product();
                    product = productManager.GetById(ID);


                    /* Rellenamos los formularios con los datos del producto */

                    tbName.Text = product.Name;
                    tbBrand.Text = product.Brand;
                    tbPrice.Text = product.Price.ToString();
                    //ddlType !¡!¡!¡!¡!¡!¡!
                    tbImage.Text = product.Image;
                    tbDescription.Text = product.Description;
                    tbAmount.Text = product.Amount.ToString();
                    //cbStock !¡!¡!¡!¡!¡!¡!¡!


                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Carga de datos correcta')", true);
                }
                catch
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Carga de datos fallida')", true);

                }
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            
            try
            {
                Product oldProduct = new Product();
                int ID = Int32.Parse(Request.QueryString["ProductID"]);
                oldProduct = productManager.GetById(ID);

                /*Añadimos los datos de los controles de la página al objeto productModify*/
                Product newProduct = new Product()
                {
                    Id = ID,
                    Name = tbName.Text,
                    Brand = tbBrand.Text,
                    Price = Decimal.Parse(tbPrice.Text),
                    Image = tbImage.Text,
                    Description = tbDescription.Text,
                    Stock = cbStock.Checked,
                    Amount = Int32.Parse(tbAmount.Text),
                    ProductType = (ProductType)Enum.Parse(typeof(ProductType), ddlType.SelectedValue),
                };

                /* Añadimos el producto con los datos anteriores, y despues el producto con los datos nuevos*/
                productManager.Update(oldProduct, newProduct);
                /*Modificamos los datos en la base de datos*/
                context.SaveChanges();
                btnModify.Enabled = false;
                btnModify.Text = "Se ha modificado el producto correctamente.";
                btnModify.ForeColor = Color.Green;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                lblSave.Text = "Se ha producido un problema al modificar los datos del producto.";
                lblSave.ForeColor = Color.Red;


            }
        }

        protected void cbStock_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbStock.Checked)
            {
                tbAmount.Enabled = false;
                tbAmount.Text = "0";
            }
            else
            {
                tbAmount.Enabled = true;
            }
        }





    





    }
}