using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using STDServices.SWTramite;
using STDServices.SWSolicitante;
using STDServices.SWExpediente;

namespace SistemaTramiteDocumentario
{
    public partial class RegistrarExpediente : System.Web.UI.Page
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

        private List<STDServices.SWSolicitante.Solicitante> ListaSolicitante
        {
            get
            {
                if (ViewState["ListaSolicitante"] != null)
                    return (List<STDServices.SWSolicitante.Solicitante>)ViewState["ListaSolicitante"];
                else
                    return null;
            }
            set
            {
                ViewState["ListaSolicitante"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["codigoTramite"] != null && Session["codigoSolicitante"] != null)
                {
                    codigoTramite = Convert.ToInt32(Session["codigoTramite"]);
                    codigoSolicitante = Convert.ToInt32(Session["codigoSolicitante"]);

                    SolicitanteClient solicitante = new SolicitanteClient();
                    ListaSolicitante = solicitante.ObtenerSolicitante(codigoSolicitante);

                    gvSolicitante.Visible = true;
                    btnGenerarCargo.Visible = true;
                    btnConsultarTUPA.Enabled = false;
                    gvSolicitante.DataSource = ListaSolicitante;
                    gvSolicitante.DataBind();

                    ddlTramite.SelectedValue = codigoTramite.ToString();
                    ddlTramite.Enabled = false;
                }
                else
                {
                    gvSolicitante.Visible = false;
                    btnGenerarCargo.Visible = false;
                    btnConsultarTUPA.Enabled = true;
                    ddlTramite.Enabled = true;
                }
                CargarControles();
            }
        }

        protected void btnConsultarTUPA_Click(object sender, EventArgs e)
        {
            codigoTramite = int.Parse(ddlTramite.SelectedValue.ToString());
            if (codigoTramite == 0)
            {
                lblError.Text = "Seleccione un valor válido.";
            }
            else
            {
                Session["codigoTramite"] = codigoTramite.ToString();
                Response.Redirect("ConsultarTUPA.aspx");
            }
        }

        private void CargarControles()
        {
            TramiteClient tramite = new TramiteClient();
            List<STDServices.SWTramite.Tramite> ListaTramite = new List<STDServices.SWTramite.Tramite>() { new STDServices.SWTramite.Tramite() { codigo = 0, nombre = "--Seleccione un trámite--" } };
            ListaTramite.AddRange(tramite.ListarTramites());
            this.ddlTramite.DataSource = ListaTramite;
            this.ddlTramite.DataTextField = "nombre";
            this.ddlTramite.DataValueField = "codigo";
            this.ddlTramite.DataBind();
            this.ddlTramite.SelectedValue = "0";
        }

        protected void btnGenerarCargo_Click(object sender, EventArgs e)
        {
            Session["codigoTramite"] = codigoTramite;
            Session["codigoSolicitante"] = codigoSolicitante;

            ExpedienteClient expediente = new ExpedienteClient();
            STDServices.SWExpediente.Expediente eExpediente = new STDServices.SWExpediente.Expediente();
            eExpediente.codigo = 1;
            eExpediente.codigoSolicitante = codigoSolicitante;
            eExpediente.codigoTramite = codigoTramite;
            eExpediente.Estado = 1;
            bool resultado = expediente.Agregar(ref eExpediente);

            if (resultado)
            {
                Session["codigoExpediente"] = eExpediente.codigo;
                Response.Redirect("RegistrarCargo.aspx");
            }
            else
            {
                lblError.Text = "Hubo un error al registrar el expediente.";
            }
        }
    }
}