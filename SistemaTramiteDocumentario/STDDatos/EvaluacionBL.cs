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
                using (BDDOCUMENTUMEntities datos = new BaseDAO().conexion())
                {
                    var vResult = datos.Evaluacions.ToList();
                    return vResult;
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al listar las evaluaciones.");
            }
        }
    }
}
