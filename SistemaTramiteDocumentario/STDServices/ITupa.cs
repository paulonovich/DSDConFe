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
    public interface ITupa
    {
        [OperationContract]
        List<Tupa> ListarTupa(int codigoTramite);
    }
}