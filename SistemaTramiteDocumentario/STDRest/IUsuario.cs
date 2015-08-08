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
    public interface IUsuario
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Usuario/{dni}", ResponseFormat = WebMessageFormat.Json)]
        STDDatos.Usuario ObtenerUsuario(string dni);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Usuario", ResponseFormat = WebMessageFormat.Json)]
        bool AgregarUsuario(STDDatos.Usuario pUsuario);
    }
}