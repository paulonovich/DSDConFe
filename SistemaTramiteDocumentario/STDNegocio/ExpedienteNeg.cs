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

        public Expediente ObtenerExpediente(int codigo, ref String mensaje)
        {
            try
            {
                mensaje = "";
                return cliente.ObtenerExpediente(codigo);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return null;
            }
        }

        public Expediente AgregarExpediente(Expediente pExpediente, ref String mensaje)
        {
            try
            {
                bool resultado = cliente.AgregarExpediente(ref pExpediente);
                mensaje = "Expediente registrado.";
                return pExpediente;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return null;
            }
        }
    }
}
