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
                BDDOCUMENTUMEntities datos = new BaseDAO().conexion();
                datos.Expediente.AddObject(pExpediente);
                var vResult = datos.SaveChanges();
                if (vResult > 0)
                {
                    pExpediente.codigo = vResult;
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

        public bool Actualizar(ref Expediente pExpediente)
        {
            try
            {
                BDDOCUMENTUMEntities datos = new BaseDAO().conexion();
                datos.Expediente.Attach(pExpediente);
                datos.ObjectStateManager.ChangeObjectState(pExpediente, System.Data.EntityState.Modified);
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

        public List<Expediente> Obtener(int codigo)
        {
            try
            {
                BDDOCUMENTUMEntities datos = new BaseDAO().conexion();
                var vResult = datos.Expediente.Where(t => t.codigo == codigo).ToList();
                return vResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
