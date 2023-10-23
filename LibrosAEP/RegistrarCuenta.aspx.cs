using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrosAEP
{
    public partial class RegistrarCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        bool ValidarVacios()
        {

            TxtApellido.BorderColor = Color.White;
            TxtNombre.BorderColor = Color.White;
            TxtEmail.BorderColor = Color.White;
            TxtPass.BorderColor = Color.White;

            bool vacios = false;
            if (TxtApellido.Text == "")
            {
                TxtApellido.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtNombre.Text == "")
            {
                TxtNombre.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtEmail.Text == "")
            {
                TxtEmail.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtPass.Text == "")
            {
                TxtPass.BorderColor = Color.Red;
                vacios = true;
            }


            return vacios;
        }
        private bool LongitudContraseña()
        {
            bool cumpleRequisitos = false;
            string campo = TxtPass.Text;

            if (campo.Length >= 3)
            {
                cumpleRequisitos = true;
            }
            return cumpleRequisitos;
        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                EmailService emailService = new EmailService();
                usuario.Nombre = TxtNombre.Text;
                usuario.Apellido = TxtApellido.Text;
                usuario.Email = TxtEmail.Text;
                usuario.Pass = TxtPass.Text;
                if (usuarioNegocio.ExisteUsuarioPorEmail(usuario) != 0)
                {
                    // Mostrar mensaje de error indicando que el correo electrónico ya está en uso

                    LblMensaje.Text = "El correo electrónico ya está registrado. Por favor, utilice otro correo electrónico.";
                    LblMensaje.Visible = true;
                    return;
                }
                if (ValidarVacios() == false)
                {
                    if (LongitudContraseña() == false)
                    {
                        // El campo no cumple con el mínimo de caracteres requeridos
                        LblMensaje.Text = "El campo debe tener al menos 3 caracteres";
                        LblMensaje.Visible = true;
                    }
                    else
                    {

                        usuario.ID = usuarioNegocio.insertarNuevo(usuario);
                        Session.Add("Usuario", usuario);
                        emailService.EnviarCorreo(usuario.Email, "Bienvenidx a Libros AEP", "Gracias por registrarte, esperamos que disfrutes tu experiencia!");

                        Response.Redirect("MiPerfil.aspx", false);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('  usuario creado exitosamente ,Hola " + usuario.Nombre + "');window.location ='Inicio.aspx';", true);

                    }

                }
                else
                {

                    LblMensaje.Text = "Complete todos los campos necesarios, por favor.";
                    LblMensaje.Visible = true;
                    return;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}