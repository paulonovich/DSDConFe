using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace STDServices
{
    public class SolicitanteService : ISolicitante
    {
        public bool AgregarSolicitante(ref STDDatos.Solicitante pSolicitante)
        {
            String mensaje = "";
            try
            {
                bool validacion = verificaSolicitante(pSolicitante, ref mensaje);
                if (validacion)
                {
                    return new STDDatos.SolicitanteBl().Agregar(ref pSolicitante);
                }
                else
                {
                    throw new FaultException(mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        private bool verificaSolicitante(STDDatos.Solicitante pSolicitante, ref String mensaje)
        {
            if (pSolicitante.nombre.Equals(""))
            {
                mensaje = "Tiene que ingresar el nombre del solicitante.";
                return false;
            }

            if (pSolicitante.apellido.Equals(""))
            {
                mensaje = "Tiene que ingresar el apellido del solicitante.";
                return false;
            }

            if (pSolicitante.dni.Equals(""))
            {
                mensaje = "Tiene que ingresar el DNI del solicitante.";
                return false;
            }

            if (!verificaValor(pSolicitante.telefono))
            {
                mensaje = "Tiene que ingresar un número de Teléfono válido.";
                return false;
            }

            if (!pSolicitante.correo.Equals("") && (!pSolicitante.correo.Contains(@"@") || !pSolicitante.correo.Contains(@".com")))
            {
                mensaje = "Tiene que ingresar el correo válido.";
                return false;
            }

            mensaje = "";
            return true;
        }

        private bool verificaValor(String cadena)
        {
            long resultado = 0;
            bool verifica = long.TryParse(cadena, out resultado);
            return verifica;
        }
        
        public STDDatos.Solicitante ObtenerSolicitante(int codigo)
        {
            try
            {
                return new STDDatos.SolicitanteBl().Obtener(codigo);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
















        public List<STDDatos.Solicitante> ListarSolicitante()
        {
            try
            {
                return new STDDatos.SolicitanteBl().Listar();
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        
    }
}