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
    public partial class LibroxGenero : System.Web.UI.Page
    {
      
        
        public List <Libro> listaLibro { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("FiltroBusqueda", 2);
            LibroNegocio negocio = new LibroNegocio();
            try
            {
                string Id = Request.QueryString["IdGenero"];
                if (Id != null)
                {
                    Int32 IdGenero = Int32.Parse(Request.QueryString["IdGenero"]);
                    Session.Add("IdGenero", IdGenero);//se la necesita por que se pierde el id del gnero cuando se recrga la pg,por ejemplo cuando haces clic en btncarrito
                    listaLibro = negocio.listarxGenero(IdGenero);
                    Session.Add("ListaLibro", listaLibro);
                }
                else
                {
                    Response.Redirect("Inicio.aspx", false);
                }

                if (Request.QueryString["idfiltrado"] != null)
                {
                    Int32 IdArt = Int32.Parse(Request.QueryString["idfiltrado"]);
                    Session.Add("idArtCarrito", IdArt);



                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnLeer_Click(object sender, EventArgs e)
        {
            try
            {
                LibroNegocio negocio = new LibroNegocio();
                Libro seleccionado = new Libro();


                string Id = ((Button)sender).CommandArgument;
                if (Id != "")

                {


                    Response.Redirect("MiLectura.aspx?Id=" + Id, false);

                }

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al seleccionar el Libro: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }

    }
}