using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STDDatos
{
    public class SolicitanteBl
    {
        public List<Solicitante> Obtener()
        {
            try
            {
                BDDOCUMENTUMEntities datos = new BaseDAO().conexion();
                var vResult = datos.Solicitante.ToList();
                return vResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Solicitante> ObtenerSolicitante(int codigoSolicitante)
        {
            try
            {
                BDDOCUMENTUMEntities datos = new BaseDAO().conexion();
                var vResult = datos.Solicitante.Where(t => t.codigo == codigoSolicitante).ToList();
                return vResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Agregar(ref Solicitante pSolicitante)
        {
            try
            {
                BDDOCUMENTUMEntities datos = new BaseDAO().conexion();
                datos.Solicitante.AddObject(pSolicitante);
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
