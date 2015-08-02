using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STDNegocio.WSExpediente;
using STDDatos;

namespace STDNegocio
{
    public class ExpedienteNeg
    {
        ExpedienteClient cliente = new ExpedienteClient();

        public void AgregarExpediente(Expediente pExpediente, ref String mensaje, ref int codigo)
        {
            try
            {
                bool resultado = cliente.AgregarExpediente(ref pExpediente);
                if (resultado)
                {
                    mensaje = "Expediente registrado!";
                    codigo = pExpediente.codigo;
                }
                else
                {
                    mensaje = "No se pudo registrar el expediente";
                    codigo = 0;
                }
            }
            catch (Exception)
            {
                mensaje = "No se pudo registrar el expediente.";
            }
        }

        public List<Expediente> ObtenerExpediente(int codigo, ref String mensaje)
        {
            try
            {
                List<Expediente> lista = cliente.ObtenerExpediente(codigo);
                mensaje = "";
                return lista;
            }
            catch (Exception)
            {
                mensaje = "No se pudo obtener la información del expediente.";
                return null;
            }
        }
    }
}
