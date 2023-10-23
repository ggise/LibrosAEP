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
    public partial class Detalle : System.Web.UI.Page
    {

        public List<Libro> listaproducto { get; set; }

        public Libro LibroSeleccionado { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["iddetalle"] != null)
                {
                    Int32 id = Int32.Parse(Request.QueryString["iddetalle"]);
                    LibroNegocio negocio = new LibroNegocio();
                    LibroSeleccionado = negocio.ObtenerLibro(id);
                    Session.Add("Id", id);
                    Session.Add("producto", LibroSeleccionado);

                }
                else
                {
                    Response.Redirect("Inicio.aspx", false);
                }
                if (Request.QueryString["id"] != null)
                {
                    Int32 IdArt = Int32.Parse(Request.QueryString["id"]);
                    Session.Add("idArtCarrito", IdArt);

                    Session.Add("items", 1);


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