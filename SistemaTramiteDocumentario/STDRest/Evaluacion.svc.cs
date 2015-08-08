using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace STDRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Evaluacion : IEvaluacion
    {
        public List<STDDatos.Evaluacion> Listar()
        {
            string mensaje = "";
            try
            {
                List<STDDatos.Evaluacion> lista = new STDDatos.EvaluacionBL().Listar();
                if (lista.Count > 0) return lista;
                else
                {
                    mensaje = "No se encontraron registros.";
                    throw new FaultException(mensaje);
                }
            }
            catch (Exception)
            {
                throw new FaultException(mensaje);
            }
        }

        public STDDatos.Expediente Actualizar(STDDatos.Expediente expedienteModificado)
        {
            string mensaje = "";
            try
            {
                bool respuesta = new STDDatos.ExpedienteBl().Actualizar(ref expedienteModificado);
                if (respuesta)
                {
                    return expedienteModificado;
                }
                else
                {
                    mensaje = "No se actualizó el expediente.";
                    throw new FaultException(mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new FaultException(mensaje);
            }
        }


        public Evaluacion Obtener(string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
