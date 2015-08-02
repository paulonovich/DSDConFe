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
        public String Actualizar(STDDatos.Expediente expedienteModificado)
        {
            String mensaje = "";
            try
            {
                bool resultado = new STDDatos.EvaluacionBL().Actualizar(expedienteModificado);
                if (!resultado)
                {
                    return "Ocurrio un error al momento de actualizar el expediente.";
                }
                return mensaje;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<STDDatos.Evaluacion> Listar()
        {
            try
            {
                var lista = new STDDatos.EvaluacionBL().Listar();
                return lista;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public List<STDDatos.Evaluacion> Obtener(string codigo)
        {
            string mensaje = "";
            try
            {
                int numero = 0;
                mensaje = "Debe enviar un codigo valido";
                numero = Convert.ToInt32(codigo);
                var lista = new STDDatos.EvaluacionBL().Obtener(numero);
                if (lista.Count > 0)
                {
                    return lista;
                }
                else
                {
                    mensaje = "No hay informacion del expediente";
                    throw new WebFaultException<string>("No hay informacion del expediente", System.Net.HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception)
            {
                throw new WebFaultException<string>(mensaje, System.Net.HttpStatusCode.InternalServerError);

            }


        }
    }
}
