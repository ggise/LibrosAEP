using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class LeyendoNegocio
    {

        public List<Leyendo> listar(bool Devolvio = false)
        {
            List<Leyendo> lista = new List<Leyendo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (Devolvio == false)
                {
                    datos.setearConsulta("select L.Id, U.nombre as Leido, libro.Titulo as Libro from LEYENDO L, LIBROS libro, USUARIO u where  l.IdUsuario=u.Id and  l.IdLibro=libro.Id  and l.Devolvio=0");

                }
                else
                {
                    datos.setearConsulta("select L.Id,U.nombre as Leido, libro.Titulo as Libro from LEYENDO L, LIBROS libro, USUARIO u where  l.IdUsuario=u.Id and  l.IdLibro=libro.Id");

                }

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Leyendo aux = new Leyendo();
                    aux.Id = (int)datos.Lector["Id"];

                    aux.Usuario = new Usuario();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Leido"))))
                        aux.Usuario.Nombre = (string)datos.Lector["Leido"];

                    aux.Libro = new Libro();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Libro"))))
                        aux.Libro.Titulo = (string)datos.Lector["Libro"];


                    aux.Devolvio = (bool)datos.Lector["Devolvio"];


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


        public List<Leyendo> listarxUsuario(int idusuario, bool devolvio)
        {
            List<Leyendo> lista = new List<Leyendo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (devolvio == false)
                {
                    datos.setearConsulta("select L.Id, libro.Titulo from LEYENDO L, LIBROS libro,USUARIO u where l.IdUsuario = u.Id and  l.IdLibro = libro.Id  and l.Devolvio = 0 and U.id=" + idusuario);

                }
                else
                {

                    datos.setearConsulta("select L.Id, libro.Titulo from LEYENDO L, LIBROS libro, USUARIO u where  l.IdUsuario = u.Id and  l.IdLibro = libro.Id  and l.Devolvio = 1 and U.id=" + idusuario);
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Leyendo aux = new Leyendo();
                    aux.Id = (int)datos.Lector["Id"];



                    aux.Libro = new Libro();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Titulo"))))
                        aux.Libro.Titulo = (string)datos.Lector["Titulo"];

                    //  aux.Devolvio = (bool)datos.Lector["Devolvio"];


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


        public void solicitadoParaLeer(int IdUsario, int IdLibro)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "INSERT INTO LEYENDO (IdUsuario, IdLibro) " +
                                  "VALUES (@IdUsuario, @IdLibro)";
                datos.setearConsulta(consulta);
                datos.setearParametro("@IdUsuario", IdUsario);
                datos.setearParametro("@IdLibro", IdLibro);

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

        public void modificarConSP(Leyendo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearProcedimiento("sp_modificarLeyendo");
                datos.setearParametro("@Id", nuevo.Id);
                datos.setearParametro("@IdUsuario", nuevo.Usuario.ID);
                datos.setearParametro("@IdLibro", nuevo.Libro.Id);
                datos.setearParametro("@Devolvio", nuevo.Devolvio);

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

        public Leyendo ObtenerLeyendo(int id)
        {
            Leyendo aux = new Leyendo();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select l.Id, u.Nombre,libro.Id as Libro, libro.Titulo, l.Devolvio from LEYENDO l, LIBROS libro, USUARIO u where   u.Id=l.IdUsuario and libro.Id=l.IdLibro and l.Id=" + id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {


                    aux.Id = (Int32)datos.Lector["Id"];

                    aux.Usuario = new Usuario();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Nombre"))))
                        aux.Usuario.Nombre = (string)datos.Lector["Nombre"];

                    aux.Libro = new Libro();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Libro"))))
                        aux.Libro.Id = (int)datos.Lector["Libro"];

                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Titulo"))))
                        aux.Libro.Titulo = (string)datos.Lector["Titulo"];


                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Devolvio"))))
                        aux.Devolvio = (bool)datos.Lector["Devolvio"];


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



        public void Devolvio(Leyendo leyendo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE LEYENDO set Devolvio = 1 where Id=" + leyendo.Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error devolver el Libro.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

    }



}
