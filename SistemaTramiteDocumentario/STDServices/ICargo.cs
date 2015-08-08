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
        STDDatos.Cargo ObtenerCargo(int codigo);

        [OperationContract]
        bool AgregarCargo(ref STDDatos.Cargo pCargo);

        [OperationContract]
        int ObtenerNuevoCodigo();
    }
}