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
        public List<Cargo> ObtenerCargo(int codigo, ref String mensaje)
        {
            try
            {
                List<Cargo> lista = cliente.ObtenerCargo(codigo);
                mensaje = "";
                return lista;
            }
            catch (Exception)
            {
                mensaje = "No se pudo registrar el cargo.";
                return null;
            }
        }

        public void AgregarCargo(Cargo pCargo, ref String mensaje)
        {
            try
            {
                bool resultado = cliente.AgregarCargo(pCargo);
                if (!resultado) mensaje = "No se pudo registrar el cargo.";
                else mensaje = "Cargo registrado!";
            }
            catch (Exception)
            {
                mensaje = "No se pudo registrar el cargo.";
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
