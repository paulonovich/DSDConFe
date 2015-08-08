using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STDNegocio.WSTupa;
using STDDatos;

namespace STDNegocio
{
    public class TupaNeg
    {
        TupaClient cliente = new TupaClient();
        public List<Tupa> ObtenerTupa(int codigoTramite, ref String mensaje)
        {
            try
            {
                mensaje = "";
                return cliente.ObtenerTupa(codigoTramite);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return null;
            }
        }
    }
}
