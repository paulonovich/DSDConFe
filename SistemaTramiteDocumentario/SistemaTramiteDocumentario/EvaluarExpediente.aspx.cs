using SistemaTramiteDocumentario.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaTramiteDocumentario
{
    public partial class EvaluarExpediente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = "Listado de expedientes";
            CargarData();
        }

        public void CargarData()
        {
            List<Listado> listado = new List<Listado>();
            Listado eListado = new Listado();
            eListado.Solicitante = "Solicitante 1";
            eListado.Expediente = "EXP01";
            listado.Add(eListado);

            Listado eListado1 = new Listado();
            eListado1.Solicitante = "Solicitante 2";
            eListado1.Expediente = "EXP02";
            listado.Add(eListado1);

            Listado eListado2 = new Listado();
            eListado2.Solicitante = "Solicitante 3";
            eListado2.Expediente = "EXP03";
            listado.Add(eListado2);

            Listado eListado4 = new Listado();
            eListado4.Solicitante = "Solicitante 4";
            eListado4.Expediente = "EXP04";
            listado.Add(eListado4);

            GridView1.DataSource = listado;
            GridView1.DataBind();
        }

        protected void btnConsultarExpediente_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultarExpediente.aspx");
        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            if(btnAprobar.Visible==false){
                btnAprobar.Visible=true;
                btnRechazar.Visible=true;
            }else{
                btnAprobar.Visible = false;
                btnRechazar.Visible = false;
            }
        }
    }
}