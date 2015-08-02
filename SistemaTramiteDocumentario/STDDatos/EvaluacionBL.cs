using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace STDDatos
{
    public class EvaluacionBL
    {
        public List<Evaluacion> Listar()
        {
            try
            {
                BDDOCUMENTUMEntities datos = new BaseDAO().conexion();
                var vResult = datos.Evaluacion.ToList();
                return vResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Evaluacion> Obtener(int codigoExpediente)
        {
            try
            {
                BDDOCUMENTUMEntities datos = new BaseDAO().conexion();
                var vResult = datos.Evaluacion.Where(t => t.codigoExpediente == codigoExpediente).ToList();
                return vResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Actualizar(Expediente pExpediente)
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
    }
}
