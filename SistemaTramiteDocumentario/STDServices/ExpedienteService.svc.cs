using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace STDServices
{
    public class ExpedienteService : IExpediente
    {
        public bool AgregarExpediente(ref STDDatos.Expediente pExpediente)
        {
            bool resultado = new STDDatos.ExpedienteBl().Agregar(ref pExpediente);
            return resultado;
        }

        public List<STDDatos.Expediente> ObtenerExpediente(int codigo)
        {
            try
            {
                var lista = new STDDatos.ExpedienteBl().Obtener(codigo);
                return lista;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}