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
    public partial class FormAltaLibro : System.Web.UI.Page
    {

        GeneroNegocio genero = new GeneroNegocio();
        List<Genero> listaGenero = new List<Genero>();

        UsuarioNegocio usuario = new UsuarioNegocio();
        List<Usuario> listaUsuario = new List<Usuario>();

        AutorNegocio Autor = new AutorNegocio();
        List<Autor> listaAutor = new List<Autor>();

        LibroNegocio negocio = new LibroNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {


                    //Genero
                    listaGenero = genero.listar();
                    listaGenero.Insert(0, new Genero { Id = -1, Descripcion = "Elegir Genero" });
                    ddlGenero.DataSource = listaGenero;
                    ddlGenero.DataTextField = "Descripcion";
                    ddlGenero.DataValueField = "Id";
                    ddlGenero.DataBind();

                    ddlGenero.SelectedIndex = -1;



                    //Autor

                    listaAutor = Autor.listar();

                    listaAutor.Insert(0, new Autor { Id = -1, Nombre = "Elegir Autor" });
                    ddlAutor.DataSource = listaAutor;
                    ddlAutor.DataTextField = "Nombre";
                    ddlAutor.DataValueField = "Id";
                    ddlAutor.DataBind();

                    ddlAutor.SelectedIndex = -1;


                    //Usuario
                    listaUsuario = usuario.listar();
                    listaUsuario.Insert(0, new Usuario { ID = -1, Nombre = "Elegir Dueña" });
                    ddlUsuario.DataSource = listaUsuario;
                    ddlUsuario.DataTextField = "Nombre";
                    ddlUsuario.DataValueField = "ID";
                    ddlUsuario.DataBind();

                    ddlUsuario.SelectedIndex = -1;


                    Lbltitlulo.Text = "Alta de Libros"; //Cambia Dinamicamente dependiendo de donde entre

                    ///Toma el Id del Libro se se viene desde el boton de Modificar en el caso que no tenga Id cargado se asigna""
                    string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                    if (Id != "")

                    {
                        Libro seleccionado = new Libro();
                        seleccionado.Id = int.Parse(Id);
                        int idbuscado = seleccionado.Id;
                        seleccionado = negocio.ObtenerLibro(idbuscado);
                        //se carga los datos del Libro que se selecciono modificar
                        if (!seleccionado.Activo)
                        {
                            Lbltitlulo.Text = "Alta de Libros";
                        }
                        else
                        {
                            Lbltitlulo.Text = "Modificando Libros"; //Cambia Dinamicamente dependiendo de donde entre

                        }

                        TxtTitulo.Text = seleccionado.Titulo.ToString();
                        TxtImgTapa.Text = seleccionado.ImgTapa.ToString();
                        /////



                        //////////////////////////////////////////////

                        /*
                                                List<Usuario> filtrada = new List<Usuario>();
                                                Usuario duena = new Usuario();
                                                int IdDuena = seleccionado.Usuario.ID;

                                                ///se busca la Usuario del Libro seleccionado
                                                duena = usuario.ObtenerPorId(IdDuena);


                                                ddlUsuario.SelectedValue = duena.Nombre.ToString();
                                                ddlUsuario.SelectedValue = seleccionado.Usuario.ID.ToString();
                                                ddlUsuario.SelectedIndex = duena.ID;
                        */
                        /////////////////////////////////////////////////

                        List<Usuario> usuFiltrado = new List<Usuario>();
                        Usuario usuSeleccionado = new Usuario();

                        usuFiltrado = listaUsuario.FindAll(x => x.Nombre == seleccionado.Usuario.Nombre.ToString());
                        usuSeleccionado.ID = usuFiltrado[0].ID;
                        usuSeleccionado.Nombre = seleccionado.Usuario.ToString();

                        ddlUsuario.SelectedValue = usuSeleccionado.ID.ToString();
                        ddlUsuario.SelectedValue = seleccionado.Usuario.ID.ToString();
                        ddlUsuario.SelectedIndex = usuSeleccionado.ID;



                        List<Genero> genFiltrado = new List<Genero>();
                        Genero genSeleccionado = new Genero();


                        genFiltrado = listaGenero.FindAll(x => x.Descripcion == seleccionado.Genero.ToString());
                        genSeleccionado.Id = genFiltrado[0].Id;
                        genSeleccionado.Descripcion = seleccionado.Genero.ToString();


                        ddlGenero.SelectedValue = genSeleccionado.Id.ToString();
                        ddlGenero.SelectedValue = seleccionado.Genero.Id.ToString();
                        ddlGenero.SelectedIndex = genSeleccionado.Id;
                        /////////////////////////////////////////////////////

                        List<Autor> artFiltrado = new List<Autor>();
                        Autor artSeleccionado = new Autor();

                        artFiltrado = listaAutor.FindAll(x => x.Nombre == seleccionado.Autor.ToString());
                        artSeleccionado.Id = artFiltrado[0].Id;
                        artSeleccionado.Nombre = seleccionado.Autor.ToString();

                        ddlAutor.SelectedValue = artSeleccionado.Id.ToString();
                        ddlAutor.SelectedValue = seleccionado.Autor.Id.ToString();
                        ddlAutor.SelectedIndex = artSeleccionado.Id;





                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void btnAgregarAutor_Click(object sender, EventArgs e)
        {
            Session["PaginaAnterior"] = Request.Url.ToString();
            Response.Redirect("FormAltaAutores.aspx", false);
        }
        protected void btnAgregarGenero_Click(object sender, EventArgs e)
        {
            Session["PaginaAnterior"] = Request.Url.ToString();
            Response.Redirect("FormAltaGenero.aspx", false);
        }
        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Session["PaginaAnterior"] = Request.Url.ToString();
            Response.Redirect("FormAltaUsuario.aspx", false);
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                ///
                ///  PARA AGREGAR UN NUEVO Libro
                ///     
                Libro nuevo = new Libro();
                nuevo.Titulo = TxtTitulo.Text;


                LibroNegocio LibroNegocio = new LibroNegocio();


                if (ValidarVacios() == false)
                {

                    nuevo.ImgTapa = TxtImgTapa.Text;
                    nuevo.Genero = new Genero();
                    nuevo.Genero.Id = int.Parse(ddlGenero.SelectedValue);
                    nuevo.Usuario = new Usuario();
                    nuevo.Usuario.ID = int.Parse(ddlUsuario.SelectedValue);
                    nuevo.Autor = new Autor();
                    nuevo.Autor.Id = int.Parse(ddlAutor.SelectedValue);
                    nuevo.Sinopsis = txtSinopsis.Text;
                    nuevo.Activo = true;
                    if (Request.QueryString["Id"] != null)
                    {
                        nuevo.Id = Int32.Parse(Request.QueryString["Id"]);

                        //////
                        ///     PARA MODIFICAR UN Libro
                        ///  
                        LibroNegocio.modificarConSP(nuevo);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert(' " + nuevo.Titulo + " modificado exitosamente');window.location ='Listar.aspx';", true);
                        // Response.Redirect("Listar.aspx");
                    }
                    else
                    {

                        LibroNegocio.agregar(nuevo);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert(' " + nuevo.Titulo + " Agregado exitosamente');window.location ='Listar.aspx';", true);
                        // Response.Redirect("Listar.aspx");

                    }

                }
                else
                {
                    LblMensaje.Text = "Debe ingresar los campos obligatorios";
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
            Response.Redirect("Listar.aspx", false);
        }
        bool ValidarVacios()
        {
            TxtTitulo.BorderColor = Color.White;
            TxtImgTapa.BorderColor = Color.White;
            ddlAutor.BorderColor = Color.White;
            ddlUsuario.BorderColor = Color.White;
            ddlGenero.BorderColor = Color.White;

            bool vacios = false;
            if (TxtTitulo.Text == "")
            {
                TxtTitulo.BorderColor = Color.Red;
                vacios = true;
            }
            if (ddlAutor.SelectedIndex == -1)
            {
                ddlAutor.BorderColor = Color.Red;
                vacios = true;
            }
            if (ddlUsuario.SelectedIndex == -1)
            {
                ddlUsuario.BorderColor = Color.Red;
                vacios = true;
            }
            if (ddlGenero.SelectedIndex == -1)
            {
                ddlGenero.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtImgTapa.Text == "")
            {

                TxtImgTapa.BorderColor = Color.Red;
                vacios = true;
            }
            return vacios;
        }


    }
}