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
    public partial class EvaluarExpediente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Al momento de cargar necesita la lista de evaluaciones (vista)
                EvaluacionNeg evaluacionNegocio = new EvaluacionNeg();
                List<Evaluacion> ListaEvaluacion = new List<Evaluacion>();
                String mensaje = "";

                mensaje = evaluacionNegocio.Actualizar();
                if (mensaje.Equals(""))
                {
                    //Se enlaza a la capa de negocio y obtiene la lista de evaluaciones, devuelve tambien un mensaje
                    ListaEvaluacion = evaluacionNegocio.ListarEvaluacion(ref mensaje);

                    //Si no existe mensaje significa que si devolvio informacion
                    if (mensaje.Equals(""))
                    {
                        //mostramos el gridview y ocultamos los botones de aprobacion
                        gvExpediente.Visible = true;
                        trOpcion.Visible = false;
                        trPregunta.Visible = false;
                        gvExpediente.DataSource = ListaEvaluacion;
                        gvExpediente.DataBind();
                    }
                    else
                    {
                        //Ocultamos la grilla y los botones de aprobacion
                        gvExpediente.Visible = false;
                        trOpcion.Visible = false;
                        trPregunta.Visible = false;
                        lblError.Text = mensaje;
                    }
                }
                else
                {
                    //Ocultamos la grilla y los botones de aprobacion
                    gvExpediente.Visible = false;
                    trOpcion.Visible = false;
                    trPregunta.Visible = false;
                    lblError.Text = mensaje;
                }
            }
        }

        protected void btnEvaluar_Click(object sender, EventArgs e)
        {
            //Verificamos si existe un expediente seleccionado
            if (hdCodigo.Value.Equals(""))
            {
                lblError.Text = "Seleccione un expediente a revisar.";
                trOpcion.Visible = false;
                trPregunta.Visible = false;
                Session["codigoExpediente"] = "";
            }
            else
            {
                Session["codigoExpediente"] = hdCodigo.Value;
                trOpcion.Visible = true;
                trPregunta.Visible = true;
            }
        }

        protected void gvExpediente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvExpediente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Al presionar el select de la grilla obtenemos la fila elegida
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvExpediente.DataKeys[index].Value);
                //guardamos el id expediente en un control oculto
                hdCodigo.Value = id.ToString();
            }
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            //Evaluar 3 ... Aprobado
            Evaluar(3);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Evaluar 2 ... Cancelado (denegado)
            Evaluar(2);
        }

        public void Evaluar(int estado)
        {
            //conectamos la capa de negocio (STDNegocio)
            Expediente eExpediente = new Expediente();
            ExpedienteNeg expedienteNegocio = new ExpedienteNeg();
            EvaluacionNeg evaluacionNegocio = new EvaluacionNeg();
            String mensaje = "";
            int codigoExp = Convert.ToInt32(hdCodigo.Value);
            //Obtenemos la informacion del expediente en base al codigo seleccionado
            eExpediente = expedienteNegocio.ObtenerExpediente(codigoExp, ref mensaje);
            //modificamos el estado del expediente
            eExpediente.Estado = estado;
            //recuperamos el mensaje 
            mensaje = evaluacionNegocio.ActualizarCola(eExpediente);
            lblError.Text = mensaje;
            trOpcion.Visible = false;
            trPregunta.Visible = false;
        }
    }
}