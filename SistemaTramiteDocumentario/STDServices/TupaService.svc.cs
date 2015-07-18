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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class TupaService : ITupa 
    {
        public List<Tupa> ListarTupa(int codigoTramite)
        {
            try
            {
                var lista = new TupaBl().ObtenerTupa(codigoTramite);
                return lista;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }

        }
    }
}