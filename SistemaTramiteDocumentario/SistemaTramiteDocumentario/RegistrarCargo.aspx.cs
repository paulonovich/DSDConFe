using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using STDDatos;
using STDNegocio;

namespace SistemaTramiteDocumentario
{
    public partial class RegistrarCargo : System.Web.UI.Page
    {
        private int codigoTramite
        {
            get
            {
                if (ViewState["codigoTramite"] != null)
                    return (int)ViewState["codigoTramite"];
                else
                    return 0;
            }
            set
            {
                ViewState["codigoTramite"] = value;
            }
        }

        private int codigoSolicitante
        {
            get
            {
                if (ViewState["codigoSolicitante"] != null)
                    return (int)ViewState["codigoSolicitante"];
                else
                    return 0;
            }
            set
            {
                ViewState["codigoSolicitante"] = value;
            }
        }

        private int codigoCargo
        {
            get
            {
                if (ViewState["codigoCargo"] != null)
                    return (int)ViewState["codigoCargo"];
                else
                    return 0;
            }
            set
            {
                ViewState["codigoCargo"] = value;
            }
        }

        private int codigoExpediente
        {
            get
            {
                if (ViewState["codigoExpediente"] != null)
                    return (int)ViewState["codigoExpediente"];
                else
                    return 0;
            }
            set
            {
                ViewState["codigoExpediente"] = value;
            }
        }
                
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargoNeg cargoNegocio = new CargoNeg();
                String mensaje = "";
                codigoTramite = Convert.ToInt32(Session["codigoTramite"]);
                codigoSolicitante = Convert.ToInt32(Session["codigoSolicitante"]);
                codigoExpediente = Convert.ToInt32(Session["codigoExpediente"]);
                codigoCargo = cargoNegocio.ObtenerNuevoCodigo(ref mensaje);

                if (mensaje == "")
                {
                    Bloquear(false);
                    txtId.Text = codigoCargo.ToString();
                    txtCodigoExp.Text = codigoExpediente.ToString();
                    txtFechaEmision.Text = DateTime.Today.ToShortDateString();
                }
                else
                {
                    lblMensaje.Text = mensaje;
                    Bloquear(true);
                }
            }
        }

        private void Bloquear(bool bEstado)
        {
            txtCodigoExp.Enabled = !bEstado;
            txtFechaEmision.Enabled = !bEstado;
            txtRecepcionista.Enabled = !bEstado;
            txtSolicitante.Enabled = !bEstado;
            ddlEstado.Enabled = !bEstado;
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                CargoNeg cargoNegocio = new CargoNeg();
                String mensaje = "";
                Cargo cargo = new Cargo();
                cargo.codigo = codigoCargo;
                cargo.codigoExpediente = codigoExpediente;
                cargo.FechaEmision = DateTime.Today;
                cargo.Recepcionista = txtRecepcionista.Text;
                cargo.Solicitante = txtSolicitante.Text;
                cargo.Estado = ddlEstado.Text;
                cargoNegocio.AgregarCargo(cargo, ref mensaje);
                lblMensaje.Text = mensaje;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.ToString();
            }
        }
    }
}