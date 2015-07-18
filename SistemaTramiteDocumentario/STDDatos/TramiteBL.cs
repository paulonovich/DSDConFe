using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STDDatos
{
    public class TramiteBl
    {
        public List<Tramite> Obtener()
        {
            try
            {
                BDDOCUMENTUMEntities datos = new BaseDAO().conexion();
                var vResult = datos.Tramite.ToList();
                return vResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool Agregar(ref Tramite pTramite)
        {
            try
            {
                BDDOCUMENTUMEntities datos = new BaseDAO().conexion();
                datos.Tramite.AddObject(pTramite);
                var vResult = datos.SaveChanges();
                if (vResult > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
