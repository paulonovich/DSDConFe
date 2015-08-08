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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarControles();
                if (Session["codigoTramite"] != null && Session["codigoSolicitante"] != null)
                {
                    SolicitanteNeg solicitanteNegocio = new SolicitanteNeg();
                    List<Solicitante> ListaSolicitante = new List<Solicitante>();
                    Solicitante solicitanteDato = new Solicitante();
                    String mensaje = "";
                    codigoTramite = Convert.ToInt32(Session["codigoTramite"]);
                    codigoSolicitante = Convert.ToInt32(Session["codigoSolicitante"]);
                    solicitanteDato = solicitanteNegocio.ObtenerSolicitante(codigoSolicitante, ref mensaje);
                    ListaSolicitante.Add(solicitanteDato);

                    if (mensaje.Equals(""))
                    {
                        Bloquear(false);
                        gvSolicitante.DataSource = ListaSolicitante;
                        gvSolicitante.DataBind();
                        ddlTramite.SelectedValue = codigoTramite.ToString();
                    }
                    else
                    {
                        Bloquear(true);
                        lblError.Text = mensaje;
                    }

                }
                else
                {
                    Bloquear(true);
                }
            }
        }

        private void CargarControles()
        {
            TramiteNeg tramiteNegocio = new TramiteNeg();
            String mensaje = "";
            List<Tramite> ListaTramite = new List<Tramite>() { new Tramite() { codigo = 0, nombre = "--Seleccione un trámite--" } };
            List<Tramite> ListaAux = tramiteNegocio.ListarTramites(ref mensaje);
            if (mensaje.Equals(""))
            {
                ListaTramite.AddRange(ListaAux);
                this.ddlTramite.DataSource = ListaTramite;
                this.ddlTramite.DataTextField = "nombre";
                this.ddlTramite.DataValueField = "codigo";
                this.ddlTramite.DataBind();
                this.ddlTramite.SelectedValue = "0";
            }
            else
            {
                lblErrorCarga.Text = mensaje;
            }
        }

        private void Bloquear(bool valor)
        {
            lblError.Text = "";
            lblErrorCarga.Text = "";
            gvSolicitante.Visible = !valor;
            btnGenerarCargo.Visible = !valor;
        }

        protected void btnConsultarTUPA_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
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

        protected void btnGenerarCargo_Click(object sender, EventArgs e)
        {
            Session["codigoTramite"] = codigoTramite;
            Session["codigoSolicitante"] = codigoSolicitante;

            ExpedienteNeg expedienteNegocio = new ExpedienteNeg();
            String mensaje = "";
            Expediente eExpediente = new Expediente();
            eExpediente.codigoSolicitante = codigoSolicitante;
            eExpediente.codigoTramite = codigoTramite;
            eExpediente.Estado = 1;
            eExpediente = expedienteNegocio.AgregarExpediente(eExpediente, ref mensaje);

            if (eExpediente.codigo > 0)
            {
                Session["codigoExpediente"] = eExpediente.codigo;
                Response.Redirect("RegistrarCargo.aspx");
            }
            else
            {
                lblError.Text = mensaje;
            }
        }
    }
}