using EASendMail;
using System;
using System.Configuration; // Agrega esta referencia
using System.Net.Mail;
using SmtpClient = EASendMail.SmtpClient;

namespace Negocio
{
    public class EmailService
    {
        public string EnviarCorreo(string correoDestino, string asunto, string mensajeCorreo)
        {
            string mensaje = "Error al enviar correo.";

            try
            {
                SmtpMail objetoCorreo = new SmtpMail("TryIt");

                objetoCorreo.From = "librosaep@outlook.com";
                objetoCorreo.To = correoDestino;
                objetoCorreo.Subject = asunto;
                objetoCorreo.TextBody = mensajeCorreo;

                SmtpServer objetoServidor = new SmtpServer("smtp.office365.com");

                objetoServidor.User = "librosaep@outlook.com";

                // Obtén la contraseña desde la configuración
                objetoServidor.Password = ConfigurationManager.AppSettings["CorreoPassword"];

                objetoServidor.Port = 587;
                objetoServidor.ConnectType = SmtpConnectType.ConnectSSLAuto;

                SmtpClient objetoCliente = new SmtpClient();
                objetoCliente.SendMail(objetoServidor, objetoCorreo);
                mensaje = "Correo Enviado Correctamente.";
            }
            catch (Exception ex)
            {
                mensaje = "Error al enviar correo." + ex.Message;
            }
            return mensaje;
        }
    }
}
