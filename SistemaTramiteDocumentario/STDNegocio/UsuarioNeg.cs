using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STDNegocio.WSSolicitante;
using STDDatos;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Messaging;

namespace STDNegocio
{
    public class UsuarioNeg
    {
        //Actualizacion de los expedientes
        public string AgregarUsuario(Usuario usuarioCrear)
        {
            string mensaje = "";
            try
            {
                string postdata = "{" +
                "\"Dni\":\"" + usuarioCrear.DNI + "\"," +
                "\"Nombre\":\"" + usuarioCrear.Nombre + "\"," +
                "\"Tipo\":\"" + usuarioCrear.Tipo + "\"}";

                //string postdata = "{\"Codigo\":\"3\",\"Marca\":\"1\",\"Tipo\":\"1\",\"Color\":\"1\",\"Placa\":\"QA-1231\",\"Modelo\":\"2012\",\"Descripcion\":\"Mazda 4\",\"Estado\":\"1\"}"; //JSON
                
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:7966/Usuario.svc/Usuario");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                var res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string usuarioJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                bool usuarioCreado = js.Deserialize<bool>(usuarioJson);
                mensaje = "";
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string msjError = js.Deserialize<string>(error);
                mensaje = msjError;
                try
                {
                    string rutaCola = @".\private$\usuarioNoGuardado";
                    if (!MessageQueue.Exists(rutaCola))
                        MessageQueue.Create(rutaCola);
                    MessageQueue cola = new MessageQueue(rutaCola);
                    Message mensajeCola = new Message();
                    mensajeCola.Label = "Usuario por registrar.";
                    mensajeCola.Body = new Usuario()
                    {
                        DNI = usuarioCrear.DNI,
                        Nombre = usuarioCrear.Nombre,
                        Tipo = usuarioCrear.Tipo
                    };
                    cola.Send(mensajeCola);
                    mensaje = mensaje + " El usuario queda en estado 'Por registrar'.";
                }
                catch (Exception)
                {
                    mensaje = mensaje + "";
                }
            }
            return mensaje;
        }

        public String RegistrarColaUsuario()
        {
            String mensajeFinal = "";
            /* 1. Regulizar expedientes*/
            string rutaCola = @".\private$\usuarioNoGuardado";
            if (!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);
            MessageQueue cola = new MessageQueue(rutaCola);
            cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(Usuario) });

            while (cola.GetAllMessages().Count() != 0)
            {
                Message mensaje = cola.Receive();
                Usuario expedienteItem = (Usuario)mensaje.Body;

                AgregarUsuario(expedienteItem);
            }
            return mensajeFinal;
        }

        public Usuario ObtenerUsuario(String dni, ref String mensaje)
        {
            Usuario eUsuario = new Usuario();
            try
            {
                
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:7966/Usuario.svc/Usuario/" + dni);
                req.Method = "GET";
                req.ContentType = "application/json";
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string usuarioJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                eUsuario = js.Deserialize<Usuario>(usuarioJson);
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
            return eUsuario;
        }
    }
}
