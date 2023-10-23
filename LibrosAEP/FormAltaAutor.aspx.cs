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
    public partial class FormAltaAutor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                Autor Autor = new Autor();
                AutorNegocio negocio = new AutorNegocio();

                LblNombre.Text = "Alta Autor";

                if (!IsPostBack)
                {
                    string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                    if (Id != "")

                    {
                        int IdAutor = int.Parse(Id);
                        Autor = negocio.ObtenerAutorPorId(IdAutor);

                        TxtNombre.Text = Autor.Nombre.ToString();
                        LblNombre.Text = "Modificar Arista";

                    }


                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        bool ValidarVacios()
        {
            TxtNombre.BorderColor = Color.White;
            bool vacios = false;
            if (TxtNombre.Text == "")
            {
                TxtNombre.BorderColor = Color.Red;
                LblMensaje.Text = "Complete el campo...";
                LblMensaje.Visible = true;
                vacios = true;
            }



            return vacios;
        }


        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                AutorNegocio negocio = new AutorNegocio();
                Autor Autor = new Autor();
                string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                if (Id != "")

                {
                    int IdAutor = int.Parse(Id);
                    Autor = negocio.ObtenerAutorPorId(IdAutor);
                    Autor.Nombre = TxtNombre.Text;
                    negocio.modificar(Autor);
                    LblMensaje.Text = "Autor modificado exitosamente";
                    LblMensaje.Visible = true;
                    Response.Redirect("Autores.aspx", false);

                }
                else
                {
                    if (ValidarVacios() == false)
                    {
                        Autor nuevo = new Autor();
                        nuevo.Nombre = TxtNombre.Text;

                        negocio.agregar(nuevo);
                        LblMensaje.Text = "Autor agregado exitosamente";
                        LblMensaje.Visible = true;

                        string paginaAnterior = Session["PaginaAnterior"] as string;
                        if (!string.IsNullOrEmpty(paginaAnterior))
                        {
                            Response.Redirect(paginaAnterior, false);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);

            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            string paginaAnterior = Session["PaginaAnterior"] as string;
            if (!string.IsNullOrEmpty(paginaAnterior))
                Response.Redirect(paginaAnterior, false);
            else
                Response.Redirect("Autores.aspx", false);
        }
    }
}