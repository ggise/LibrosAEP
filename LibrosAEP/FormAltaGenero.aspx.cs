using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace LibrosAEP
{
    public partial class FormAltaGenero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Genero genero = new Genero();
            GeneroNegocio negocio = new GeneroNegocio();
            try
            {
                LblNombre.Text = "Alta Genero";

                if (!IsPostBack)
                {
                    string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                    if (Id != "")

                    {
                        int IdGenero = int.Parse(Id);
                        genero = negocio.ObtenerPorId(IdGenero);

                        TxtNombre.Text = genero.Descripcion.ToString();
                        LblNombre.Text = "Modificar Genero";

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
                Genero nuevo = new Genero();
                Genero modificar = new Genero();
                GeneroNegocio negocio = new GeneroNegocio();

                string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                if (Id != "")

                {
                    int IdGenero = int.Parse(Id);
                    modificar = negocio.ObtenerPorId(IdGenero);
                    modificar.Descripcion = TxtNombre.Text;
                    negocio.modificar(modificar);
                    LblMensaje.Text = "Genero modificado exitosamente";
                    LblMensaje.Visible = true;
                    Response.Redirect("Generos.aspx", false);

                }
                else
                {
                    if (ValidarVacios() == false)
                    {
                        nuevo.Descripcion = TxtNombre.Text;

                        negocio.agregar(nuevo);
                        LblMensaje.Text = "Genero agregado exitosamente";
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
                Response.Redirect("Generos.aspx", false);
        }
    }
}