using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using STDDatos;

namespace STDServices
{
    public class ExpedienteService : IExpediente
    {
        public bool Agregar(ref Expediente pExpediente)
        {
            bool resultado = new ExpedienteBl().Agregar(ref pExpediente);
            return resultado;
        }
                
        public bool Actualizar(ref Expediente pExpediente)
        {
            throw new NotImplementedException();
        }
        
        public List<Expediente> Obtener(int codigo)
        {
            try
            {
                var lista = new ExpedienteBl().Obtener(codigo);
                return lista;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}