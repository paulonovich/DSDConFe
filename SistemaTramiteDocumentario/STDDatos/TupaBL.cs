using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STDDatos
{
    public class TupaBl
    {
        public List<Tupa> Obtener(int codigoTramite)
        {
            try
            {
                BDDOCUMENTUMEntities datos = new BaseDAO().conexion();
                var vResult = datos.Tupa.Where(t => t.codigoTramite == codigoTramite).ToList();
                return vResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
