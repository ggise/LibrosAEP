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
    public partial class Listar : System.Web.UI.Page
    {


        public List<Libro> listaLibro { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {

            Session.Add("FiltroBusqueda", 2);
            LibroNegocio negocio = new LibroNegocio();
            if (!IsPostBack)
            {
                try
                {
                    Session.Remove("listaFiltrada");

                    if (Session["listaFiltrada"] != null)
                    {
                        listaLibro = (List<Libro>)Session["listaFiltrada"];
                        repRepetidor.DataSource = listaLibro;
                        repRepetidor.DataBind();

                    }
                    else
                    {
                        listaLibro = new List<Libro>();

                        bool activos = false;
                        listaLibro = negocio.listar(activos);

                        repRepetidor.DataSource = listaLibro;
                        repRepetidor.DataBind();
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("FormAltaLibro.aspx?Id=" + Id, false);

        }

        protected void BtnAlta_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormAltaLibro.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = ((Button)sender).CommandArgument;
                LibroNegocio negocio = new LibroNegocio();

                negocio.BajaLogica(int.Parse(Id));
                Response.Redirect("Listar.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de alta la Libros: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = ((Button)sender).CommandArgument;
                LibroNegocio negocio = new LibroNegocio();

                negocio.AltaLogica(int.Parse(Id));
                Response.Redirect("Listar.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de alta el Libros: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }
    }
}
