using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using STDServices;
using System.Net;

namespace STDRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Usuario : IUsuario
    {
        public STDDatos.Usuario ObtenerUsuario(string dni)
        {
            string mensaje = "";
            try
            {
                if (dni.Equals(""))
                {
                    mensaje = "Tiene que ingresar el DNI del solicitante.";
                    throw new FaultException(mensaje);
                }
                else
                {
                    STDDatos.Usuario eUsuario = new STDDatos.UsuarioBL().Obtener(dni);
                    if (eUsuario == null)
                    {
                        mensaje = "No existe usuario.";
                        throw new FaultException(mensaje);
                    }
                    else
                        return eUsuario;
                }
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(mensaje, HttpStatusCode.InternalServerError);
            }
        }

        public bool AgregarUsuario(STDDatos.Usuario pUsuario)
        {
            string mensaje = "";
            try
            {
                //bool validacion = verificaUsuario(pUsuario, ref mensaje);
                //if (validacion)
                //{
                    return new STDDatos.UsuarioBL().Agregar(ref pUsuario);
                //}
                //else
                //{
                //    throw new WebFaultException<string>(mensaje, HttpStatusCode.InternalServerError);
                //}
            }
            catch (Exception)
            {
                mensaje = "Usuario no fue creado.";
                throw new WebFaultException<string>(mensaje, HttpStatusCode.InternalServerError);
            }
        }

        private bool verificaUsuario(STDDatos.Usuario pUsuario, ref String mensaje)
        {
            if (pUsuario.DNI.Equals(""))
            {
                mensaje = "Tiene que ingresar el DNI del solicitante.";
                return false;
            }
            if (pUsuario.Nombre.Equals(""))
            {
                mensaje = "Tiene que ingresar el nombre del solicitante.";
                return false;
            }

            mensaje = "";
            return true;
        }
    }
}
