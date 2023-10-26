using Dominio;
using System;
using System.Collections.Generic;
using System.Data;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public int insertarNuevo(Usuario nuevo)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("InsertarNuevo");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Pass", nuevo.Pass);

                return datos.ejectutarAccionScalar();


            }
            catch (Exception ex)
            {
                throw ex;

            }

            finally
            {
                datos.cerrarConexion();
            }


        }



        public Usuario Login(Usuario usuario)
        {

            Usuario aux = new Usuario();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select ID, Nombre, Apellido, Email, Pass,Administrador,IdLeyendo,Activo from USUARIO  where email=@email and pass=@pass");

                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {

                    aux.ID = (Int32)datos.Lector["Id"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Nombre"))))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Apellido"))))
                        aux.Apellido = (string)datos.Lector["Apellido"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Email"))))
                        aux.Email = (string)datos.Lector["Email"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Pass"))))
                        aux.Pass = (string)datos.Lector["Pass"];

                    aux.Leyendo = new Leyendo();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("IdLeyendo"))))
                        aux.Leyendo.Id = (int)datos.Lector["IdLeyendo"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Administrador"))))
                        aux.Admin = (bool)datos.Lector["Administrador"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Activo"))))
                        aux.Activo = (bool)datos.Lector["Activo"];

                    ///



                    // mensaje para verificar los valores
                    Console.WriteLine("Inicio de sesión exitoso. ID: " + aux.ID + ", Admin: " + aux.Admin);

                }
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void modificarContraseña(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("update USUARIO set Nombre=@nombre, Apellido=@apellido, Pass=@pass where Id=@id");
                datos.setearParametro("@id", usuario.ID);
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@pass", usuario.Pass);


                datos.ejectutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("update USUARIO set Nombre=@nombre, Apellido=@apellido, Email=@email where Id=@id");
                datos.setearParametro("@id", usuario.ID);
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@email", usuario.Email);


                datos.ejectutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



        //listarUsuario
        public List<Usuario> listar(bool orden=false)
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (orden)
                 datos.setearConsulta("select Id,Nombre,Apellido,Email,IdLeyendo,Administrador,Activo from USUARIO where Activo=1 ORDER BY Nombre ASC");
                else
                    datos.setearConsulta("select Id,Nombre,Apellido,Email,IdLeyendo,Administrador,Activo from USUARIO");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Nombre = datos.Lector["Nombre"] is DBNull ? null : (string)datos.Lector["Nombre"];
                    aux.Apellido = datos.Lector["Apellido"] is DBNull ? null : (string)datos.Lector["Apellido"];
                    aux.Email = datos.Lector["Email"] is DBNull ? null : (string)datos.Lector["Email"];

                    aux.Leyendo = new Leyendo();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("IdLeyendo"))))
                        aux.Leyendo.Id = (int)datos.Lector["IdLeyendo"];


                    aux.Admin = datos.Lector["Administrador"] is DBNull ? false : (bool)datos.Lector["Administrador"];
                    aux.Activo = datos.Lector["Activo"] is DBNull ? false : (bool)datos.Lector["Activo"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public List<Usuario> listar(string buscar)
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id,Nombre,Apellido,Email,IdLeyendo,Administrador,Activo from USUARIO where Apellido like '%" + buscar + "%' or Nombre like '%" + buscar + "%'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Nombre = datos.Lector["Nombre"] is DBNull ? null : (string)datos.Lector["Nombre"];
                    aux.Apellido = datos.Lector["Apellido"] is DBNull ? null : (string)datos.Lector["Apellido"];
                    aux.Email = datos.Lector["Email"] is DBNull ? null : (string)datos.Lector["Email"];
                    aux.Leyendo = new Leyendo();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("IdLeyendo"))))
                        aux.Leyendo.Id = (int)datos.Lector["IdLeyendo"];

                    aux.Admin = datos.Lector["Administrador"] is DBNull ? false : (bool)datos.Lector["Administrador"];
                    aux.Activo = datos.Lector["Activo"] is DBNull ? false : (bool)datos.Lector["Activo"];


                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int ExisteUsuarioPorEmail(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM USUARIO WHERE Email = @Email");
                datos.setearParametro("@Email", usuario.Email);

                int count = (int)datos.ejectutarAccionScalar();

                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void BajaLogica(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE USUARIO set Activo = 0 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar desactivar al usuario.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void AltaLogica(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE USUARIO set Activo = 1 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar activar al usuario.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public Usuario BuscarAdmin()
        {

            Usuario aux = new Usuario();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select ID, Nombre, Apellido, Email, Pass,IdLeyendo,Administrador,Activo from USUARIO  where Administrador=1");


                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {

                    aux.ID = (Int32)datos.Lector["Id"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Nombre"))))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Apellido"))))
                        aux.Apellido = (string)datos.Lector["Apellido"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Email"))))
                        aux.Email = (string)datos.Lector["Email"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Pass"))))
                        aux.Pass = (string)datos.Lector["Pass"];
                    aux.Leyendo = new Leyendo();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("IdLeyendo"))))
                        aux.Leyendo.Id = (int)datos.Lector["IdLeyendo"];

                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Administrador"))))
                        aux.Admin = (bool)datos.Lector["Administrador"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Activo"))))
                        aux.Activo = (bool)datos.Lector["Activo"];

                    ///



                    // mensaje para verificar los valores
                    Console.WriteLine("Inicio de sesión exitoso. ID: " + aux.ID + ", Admin: " + aux.Admin);

                }
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int CantidadLibrosPorUsuario(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = new Usuario();
            int cant = 0;
            try
            {
                datos.setearConsulta("select count (*) from LIBROS where IdUsuarioDuena =" + Id);
                datos.setearParametro("@id", Id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    cant = Convert.ToInt32(datos.Lector[0]);
                }
                return cant;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int CantidadLeidosPorUsuario(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = new Usuario();
            int cant = 0;
            try
            {
                datos.setearConsulta("SELECT COUNT(DISTINCT IdLibro) FROM LEYENDO WHERE IdUsuario =" + Id);
                datos.setearParametro("@id", Id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    cant = Convert.ToInt32(datos.Lector[0]);
                }
                return cant;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = new Usuario();

            try
            {
                datos.setearConsulta("SELECT Id, Nombre, Apellido, Email FROM USUARIO WHERE Id =+" + idUsuario);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario = new Usuario();
                    usuario.ID = Convert.ToInt32(datos.Lector["Id"]);
                    usuario.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    usuario.Apellido = Convert.ToString(datos.Lector["Apellido"]);
                    usuario.Email = Convert.ToString(datos.Lector["Email"]);
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Usuario ObtenerUsuarioPorMail(string correo)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = new Usuario();

            try
            {
                datos.setearConsulta("SELECT Id, Nombre, Apellido, Email FROM USUARIO WHERE Email = '" + correo + "'");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario = new Usuario();
                    usuario.ID = Convert.ToInt32(datos.Lector["Id"]);
                    usuario.Nombre = Convert.ToString(datos.Lector["Nombre"]);
                    usuario.Apellido = Convert.ToString(datos.Lector["Apellido"]);
                    usuario.Email = Convert.ToString(datos.Lector["Email"]);

                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
