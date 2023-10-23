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
    public partial class MiPerfil : System.Web.UI.Page
    {
        public Usuario perfil { get; set; }

        public UsuarioNegocio negocio { get; set; } 

        public int cantLibros { get; set; } 

        public int cantLeidos { get; set; } 
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                negocio = new UsuarioNegocio();
                cantLeidos = 0;
                cantLibros = 0;
                if (Seguridad.sesionActiva(Session["usuario"]))
                {
                    perfil = (Usuario)Session["usuario"];

                    cantLibros = negocio.CantidadLibrosPorUsuario(perfil.ID);
                    cantLeidos = negocio.CantidadLeidosPorUsuario(perfil.ID);



                }

            }
        }

        protected void btnDatos_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("DatosUsuario.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }

        protected void btnSumarLibros_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("SumarLibros.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }

        }
        protected void btnLibros_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("MiLectura.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);
            }
        }


    }
}