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

        public List<Tramite> ListarTramites(ref String mensaje)
        {
            try
            {
                TramiteClient cliente = new TramiteClient();
                List<Tramite> lista = cliente.ListarTramites();
                mensaje = "";
                return lista;
            }
            catch (Exception)
            {
                mensaje = "No se pudo cargar la lista de tramites.";
                return null;
            }
        }
    }
}
