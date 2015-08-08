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
    public partial class ConsultarTUPA : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarControles();
            }
        }

        private void CargarControles()
        {
            try
            {
                TupaNeg tupaNegocio = new TupaNeg();
                String mensaje = "";
                if (Session["codigoTramite"] != null)
                {
                    codigoTramite = Convert.ToInt32(Session["codigoTramite"]);
                    List<Tupa> ListaTupa = new List<Tupa>();
                    ListaTupa.AddRange(tupaNegocio.ObtenerTupa(codigoTramite, ref mensaje));
                    if (mensaje.Equals(""))
                    {
                        this.gvTUPA.Visible = true;
                        this.gvTUPA.DataSource = ListaTupa;
                        this.gvTUPA.DataBind();
                    }
                    else
                    {
                        this.gvTUPA.Visible = false;
                        lblError.Text = mensaje;
                    }
                }
                else
                {
                    lblError.Text = "No hay un código de trámite activo.";
                    gvTUPA.Visible = false;
                    btnContinuar.Visible = false;
                    btnRegresar.Visible = true;
                }
            }
            catch (Exception ex)
            {
                gvTUPA.Visible = false;
                btnContinuar.Visible = false;
                btnRegresar.Visible = true;
                lblError.Text = ex.ToString();
            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            bool verificaCheckBox = false;
            foreach (GridViewRow tupaRow in this.gvTUPA.Rows)
            {
                CheckBox cb = (CheckBox)tupaRow.FindControl("chkDocumento");

                if (cb != null && cb.Checked)
                {
                    verificaCheckBox = true;
                }
                else
                {
                    verificaCheckBox = false;
                    break;
                }
            }

            if (verificaCheckBox)
            {
                //ViewState.Add("codigoTramite", codigoTramite);
                Session["codigoTramite"] = codigoTramite.ToString();
                Response.Redirect("RegistrarSolicitante.aspx");
            }
            else
            {
                btnContinuar.Visible = false;
                btnRegresar.Visible = true;
                lblError.Text = "No cumple con los requisitos para el tramite a solicitar.";
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("RegistrarExpediente.aspx");
        }
    }
}