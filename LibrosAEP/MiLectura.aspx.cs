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
    public partial class MiLectura : System.Web.UI.Page
    {
        public List<Libro> listaLibro { get; set; }

        public List<Leyendo> listaLeyendo { get; set; }

        public List<Leyendo> listaLeidos { get; set; }

        public Libro LibroSeleccionado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Request.QueryString["id"] != null)
                {
                    Int32 id = Int32.Parse(Request.QueryString["Id"]);
                    LibroNegocio negocio = new LibroNegocio();
                    LibroSeleccionado = negocio.ObtenerLibro(id);
                }
                if (Seguridad.sesionActiva(Session["usuario"]))
                {

                    Usuario logueado = (Usuario)Session["usuario"];
                    int IdUsuario = logueado.ID;

                    LeyendoNegocio negocioLeyendo = new LeyendoNegocio();
                    bool devolvio = false;
                    listaLeyendo = negocioLeyendo.listarxUsuario(IdUsuario, devolvio);
                    Session.Add("Leyendo", listaLeyendo);


                    repRepetidor.DataSource = listaLeyendo;
                    repRepetidor.DataBind();

                    devolvio = true;
                    listaLeidos = negocioLeyendo.listarxUsuario(IdUsuario, devolvio);
                }


            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }


        }



        protected void btnSolicitar_Click(object sender, EventArgs e)
        {


            try
            {
                if (LibroSeleccionado != null && (Session["usuario"]) != null)
                {

                    // string Id = ((Button)sender).CommandArgument;
                    LibroNegocio negocio = new LibroNegocio();
                    LeyendoNegocio negocioLeyendo = new LeyendoNegocio();
                    Usuario logueado = (Usuario)Session["usuario"];
                    int IdUsuario = logueado.ID;
                    EmailService emailService = new EmailService();


                    emailService.EnviarCorreo(LibroSeleccionado.Usuario.Email, "Alguien quiere tu libro", "Hola! " + LibroSeleccionado.Usuario.Nombre + " " + logueado.Nombre + " quiere pedirte prestado tu libro " + LibroSeleccionado.Titulo);



                    negocio.BajaLogica(LibroSeleccionado.Id);
                    negocioLeyendo.solicitadoParaLeer(IdUsuario, LibroSeleccionado.Id);
                    Response.Redirect("MiLectura.aspx");

                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de alta la Libros: " + ex.Message;
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;

            }
            repRepetidor.DataBind();

        }

        protected void btnDevolver_Click(object sender, EventArgs e)
        {

            try
            {
                LeyendoNegocio negocio = new LeyendoNegocio();
                Leyendo leyendo = new Leyendo();
                LibroNegocio libroNegocio = new LibroNegocio();
                Libro libro = new Libro();


                string Id = ((Button)sender).CommandArgument;

                leyendo = negocio.ObtenerLeyendo(int.Parse(Id));
                LibroNegocio negocioLibro = new LibroNegocio();
                int IdLibro = leyendo.Libro.Id;
                libro = libroNegocio.ObtenerLibro(IdLibro);
                negocio.Devolvio(leyendo);
                negocioLibro.AltaLogica(IdLibro);

                ///////
                Usuario logueado = (Usuario)Session["usuario"];
                EmailService emailService = new EmailService();


                emailService.EnviarCorreo(libro.Usuario.Email, "Ya terminaron de leer tu libro!", "Hola! " + leyendo.Usuario.Nombre + " " + logueado.Nombre + " ya termino de leer tu libro " + leyendo.Libro.Titulo + " y quiere devolvertelo. ");



            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al dar de alta el Libro: " + ex.ToString();
                lblMensaje.CssClass = "error-message";
                lblMensaje.Visible = true;


            }
            finally
            {
                // Actualizar la vista antes de redirigir
                repRepetidor.DataBind();
                // Redireccionar fuera del bloque try-catch
                Response.Redirect("MiLectura.aspx");
            }
        }
    }
}
