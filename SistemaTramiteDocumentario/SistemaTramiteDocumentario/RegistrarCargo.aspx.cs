using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using STDServices.SWCargo;

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
        
        private Cargo cargo
        {
            get
            {
                if (ViewState["Cargo"] != null)
                    return (Cargo)ViewState["Cargo"];
                else
                    return null;
            }
            set
            {
                ViewState["Cargo"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargoClient cargo = new CargoClient();
                codigoTramite = Convert.ToInt32(Session["codigoTramite"]);
                codigoSolicitante = Convert.ToInt32(Session["codigoSolicitante"]);
                codigoExpediente = Convert.ToInt32(Session["codigoExpediente"]);
                codigoCargo = cargo.ObtenerCodigo();

                txtId.Text = codigoCargo.ToString();
                txtCodigoExp.Text = codigoExpediente.ToString();
                txtFechaEmision.Text = DateTime.Today.ToShortDateString();
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                cargo = new Cargo();
                cargo.codigo = codigoCargo;
                cargo.codigoExpediente = codigoExpediente;
                cargo.FechaEmision=DateTime.Today;
                cargo.Recepcionista=txtRecepcionista.Text;
                cargo.Solicitante=txtSolicitante.Text;
                cargo.Estado = ddlEstado.Text;
                
                CargoClient cargoClient = new CargoClient();
                bool resultado = false;
                resultado = cargoClient.AgregarCargo(cargo);
                if (resultado)
                {
                    lblMensaje.Text = "Cargo registrado.";
                }
                else
                {
                    lblMensaje.Text = "Ocurrio un error al registrar el cargo.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = ex.ToString();
            } 
        }
    }
}