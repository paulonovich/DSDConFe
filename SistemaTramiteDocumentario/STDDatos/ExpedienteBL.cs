using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STDDatos
{
    public class ExpedienteBl
    {
        public bool Agregar(ref Expediente pExpediente)
        {
            try
            {
                using (BDDOCUMENTUMEntities datos = new BaseDAO().conexion())
                {
                    datos.Expedientes.AddObject(pExpediente);
                    var vResult = datos.SaveChanges();
                    if (vResult > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al registrar el expediente.");
            }
        }

        public bool Actualizar(ref Expediente pExpediente)
        {
            try
            {
                using (BDDOCUMENTUMEntities datos = new BaseDAO().conexion())
                {
                    datos.Expedientes.Attach(pExpediente);
                    datos.ObjectStateManager.ChangeObjectState(pExpediente, System.Data.EntityState.Modified);
                    var vResult = datos.SaveChanges();
                    if (vResult > 0)
                        return true;
                    else
                        throw new Exception("No existe el registro Expediente para modificar.");
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al actualizar el expediente.");
            }
        }

        public Expediente Obtener(int codigoExpediente)
        {
            try
            {
                using (BDDOCUMENTUMEntities datos = new BaseDAO().conexion())
                {
                    var vResult = datos.Expedientes.FirstOrDefault(t => t.codigo == codigoExpediente);
                    if (vResult != null)
                        return vResult;
                    else
                        throw new Exception("No existe el Expediente a buscar");
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al buscar el Expediente.");
            }
        }
    }
}
