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
    [ServiceContract]
    public interface IExpediente
    {
        [OperationContract]
        bool Agregar(ref Expediente pExpediente);

        [OperationContract]
        bool Actualizar(ref Expediente pExpediente);

        [OperationContract]
        List<Expediente> Obtener(int codigo);

    }
}