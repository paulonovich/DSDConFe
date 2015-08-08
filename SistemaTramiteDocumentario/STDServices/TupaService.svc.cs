using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace STDServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class TupaService : ITupa
    {
        public List<STDDatos.Tupa> ObtenerTupa(int codigoTramite)
        {
            try
            {
                return new STDDatos.TupaBl().Obtener(codigoTramite);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}