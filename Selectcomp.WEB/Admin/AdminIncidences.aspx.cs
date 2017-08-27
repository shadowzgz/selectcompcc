using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace Selectcomp.WEB.Admin
{
    public partial class AdminIncidences : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.GetUserName() != "Administrador")
            {
                Response.Redirect("~/AccessDenied.aspx");
            }
            GridView1.UseAccessibleHeader = true;
            if (GridView1.HeaderRow != null)
            {
                GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}