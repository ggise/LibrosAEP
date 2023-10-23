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
    public partial class Generos : System.Web.UI.Page
    {
        public List<Genero> listaGenero { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("FiltroBusqueda", 3);
            GeneroNegocio negocio = new GeneroNegocio();
            try
            {

                if (!IsPostBack)
                {
                    bool activos = false;
                    listaGenero = negocio.listar(activos);

                    repRepetidor.DataSource = listaGenero;
                    repRepetidor.DataBind();

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
                GeneroNegocio negocio = new GeneroNegocio();

                negocio.BajaLogica(int.Parse(Id));
                Response.Redirect("Generos.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de alta un Genero: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = ((Button)sender).CommandArgument;
                GeneroNegocio negocio = new GeneroNegocio();

                negocio.AltaLogica(int.Parse(Id));
                Response.Redirect("Generos.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de alta la Genero: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }

        protected void btnAgregarNuevo_Click(object sender, EventArgs e)
        {

            Session["PaginaAnterior"] = Request.Url.ToString();
            Response.Redirect("FormAltaGenero.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("FormAltaGenero.aspx?Id=" + Id, false);
        }
    }
}