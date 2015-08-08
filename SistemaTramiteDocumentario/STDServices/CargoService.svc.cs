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
        public STDDatos.Cargo ObtenerCargo(int codigo)
        {
            try
            {
                return new STDDatos.CargoBl().Obtener(codigo);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }

        public bool AgregarCargo(ref STDDatos.Cargo pCargo)
        {
            try
            {
                return new STDDatos.CargoBl().Agregar(ref pCargo);
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
        
        public int ObtenerNuevoCodigo()
        {
            try
            {
                var nuevoCodigo = new STDDatos.CargoBl().ObtenerValorAutogenerado();
                return nuevoCodigo;
            }
            catch (Exception ex)
            {
                throw new FaultException(ex.Message);
            }
        }
    }
}