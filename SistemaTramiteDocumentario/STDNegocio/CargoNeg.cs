using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STDNegocio.WSCargo;
using STDDatos;

namespace STDNegocio
{
    public class CargoNeg
    {
        CargoClient cliente = new CargoClient();
        public Cargo ObtenerCargo(int codigo, ref String mensaje)
        {
            try
            {
                return cliente.ObtenerCargo(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cargo AgregarCargo(Cargo pCargo, ref String mensaje)
        {
            try
            {
                bool resultado = cliente.AgregarCargo(ref pCargo);
                mensaje = "Cargo registrado.";
                return pCargo;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return null;
            }
        }

        public int ObtenerNuevoCodigo(ref String mensaje)
        {
            try
            {
                mensaje = "";
                return cliente.ObtenerNuevoCodigo();
            }
            catch (Exception)
            {
                mensaje = "No se pudo obtener un nuevo código.";
                return 0;
            }
        }
    }
}
