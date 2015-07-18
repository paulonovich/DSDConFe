using STDServices.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STDServices
{
    public partial class GenerarCargo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnGenerarCargo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultarCargo.aspx");
        }

        protected void btnConsultarTUPA_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultarTUPA.aspx");
        }
    }
}