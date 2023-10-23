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
    public partial class DatosUsuario : System.Web.UI.Page
    {
        UsuarioNegocio negocio = new UsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    Usuario usuario = new Usuario();
                    usuario = (Usuario)Session["usuario"];

                    int id = usuario.ID;

                    TxtApellido.Text = usuario.Apellido;

                    TxtNombre.Text = usuario.Nombre;
                    TxtPass.Text = "Ingrese contraseña";

                }

            }
        }

        bool ValidarVacios()
        {

            TxtApellido.BorderColor = Color.White;
            TxtNombre.BorderColor = Color.White;
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
            if (TxtPass.Text == "")
            {
                TxtPass.BorderColor = Color.Red;
                vacios = true;
            }


            return vacios;
        }
        public void BtnAceptar_Click(object sender, EventArgs e)
        {

            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["usuario"];

            usuario.Nombre = TxtNombre.Text;
            usuario.Apellido = TxtApellido.Text;
            usuario.Pass = TxtPass.Text;

            if (ValidarVacios() == false)
            {
                negocio.modificarContraseña(usuario);
                Response.Redirect("MiPerfil.aspx", false);

            }
            else
            {
                LblMensaje.Text = "Complete todos los campos necesarios, por favor.";
                LblMensaje.Visible = true;
                return;
            }

        }

        public void BtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiPerfil.aspx", false);
        }

    }
}