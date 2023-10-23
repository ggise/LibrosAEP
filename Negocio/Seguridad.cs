using Dominio;

namespace Negocio
{
    public class Seguridad
    {

        public static bool sesionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null && usuario.ID != 0)
                return true;
            else return false;
        }

        public static bool esAdmin(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            return usuario != null ? usuario.Admin : false;

        }
    }
}


