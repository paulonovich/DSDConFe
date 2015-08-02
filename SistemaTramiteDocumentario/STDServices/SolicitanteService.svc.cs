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
        public List<STDDatos.Solicitante> ListarSolicitante()
        {
            try
            {
                var lista = new STDDatos.SolicitanteBl().Listar();
                return lista;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<STDDatos.Solicitante> ObtenerSolicitante(int codigo)
        {
            try
            {
                var lista = new STDDatos.SolicitanteBl().Obtener(codigo);
                return lista;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public String AgregarSolicitante(STDDatos.Solicitante pSolicitante, ref int codigo)
        {
            String mensaje = "";
            try
            {
                bool validacion = verificaSolicitante(pSolicitante, ref mensaje);

                if (validacion)
                {
                    bool resultado = new STDDatos.SolicitanteBl().Agregar(ref pSolicitante);
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
    }
}