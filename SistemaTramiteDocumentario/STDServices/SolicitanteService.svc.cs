using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using STDDatos;

namespace STDServices
{
    public class SolicitanteService : ISolicitante
    {
        public List<Solicitante> ListarSolicitante()
        {
            try
            {
                var lista = new SolicitanteBl().Obtener();
                return lista;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<Solicitante> ObtenerSolicitante(int codigo)
        {
            try
            {
                var lista = new SolicitanteBl().ObtenerSolicitante(codigo);
                return lista;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public String AgregarSolicitante(Solicitante pSolicitante, ref int codigo)
        {
            String mensaje = "";
            try
            {
                bool validacion = verificaSolicitante(pSolicitante, ref mensaje);

                if (validacion)
                {
                    bool resultado = new SolicitanteBl().Agregar(ref pSolicitante);
                    if (resultado)
                    {
                        codigo = pSolicitante.codigo;
                        return mensaje;
                    }
                    else
                    {
                        pSolicitante = null;
                        return "Ocurrio un error al momento de registrar al solicitante.";
                    }
                }
                else
                {
                    pSolicitante = null;
                    return mensaje;
                }
            }
            catch (Exception ex)
            {
                pSolicitante = null;
                throw new FaultException(ex.Message);
            }
        }

        private bool verificaSolicitante(Solicitante pSolicitante, ref String mensaje)
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
            int resultado = 0;
            bool verifica = int.TryParse(cadena, out resultado);
            return verifica;
        }
    }
}