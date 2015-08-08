using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STDNegocio.WSTramite;
using STDDatos;

namespace STDNegocio
{
    public class TramiteNeg
    {
        TramiteClient cliente = new TramiteClient();
        public List<Tramite> ListarTramites(ref String mensaje)
        {
            try
            {
                mensaje = "";
                return cliente.ListarTramites();
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return null;
            }
        }
    }
}
