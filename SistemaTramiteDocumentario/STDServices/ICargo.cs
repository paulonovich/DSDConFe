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
    public interface ICargo
    {
        [OperationContract]
        List<Cargo> ObtenerCargo(int codigo);

        [OperationContract]
        int ObtenerCodigo();

        [OperationContract]
        bool AgregarCargo(Cargo pCargo);
    }
}