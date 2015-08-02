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
                List<Tupa> lista = cliente.ObtenerTupa(codigoTramite);
                mensaje = "";
                return lista;
            }
            catch (Exception)
            {
                mensaje = "No se pudo obtener los requisitos.";
                return null;
            }
        }
    }
}
