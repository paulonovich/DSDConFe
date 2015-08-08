using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STDDatos
{
    public class CargoBl
    {
        public Cargo Obtener(int codigoCargo)
        {
            try
            {
                using (BDDOCUMENTUMEntities datos = new BaseDAO().conexion())
                {
                    var vResult = datos.Cargoes.FirstOrDefault(t => t.codigo == codigoCargo);
                    if (vResult != null)
                        return vResult;
                    else
                        throw new Exception("No existe el Cargo a buscar");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al buscar el cargo.");
            }
        }

        public int ObtenerValorAutogenerado()
        {
            try
            {
                BDDOCUMENTUMEntities datos = new BaseDAO().conexion();
                var vResult = datos.Cargoes.ToList();
                var vMax = 0;

                if (vResult.Count>0)
                {
                    vMax = vResult.Max(t => t.codigo);
                }
                return vMax + 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al retornar el nuevo código.");
            }
        }

        public bool Agregar(ref Cargo pCargo)
        {
            try
            {
                using (BDDOCUMENTUMEntities datos = new BaseDAO().conexion())
                {
                    datos.Cargoes.AddObject(pCargo);
                    var vResult = datos.SaveChanges();
                    if (vResult > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al registrar el cargo.");
            }
        }
    }
}
