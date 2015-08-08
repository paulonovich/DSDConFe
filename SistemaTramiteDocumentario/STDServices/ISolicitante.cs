using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace STDServices
{
    [ServiceContract]
    public interface ISolicitante
    {
        [OperationContract]
        List<STDDatos.Solicitante> ListarSolicitante();

        [OperationContract]
        STDDatos.Solicitante ObtenerSolicitante(int codigo);

        [OperationContract]
        bool AgregarSolicitante(ref STDDatos.Solicitante pSolicitante);
    }
}