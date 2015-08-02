using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaTramiteDocumentario
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbConExp_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistrarExpediente.aspx");
        }
        
        protected void lbEvaExp_Click(object sender, EventArgs e)
        {
            Response.Redirect("EvaluarExpediente.aspx");
        }

        protected void lbRegUsu_Click(object sender, EventArgs e)
        {
            //Response.Redirect("RegistrarUsuario.aspx");
        }
    }
}