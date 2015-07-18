using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace STDServices
{
    public partial class ConsultarExpediente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (lblTitulo.Text.Equals(""))
            {
                lblTitulo.Text = "Listado de expedientes de: " + txtDNI.Text;
                CargarData();
            }
            else
            {
                lblTitulo.Text = "";
                BorrarData();
            }
        }

        public void CargarData()
        {
            List<Expediente> listaExpediente = new List<Expediente>();
            Expediente eExpediente = new Expediente();
            eExpediente.IdExpediente = 1;
            eExpediente.CodExpediente = "EXP01";
            eExpediente.CodSUT = "SUT01";
            eExpediente.DesRequisito = "Descripcion del SUT 1";
            eExpediente.DesExpediente = "Descripcion del Expediente 1";
            eExpediente.Estado = "Activo";
            listaExpediente.Add(eExpediente);


            Expediente eExpediente1 = new Expediente();
            eExpediente1.IdExpediente = 1;
            eExpediente1.CodExpediente = "EXP02";
            eExpediente1.CodSUT = "SUT02";
            eExpediente1.DesRequisito = "Descripcion del SUT 2";
            eExpediente1.DesExpediente = "Descripcion del Expediente 2";
            eExpediente1.Estado = "Activo";
            listaExpediente.Add(eExpediente1);


            Expediente eExpediente2 = new Expediente();
            eExpediente2.IdExpediente = 1;
            eExpediente2.CodExpediente = "EXP03";
            eExpediente2.CodSUT = "SUT03";
            eExpediente2.DesRequisito = "Descripcion del SUT 3";
            eExpediente2.DesExpediente = "Descripcion del Expediente 3";
            eExpediente2.Estado = "Activo";
            listaExpediente.Add(eExpediente2);

            GridView1.DataSource = listaExpediente;
            GridView1.DataBind();
        }

        public void BorrarData()
        {
            List<Expediente> listaExpediente = new List<Expediente>();

            GridView1.DataSource = listaExpediente;
            GridView1.DataBind();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoExpediente.aspx");
        }

        protected void btnGenerarCargo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ConsultarCargo.aspx");
        }

    }
}