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
    public partial class LibrosFiltrados : System.Web.UI.Page
    {
        public List <Libro> listaLibro { get;set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("FiltroBusqueda", 2);
            LibroNegocio negocio = new LibroNegocio();
            try
            {
                //no va a carrito terminar la logica

                listaLibro = (List<Libro>)Session["listaFiltrada"];

                if (listaLibro != null)
                {

                    Session.Add("listaLibro", listaLibro);

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

    }
}