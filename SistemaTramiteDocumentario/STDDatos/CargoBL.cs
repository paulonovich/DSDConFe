using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STDDatos
{
    public class CargoBl
    {
        public List<Cargo> Obtener(int codigoCargo)
        {
            try
            {
                BDDOCUMENTUMEntities datos = new BaseDAO().conexion();
                var vResult = datos.Cargo.Where(t => t.codigo == codigoCargo).ToList();
                return vResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ObtenerValorAutogenerado()
        {
            try
            {
                BDDOCUMENTUMEntities datos = new BaseDAO().conexion();
                var vResult = datos.Cargo.ToList();
                var vMax = 0;

                if (vResult.Count>0)
                {
                    vMax = vResult.Max(t => t.codigo);
                }
                return vMax + 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Agregar(ref Cargo pCargo)
        {
            try
            {
                BDDOCUMENTUMEntities datos = new BaseDAO().conexion();
                datos.Cargo.AddObject(pCargo);
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
