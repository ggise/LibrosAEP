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
    public partial class ListarUsuarios : System.Web.UI.Page
    {
        public List<Usuario> listaUsuarios { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("FiltroBusqueda", 1);
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {


                if (!IsPostBack)
                {

                    if (Session["ListarUsuarios"] != null)
                    {
                        listaUsuarios = (List<Usuario>)Session["ListarUsuarios"];

                        repRepetidor.DataSource = listaUsuarios;
                        repRepetidor.DataBind();


                    }
                    else

                    {
                        listaUsuarios = new List<Usuario>();
                        listaUsuarios = negocio.listar();

                        repRepetidor.DataSource = listaUsuarios;
                        repRepetidor.DataBind();

                    }


                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = ((Button)sender).CommandArgument;
                UsuarioNegocio negocio = new UsuarioNegocio();

                negocio.BajaLogica(int.Parse(Id));
                Response.Redirect("ListarUsuarios.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al desactivar usuario: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }

        protected void BtnActivar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = ((Button)sender).CommandArgument;
                UsuarioNegocio negocio = new UsuarioNegocio();

                negocio.AltaLogica(int.Parse(Id));
                Response.Redirect("ListarUsuarios.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al activar usuario: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

        }
    }
}