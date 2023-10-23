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
    public partial class SumarLibros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiPerfil.aspx", false);
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSumarLibros.Text))
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    Usuario logueado = (Usuario)Session["usuario"];
                    int IdUsuario = logueado.ID;
                    EmailService emailService = new EmailService();
                    Usuario adm = new Usuario();
                    adm = negocio.ObtenerUsuarioPorId(1);
                    string libros = txtSumarLibros.Text;

                    emailService.EnviarCorreo(adm.Email, "Alguien quiere sumar su libro", "Hola! " + logueado.Nombre + " quiere sumar sus libros: " + libros);

                    lblMensaje.Text = "Muchas gracias por compartir.\nLa administradora lo sumará a la Biblioteca.";
                    lblMensaje.Visible = true;

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }

    }
}