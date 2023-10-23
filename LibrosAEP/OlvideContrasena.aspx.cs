using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrosAEP
{
    public partial class OlvideContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario = new Usuario();
                Usuario completo = new Usuario();
                UsuarioNegocio negocio = new UsuarioNegocio();


                usuario = usuarioNegocio.ObtenerUsuarioPorMail(TxtEmail.Text);

                if (usuario != null)
                {

                    EmailService emailService = new EmailService();
                    // emailService.EnviarCorreo(usuario.Email, "Restablecer contraseña", "Gracias por registrarte, esperamos que disfrutes tu experiencia!");
                    emailService.EnviarCorreo(usuario.Email, "Olvido su contraseña", "Por favor utilice la siguiente contraseña para ingresar nuevamente, recuerde cambiarla por una nueva. Contraseña: 1111");


                    usuario.Pass = "1111";
                    usuarioNegocio.modificarContraseña(usuario);

                    LblMensaje.Text = "Se envio un mail con la contraseña momentanea";
                    LblMensaje.Visible = true;

                    Response.Redirect("Login.aspx", false);

                }
                else
                {
                    LblMensaje.Text = "El correo electrónico no está registrado";
                    LblMensaje.Visible = true;
                    Response.Redirect("RegistrarCuenta.aspx", false);

                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}