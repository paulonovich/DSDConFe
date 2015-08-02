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
        bool AgregarExpediente(ref Expediente pExpediente);

        [OperationContract]
        List<Expediente> ObtenerExpediente(int codigo);

    }
}