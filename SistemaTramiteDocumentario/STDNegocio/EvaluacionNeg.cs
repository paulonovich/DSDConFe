using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STDDatos;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Messaging;

namespace STDNegocio
{
    public class EvaluacionNeg
    {
        public List<Evaluacion> ListarEvaluacion(ref String mensaje)
        {
            List<Evaluacion> ListaEvaluacion = new List<Evaluacion>();
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:7966/Evaluacion.svc/Evaluacion");
                req.Method = "GET";
                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string listaEvaluacion = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                ListaEvaluacion = js.Deserialize<List<Evaluacion>>(listaEvaluacion);
                mensaje = "";
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                mensaje = js.Deserialize<string>(error);
            }
            return ListaEvaluacion;
        }

        public String ActualizarCola(Expediente expedienteModificado) {
            try
            {
                string rutaCola = @".\private$\evaluacionXhora";
                if (!MessageQueue.Exists(rutaCola))
                    MessageQueue.Create(rutaCola);
                MessageQueue cola = new MessageQueue(rutaCola);
                Message mensaje = new Message();
                mensaje.Label = "Expediente actualizado";
                mensaje.Body = new Expediente()
                {
                    codigo = expedienteModificado.codigo,
                    codigoSolicitante = expedienteModificado.codigoSolicitante,
                    codigoTramite = expedienteModificado.codigoTramite,
                    Estado = expedienteModificado.Estado
                };
                cola.Send(mensaje);
                return "Se registro la actualización del expediente.";
            }
            catch (Exception)
            {
                return "Hubo un error al registrar la actualizacion del expediente.";
            }
        }

        //Actualizacion de los expedientes
        public String Actualizar()
        {
            String mensajeFinal = "";
            /* 1. Regulizar expedientes*/
            string rutaCola = @".\private$\evaluacionXhora";
            if (!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);
            MessageQueue cola = new MessageQueue(rutaCola);
            cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(Expediente) });

            while (cola.GetAllMessages().Count() != 0)
            {
                Message mensaje = cola.Receive();
                Expediente expedienteItem = (Expediente)mensaje.Body;

                string postdata = "{" +
                    "\"codigo\":" + expedienteItem.codigo + "," +
                    "\"codigoSolicitante\":" + expedienteItem.codigoSolicitante + "," +
                    "\"codigoTramite\":" + expedienteItem.codigoTramite + "," +
                    "\"Estado\":" + expedienteItem.Estado + "}";
                            
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:7966/Evaluacion.svc/Evaluacion");
                req.Method = "PUT";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                HttpWebResponse res = null;
                try
                {
                    res = (HttpWebResponse)req.GetResponse();
                    StreamReader reader = new StreamReader(res.GetResponseStream());
                    string pedidoJson = reader.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Expediente pedidoCreado = js.Deserialize<Expediente>(pedidoJson);
                    mensajeFinal = "";
                }
                catch (WebException e)
                {
                    HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                    string message = ((HttpWebResponse)e.Response).StatusDescription;
                    StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                    string error = reader.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    string msjError = js.Deserialize<string>(error);
                    mensajeFinal = msjError;
                    break;
                }
            }
            return mensajeFinal;
        }
    }
}
