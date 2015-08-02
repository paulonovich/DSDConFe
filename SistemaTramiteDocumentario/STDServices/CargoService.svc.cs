using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace STDServices
{
    public class CargoService : ICargo
    {
        public List<STDDatos.Cargo> ObtenerCargo(int codigo)
        {
            try
            {
                List<STDDatos.Cargo> lista = new STDDatos.CargoBl().Obtener(codigo);
                return lista;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AgregarCargo(STDDatos.Cargo pCargo)
        {
            bool resultado = new STDDatos.CargoBl().Agregar(ref pCargo);
            return resultado;
        }


        public int ObtenerNuevoCodigo()
        {
            try
            {
                var lista = new STDDatos.CargoBl().ObtenerValorAutogenerado();
                return lista;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}