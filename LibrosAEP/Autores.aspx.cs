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
    public partial class Autores : System.Web.UI.Page
    {

        public List<Autor> listaAutor { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("FiltroBusqueda", 4);

            AutorNegocio negocio = new AutorNegocio();
            try
            {
                if (Session["listaAutor"] != null)
                {
                    listaAutor = (List<Autor>)Session["listaAutor"];
                    repRepetidor.DataSource = listaAutor;
                    repRepetidor.DataBind();

                }
                else
                {

                    listaAutor = new List<Autor>();

                    bool porOrdenAlfabetico = true;
                    listaAutor = negocio.listar(porOrdenAlfabetico);


                    repRepetidor.DataSource = listaAutor;
                    repRepetidor.DataBind();
                }
            }

            catch (Exception ex)
            {

                throw ex;
            }




        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = ((Button)sender).CommandArgument;
                AutorNegocio negocio = new AutorNegocio();

                negocio.AltaLogica(int.Parse(Id));
                Response.Redirect("Autores.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de alta al Autor: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = ((Button)sender).CommandArgument;
                AutorNegocio negocio = new AutorNegocio();

                negocio.BajaLogica(int.Parse(Id));
                Response.Redirect("Autores.aspx");

            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de baja al Autor: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
        }

        protected void btnAgregarNuevo_Click(object sender, EventArgs e)
        {
            Session["PaginaAnterior"] = Request.Url.ToString();
            Response.Redirect("FormAltaAutor.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string Id = ((Button)sender).CommandArgument;
            Response.Redirect("FormAltaAutor.aspx?Id=" + Id, false);

        }
    }
}