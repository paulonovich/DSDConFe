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

namespace STDNegocio
{
    public class EvaluacionNeg
    {
        //Listado de las evaluaciones
        public List<Evaluacion> ListarEvaluacion(ref string mensaje)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:7966/Evaluacion.svc/Evaluacion");
            req.Method = "GET";
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string listaEvaluacion = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Evaluacion> ListaEvaluacion = js.Deserialize<List<Evaluacion>>(listaEvaluacion);

            if (ListaEvaluacion != null && ListaEvaluacion.Count > 0)
            {
                mensaje = "";
            }
            else
            {
                mensaje = "No se encontraron registros";
            }
            return ListaEvaluacion;
        }

        //Actualizacion de los expedientes
        public String Actualizar(Expediente expedienteModificado)
        {
            String mensaje = "";
            try
            {
                byte[] bData = ObjectToByteArray(expedienteModificado);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:7966/Evaluacion.svc/Evaluacion");
                request.Method = "PUT";
                request.ContentLength = bData.Length;
                request.ContentType = "application/json";
                var requestStream = request.GetRequestStream();
                requestStream.Write(bData, 0, bData.Length);
                var response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string evaluacionJson = reader.ReadToEnd();
                JavaScriptSerializer jsSerializacion = new JavaScriptSerializer();
                Evaluacion alumnoModificado = jsSerializacion.Deserialize<Evaluacion>(evaluacionJson);
                return mensaje;
            }
            catch (Exception)
            {
                return "Ocurrio un error al actualizar la evaluacion.";
            }
        }

        private byte[] ObjectToByteArray(Expediente obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        //public List<Evaluacion> ObtenerEvaluacion(int codigo,ref string mensaje)
        //{
        //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:7966/Evaluacion.svc/Evaluacion");
        //    req.Method = "GET";
        //    var res = (HttpWebResponse)req.GetResponse();
        //    StreamReader reader = new StreamReader(res.GetResponseStream());
        //    string listaEvaluacion = reader.ReadToEnd();
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    List<Evaluacion> ListaEvaluacion = js.Deserialize<List<Evaluacion>>(listaEvaluacion);

        //    if (ListaEvaluacion != null && ListaEvaluacion.Count > 0)
        //    {
        //        mensaje = "";
        //    }
        //    else
        //    {
        //        mensaje = "No se encontraron registros";
        //    }
        //    return ListaEvaluacion;
        //}




        //public List<Evaluacion> ListarEvaluacion(ref string mensaje)
        //{
        //    HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:7966/Evaluacion.svc/Evaluacion");
        //    req.Method = "GET";
        //    var res = (HttpWebResponse)req.GetResponse();
        //    StreamReader reader = new StreamReader(res.GetResponseStream());
        //    string listaEvaluacion = reader.ReadToEnd();
        //    JavaScriptSerializer js = new JavaScriptSerializer();
        //    List<Evaluacion> ListaEvaluacion = js.Deserialize<List<Evaluacion>>(listaEvaluacion);

        //    if (ListaEvaluacion != null && ListaEvaluacion.Count > 0)
        //    {
        //        mensaje = "";
        //    }
        //    else
        //    {
        //        mensaje = "No se encontraron registros";
        //    }
        //    return ListaEvaluacion;
        //}
    }
}
