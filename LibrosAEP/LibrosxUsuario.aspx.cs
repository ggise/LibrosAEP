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
    public partial class LibrosxUsuario : System.Web.UI.Page
    {

        public List<Libro> listaLibro { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            LibroNegocio negocio = new LibroNegocio();
            try
            {
                string Id = Request.QueryString["IdUsuario"];
                if (Id != null)
                {
                    Int32 IdUsuario = Int32.Parse(Request.QueryString["IdUsuario"]);
                    Session.Add("IdUsuario", IdUsuario);//se la necesita por que se pierde el id del gnero cuando se recrga la pg,por ejemplo cuando haces clic en btncarrito
                    listaLibro = negocio.listarxUsuario(IdUsuario);
                    Session.Add("ListaLibro", listaLibro);
                }
                else
                {
                    Response.Redirect("Inicio.aspx", false);
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