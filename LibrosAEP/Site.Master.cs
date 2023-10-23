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
    public partial class SiteMaster : MasterPage
    {
        Libro producto = new Libro();
        GeneroNegocio generonegocio = new GeneroNegocio();
        UsuarioNegocio negocioUsuario = new UsuarioNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Inicio || Page is LibrosFiltrados
                 || Page is Detalle || Page is _Default
                 || Page is MiPerfil || Page is Contact
                 || Page is Login || Page is error
                 || Page is RegistrarCuenta || Page is Info || Page is OlvideContrasena
                 || Page is LibroxGenero || Page is DatosUsuario
                 || Page is MiLectura
                || Page is SumarLibros))
            {
                if (!Seguridad.esAdmin(Session["usuario"]))
                {
                    Session.Add("error", "No tiene permisos para ingresar a esta pantalla");
                    Response.Redirect("error.aspx");

                }
            }

            if (Page is MiPerfil || Page is DatosUsuario
               || Page is MiLectura || Page is SumarLibros)

            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
            }


            if (!IsPostBack)
            {

                try
                {


                    List<Genero> listaGenero = generonegocio.listar();

                    // Agregar un elemento adicional al inicio de la lista
                    listaGenero.Insert(0, new Genero { Id = -1, Descripcion = "Seleccionar Genero" });

                    Session["listaGenero"] = listaGenero;
                    ddlGenero.DataSource = listaGenero;
                    ddlGenero.DataTextField = "Descripcion";
                    ddlGenero.DataValueField = "Id";
                    ddlGenero.DataBind();


                    // Establecer el elemento predeterminado
                    ddlGenero.SelectedIndex = -1;



                }




                catch (Exception ex)
                {

                    Session.Add("error", ex);
                    throw;
                }
            }
        }
        protected void ddlGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ddlGenero.SelectedValue);
            if (id > 0)
            {
                Response.Redirect("LibroxGenero.aspx?IdGenero=" + id, false);
            }

        }
        /*
                protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
                {
                    int id = int.Parse(ddlUsuario.SelectedValue);
                    if (id > 0)
                    {
                        Response.Redirect("LibrosxUsuario.aspx?IdUsuario=" + id, false);
                    }
                }
        */

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            Session.Remove("listaFiltrada");
            Session.Remove("ListarUsuarios");
            Session.Remove("listaAutor");

            List<Libro> listaFiltrada = new List<Libro>();
            LibroNegocio negocio = new LibroNegocio();
            string buscar = txtFiltro.Text;


            if (buscar != "")
            {
                listaFiltrada = negocio.listaFiltrada(buscar);
            }
            else
            {
                listaFiltrada = negocio.listar();
            }

            // Guardar la lista actualizada en la sesión
            Session["listaFiltrada"] = listaFiltrada;

            if (Page is Listar)
            {
                Response.Redirect("Listar.aspx", false);
            }
            else if (Page is ListarUsuarios)
            {
                List<Usuario> listaUsuarios = new List<Usuario>();
                UsuarioNegocio negocioUsuario = new UsuarioNegocio();
                listaUsuarios = negocioUsuario.listar(buscar);
                Session["ListarUsuarios"] = listaUsuarios;
                Response.Redirect("ListarUsuarios.aspx", false);
            }
            else if (Page is Autores)
            {
                List<Autor> listaAutor = new List<Autor>();
                AutorNegocio AutorNegocio = new AutorNegocio();
                listaAutor = AutorNegocio.listar(buscar);
                Session["listaAutor"] = listaAutor;
                Response.Redirect("Autores.aspx", false);
            }
            else
            {
                // Redireccionar a la página de inicio
                Response.Redirect("LibrosFiltrados.aspx", false);
            }

        }


        public void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Inicio.aspx", false);
        }
    }
}