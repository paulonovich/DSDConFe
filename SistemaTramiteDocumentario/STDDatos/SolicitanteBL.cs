using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STDDatos
{
    public class SolicitanteBl
    {
        public List<Solicitante> Listar()
        {
            try
            {
                using (BDDOCUMENTUMEntities datos = new BaseDAO().conexion())
                {
                    var vResult = datos.Solicitantes.ToList();
                    return vResult;
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al listar los solicitantes.");
            }
        }

        public Solicitante Obtener(int codigoSolicitante)
        {
            try
            {
                using (BDDOCUMENTUMEntities datos = new BaseDAO().conexion())
                {
                    var vResult = datos.Solicitantes.FirstOrDefault(t => t.codigo == codigoSolicitante);
                    if (vResult != null)
                        return vResult;
                    else
                        throw new Exception("No existe el Solicitante a buscar");
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al buscar el Solicitante.");
            }
        }

        public bool Agregar(ref Solicitante pSolicitante)
        {
            try
            {
                using (BDDOCUMENTUMEntities datos = new BaseDAO().conexion())
                {
                    datos.Solicitantes.AddObject(pSolicitante);
                    var vResult = datos.SaveChanges();
                    if (vResult > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al registrar el solicitante.");
            }
        }
    }
}
