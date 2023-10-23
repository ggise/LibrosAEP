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
    public partial class Inicio : System.Web.UI.Page
    {
        public List<Libro> listaLibro { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)  // Asegura que la carga de datos solo se haga en la primera carga y no en postbacks.
            {
                Session.Add("FiltroBusqueda", 2);
                LibroNegocio negocio = new LibroNegocio();
                try
                {
                    listaLibro = negocio.listarInicio();
                    Session.Add("ListaLibro", listaLibro);
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    throw;
                }
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