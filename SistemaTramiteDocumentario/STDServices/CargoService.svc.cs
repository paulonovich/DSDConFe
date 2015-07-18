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
    public class CargoService : ICargo
    {        
        public List<Cargo> ObtenerCargo(int codigo)
        {
            try
            {
                var lista = new CargoBl().Obtener(codigo);
                return lista;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AgregarCargo(Cargo pCargo)
        {
            bool resultado = new CargoBl().Agregar(ref pCargo);
            return resultado;
        }


        public int ObtenerCodigo()
        {
            try
            {
                var lista = new CargoBl().ObtenerCodigo();
                return lista;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}