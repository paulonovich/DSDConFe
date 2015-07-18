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
    public interface ISolicitante
    {
        [OperationContract]
        List<Solicitante> ListarSolicitante();

        [OperationContract]
        List<Solicitante> ObtenerSolicitante(int codigo);

        [OperationContract]
        String AgregarSolicitante(Solicitante pSolicitante, ref int codigo);
    }
}