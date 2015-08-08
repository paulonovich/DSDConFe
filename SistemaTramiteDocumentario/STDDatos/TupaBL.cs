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
                using (BDDOCUMENTUMEntities datos = new BaseDAO().conexion())
                {
                    var vResult = datos.Tupas.Where(t => t.codigoTramite == codigoTramite).ToList();
                    if (vResult != null)
                        return vResult;
                    else
                        throw new Exception("No existe informacion del TUPA a buscar");
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al buscar el TUPA.");
            }
        }
    }
}
