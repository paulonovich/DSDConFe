using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using STDNegocio.WSSolicitante;
using STDDatos;

namespace STDNegocio
{
    public class SolicitanteNeg
    {
        SolicitanteClient cliente = new SolicitanteClient();

        public List<Solicitante> ListarSolicitante(ref String mensaje)
        {
            try
            {
                List<Solicitante> lista = cliente.ListarSolicitante();
                mensaje = "";
                return lista;
            }
            catch (Exception)
            {
                mensaje = "No se pudo obtener la lista de solicitantes.";
                return null;
            }
        }

        public List<Solicitante> ObtenerSolicitante(int codigo, ref String mensaje)
        {
            try
            {
                List<Solicitante> lista = cliente.ObtenerSolicitante(codigo);
                mensaje = "";
                return lista;
            }
            catch (Exception)
            {
                mensaje = "No se pudo obtener la información del solicitante.";
                return null;
            }
        }

        public void AgregarSolicitante(Solicitante pSolicitante, ref String mensaje, ref int codigo)
        {
            try
            {
                String resultado = cliente.AgregarSolicitante(pSolicitante,ref codigo);
                if (resultado.Equals("")) { mensaje = resultado; }
                else { mensaje = "Solicitante registrado!"; }
            }
            catch (Exception)
            {
                mensaje = "No se pudo registrar el solicitante.";
            }
        }
    }
}
