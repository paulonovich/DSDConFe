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
    public partial class RegistrarSolicitante : System.Web.UI.Page
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                codigoTramite = Convert.ToInt32(Session["codigoTramite"]);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Solicitante solicitante = new Solicitante();
                solicitante.nombre = txtNombre.Text.Trim();
                solicitante.apellido = txtApellido.Text.Trim();
                solicitante.dni = txtDNI.Text.Trim();
                solicitante.telefono = txtTelefono.Text.Trim();
                solicitante.correo = txtCorreo.Text.Trim();
                solicitante.direccion = txtDireccion.Text.Trim();

                SolicitanteNeg solicitanteNegocio = new SolicitanteNeg();
                String mensaje = "";
                solicitante = solicitanteNegocio.AgregarSolicitante(solicitante, ref mensaje);

                if (solicitante.codigo > 0)
                {
                    btnContinuar.Visible = true;
                    btnGuardar.Visible = false;
                    Session["codigoSolicitante"] = solicitante.codigo;
                }
                else
                {
                    btnContinuar.Visible = false;
                    btnGuardar.Visible = true;
                }
                lblError.Text = mensaje;
            }
            catch (Exception ex)
            {
                btnContinuar.Visible = false;
                btnGuardar.Visible = true;
                lblError.Text = ex.ToString();
            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            Session["codigoTramite"] = codigoTramite;
            Response.Redirect("RegistrarExpediente.aspx");
        }
    }
}