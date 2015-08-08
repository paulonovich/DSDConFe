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
        public STDDatos.Expediente ObtenerExpediente(int codigo)
        {
            try
            {
                return new STDDatos.ExpedienteBl().Obtener(codigo);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AgregarExpediente(ref STDDatos.Expediente pExpediente)
        {
            try
            {
                return new STDDatos.ExpedienteBl().Agregar(ref pExpediente);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}