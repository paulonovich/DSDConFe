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

        public Solicitante AgregarSolicitante(Solicitante pSolicitante, ref String mensaje)
        {
            try
            {
                bool resultado = cliente.AgregarSolicitante(ref pSolicitante);
                mensaje = "Solicitante registrado.";
                return pSolicitante;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return null;
            }
        }

        public Solicitante ObtenerSolicitante(int codigo, ref String mensaje)
        {
            try
            {
                mensaje = "";
                return cliente.ObtenerSolicitante(codigo);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return null;
            }
        }















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
    }
}
