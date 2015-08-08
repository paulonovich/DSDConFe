using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using STDDatos;
using STDNegocio;

namespace SistemaTramiteDocumentario
{
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNeg usuarioNegocio = new UsuarioNeg();
                Usuario eUsuario = new Usuario();
                Usuario usuarioCrear = new Usuario();
                string mensaje = "";
                eUsuario.DNI = txtDNI.Text;
                eUsuario.Nombre = txtNombre.Text;
                eUsuario.Tipo = ddlTipo.SelectedIndex.ToString();
                usuarioCrear = usuarioNegocio.ObtenerUsuario(txtDNI.Text, ref mensaje);
                if (mensaje.Equals("No existe usuario."))
                {
                    mensaje = usuarioNegocio.AgregarUsuario(eUsuario);
                    lblError.Text = mensaje;
                }
                else
                {
                    lblError.Text = mensaje;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}