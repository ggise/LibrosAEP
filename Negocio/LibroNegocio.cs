using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Negocio
{
    public class LibroNegocio
    {

        public List<Libro> listar(bool Activo = true)
        {
            List<Libro> lista = new List<Libro>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (Activo)
                {
                    datos.setearConsulta("select L.Id, L.Titulo, Aut.Id, Aut.Nombre as Autor, L.ImgTapa,L.Sinopsis,L.Activo, G.Id, G.Descripcion as Genero, u.Id, u.Nombre as Dueña from LIBROS L, GENEROS G, AUTOR Aut, USUARIO u where  G.Id=L.IdGenero and  Aut.Id=L.IdAutor and u.Id=L.IdUsuarioDuena  and L.Activo=1 ");

                }
                else
                {
                    datos.setearConsulta("select L.Id, L.Titulo, Aut.Id, Aut.Nombre as Autor, L.ImgTapa,L.Sinopsis, L.Activo, G.Id, G.Descripcion as Genero, u.Id, u.Nombre as Dueña from LIBROS L, GENEROS G, AUTOR Aut, USUARIO u where  G.Id = L.IdGenero and  Aut.Id = L.IdAutor and u.Id=L.IdUsuarioDuena order by l.titulo");

                }

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Libro aux = new Libro();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];

                    aux.Autor = new Autor();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Autor"))))
                        aux.Autor.Nombre = (string)datos.Lector["Autor"];
                    if (!(datos.lector.IsDBNull(datos.lector.GetOrdinal("ImgTapa"))))
                        aux.ImgTapa = (string)datos.Lector["ImgTapa"];

                    aux.Genero = new Genero();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Genero"))))
                        aux.Genero.Descripcion = (string)datos.Lector["Genero"];
                    aux.Usuario = new Usuario();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Dueña"))))
                        aux.Usuario.Nombre = (string)datos.Lector["Dueña"];
                    if (!(datos.lector.IsDBNull(datos.lector.GetOrdinal("Sinopsis"))))
                        aux.Sinopsis = (string)datos.Lector["Sinopsis"];


                    aux.Activo = (bool)datos.Lector["Activo"];


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
        public List<Libro> listarInicio()
        {
            List<Libro> lista = new List<Libro>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                   datos.setearConsulta("select L.Id, L.Titulo, Aut.Id, Aut.Nombre as Autor, L.ImgTapa,L.Sinopsis,L.Activo, G.Id, G.Descripcion as Genero, u.Id, u.Nombre as Dueña from LIBROS L, GENEROS G, AUTOR Aut, USUARIO u where  G.Id=L.IdGenero and  Aut.Id=L.IdAutor and u.Id=L.IdUsuarioDuena order by  L.Titulo asc ");

                
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Libro aux = new Libro();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];

                    aux.Autor = new Autor();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Autor"))))
                        aux.Autor.Nombre = (string)datos.Lector["Autor"];
                    if (!(datos.lector.IsDBNull(datos.lector.GetOrdinal("ImgTapa"))))
                        aux.ImgTapa = (string)datos.Lector["ImgTapa"];

                    aux.Genero = new Genero();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Genero"))))
                        aux.Genero.Descripcion = (string)datos.Lector["Genero"];
                    aux.Usuario = new Usuario();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Dueña"))))
                        aux.Usuario.Nombre = (string)datos.Lector["Dueña"];
                    if (!(datos.lector.IsDBNull(datos.lector.GetOrdinal("Sinopsis"))))
                        aux.Sinopsis = (string)datos.Lector["Sinopsis"];


                    aux.Activo = (bool)datos.Lector["Activo"];


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


        public List<Libro> listarxGenero(int idgenero)
        {
            List<Libro> lista = new List<Libro>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(" select l.Id, l.Titulo,Aut.Nombre as Autor, l.ImgTapa,l.Sinopsis,l.Activo, G.Descripcion as Genero, u.Nombre as Dueña from LIBROS l, GENEROS G, AUTOR Aut,USUARIO u where  G.Id=l.IdGenero and  Aut.Id=l.IdAutor and u.Id=l.IdUsuarioDuena and u.Activo=1 and l.IdGenero=" + idgenero);

                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {

                    Libro aux = new Libro();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];

                    aux.Autor = new Autor();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Autor"))))
                        aux.Autor.Nombre = (string)datos.Lector["Autor"];
                    if (!(datos.lector.IsDBNull(datos.lector.GetOrdinal("ImgTapa"))))
                        aux.ImgTapa = (string)datos.Lector["ImgTapa"];
                    if (!(datos.lector.IsDBNull(datos.lector.GetOrdinal("Sinopsis"))))
                        aux.Sinopsis = (string)datos.Lector["Sinopsis"];
                    aux.Genero = new Genero();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Genero"))))
                        aux.Genero.Descripcion = (string)datos.Lector["Genero"];
                    aux.Usuario = new Usuario();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Dueña"))))
                        aux.Usuario.Nombre = (string)datos.Lector["Dueña"];




                    aux.Activo = (bool)datos.Lector["Activo"];


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

        public List<Libro> listaFiltradaXTitulo(string buscar)
        {
            List<Libro> lista = new List<Libro>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select l.Id, l.Titulo, Aut.Id, Aut.Nombre as Autor, l.ImgTapa,l.Sinopsis, G.Id, G.Descripcion as Genero, u.Id, u.Nombre as Dueña, l.Activo from LIBROS l, GENEROS G, AUTOR Aut, USUARIO u where  G.Id=A.IdGenero and  Aut.Id=l.IdAutor and u.Id=l.IdUsuarioDuena and l.Activo=1 and Titulo LIKE '%" + @buscar + "%'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Libro aux = new Libro();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];

                    aux.Autor = new Autor();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Autor"))))
                        aux.Autor.Nombre = (string)datos.Lector["Autor"];
                    if (!(datos.lector.IsDBNull(datos.lector.GetOrdinal("ImgTapa"))))
                        aux.ImgTapa = (string)datos.Lector["ImgTapa"];
                    aux.Genero = new Genero();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Genero"))))
                        aux.Genero.Descripcion = (string)datos.Lector["Genero"];
                    aux.Usuario = new Usuario();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Dueña"))))
                        aux.Usuario.Nombre = (string)datos.Lector["Dueña"];
                    if (!(datos.lector.IsDBNull(datos.lector.GetOrdinal("Sinopsis"))))
                        aux.Sinopsis = (string)datos.Lector["Sinopsis"];


                    aux.Activo = (bool)datos.Lector["Activo"];


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
        public List<Libro> listarxUsuario(int idusuario)
        {
            List<Libro> lista = new List<Libro>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select l.Id, l.Titulo, Aut.Nombre as Autor, l.ImgTapa, l.Sinopsis,l.Activo, G.Descripcion as Genero, u.Nombre as Dueña from LIBROS l, GENEROS G, Autor Aut, USUARIO u where  G.Id=l.IdGenero and  Aut.Id=l.IdAutor and u.Id=l.IdUsuarioDuena and u.Activo=1 and l.IdUsuarioDuena=" + idusuario);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Libro aux = new Libro();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];

                    aux.Autor = new Autor();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Autor"))))
                        aux.Autor.Nombre = (string)datos.Lector["Autor"];
                    if (!(datos.lector.IsDBNull(datos.lector.GetOrdinal("ImgTapa"))))
                        aux.ImgTapa = (string)datos.Lector["ImgTapa"];
                    aux.Genero = new Genero();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Genero"))))
                        aux.Genero.Descripcion = (string)datos.Lector["Genero"];
                    aux.Usuario = new Usuario();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Dueña"))))
                        aux.Usuario.Nombre = (string)datos.Lector["Dueña"];
                    if (!(datos.lector.IsDBNull(datos.lector.GetOrdinal("Sinopsis"))))
                        aux.Sinopsis = (string)datos.Lector["Sinopsis"];


                    aux.Activo = (bool)datos.Lector["Activo"];


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

        public List<Libro> listaFiltradaXAutor(string buscar)
        {
            List<Libro> lista = new List<Libro>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select l.Id, l.Titulo, Aut.Id, Aut.Nombre as Autor, l.ImgTapa,l.Sinopsis, G.Id, G.Descripcion as Genero, u.Id,u.Nombre as Dueña,l.Activo from LIBROS l, GENEROS G, Autor Aut, USUARIO u where  G.Id=A.IdGenero and  Aut.Id=l.IdAutor and u.Id=l.IdUsuarioDuena and l.Activo=1 and Aut.Nombre like '%" + @buscar + "%'");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Libro aux = new Libro();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];

                    aux.Autor = new Autor();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Autor"))))
                        aux.Autor.Nombre = (string)datos.Lector["Autor"];
                    if (!(datos.lector.IsDBNull(datos.lector.GetOrdinal("ImgTapa"))))
                        aux.ImgTapa = (string)datos.Lector["ImgTapa"];
                    aux.Genero = new Genero();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Genero"))))
                        aux.Genero.Descripcion = (string)datos.Lector["Genero"];
                    aux.Usuario = new Usuario();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Dueña"))))
                        aux.Usuario.Nombre = (string)datos.Lector["Dueña"];
                    if (!(datos.lector.IsDBNull(datos.lector.GetOrdinal("Sinopsis"))))
                        aux.Sinopsis = (string)datos.Lector["Sinopsis"];


                    aux.Activo = (bool)datos.Lector["Activo"];


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

        public void agregar(Libro nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "INSERT INTO LIBROS (Titulo, IdAutor, ImgTapa, IdGenero, Sinopsis, IdUsuarioDuena) " +
                                  "VALUES (@Titulo, @IdAutor, @ImgTapa, @IdGenero,@Sinopsis, @IdUsuarioDuena)";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Titulo", nuevo.Titulo);
                datos.setearParametro("@IdAutor", nuevo.Autor.Id);
                datos.setearParametro("@ImgTapa", nuevo.ImgTapa);

                datos.setearParametro("@IdGenero", nuevo.Genero.Id);
                datos.setearParametro("@Sinopsis", nuevo.Sinopsis);
                datos.setearParametro("@IdUsuarioDuena", nuevo.Usuario.ID);

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

        public void modificarConSP(Libro nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearProcedimiento("sp_modificarLibro");
                datos.setearParametro("@Id", nuevo.Id);
                datos.setearParametro("@Titulo", nuevo.Titulo);
                datos.setearParametro("@IdAutor", nuevo.Autor.Id);
                datos.setearParametro("@ImgTapa", nuevo.ImgTapa);
                datos.setearParametro("@IdGenero", nuevo.Genero.Id);
                datos.setearParametro("@IdUsuarioDuena", nuevo.Usuario.ID);
                datos.setearParametro("@Sinopsis", nuevo.Sinopsis);
                datos.setearParametro("@Activo", nuevo.Activo);

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

        public List<Libro> listaFiltrada(string buscar)
        {
            List<Libro> lista = new List<Libro>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select distinct l.Id, l.Titulo, Aut.Id, Aut.Nombre as Autor, l.ImgTapa,l.Sinopsis, G.Id, G.Descripcion as Genero, u.Id,u.Nombre as Dueña,l.Activo from LIBROS l inner join GENEROS G on G.id=l.IdGenero INNER JOIN Autor Aut ON Aut.Id=l.IdAutor INNER JOIN USUARIO u ON u.Id=l.IdUsuarioDuena WHERE Titulo LIKE '%" + buscar + "%' or Aut.Nombre like '%" + buscar + "%'or u.Nombre like '%" + buscar + "%' and  l.Activo=1 ORDER BY l.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Libro aux = new Libro();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Autor = new Autor();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Autor"))))
                        aux.Autor.Nombre = (string)datos.Lector["Autor"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("ImgTapa"))))
                        aux.ImgTapa = (string)datos.Lector["ImgTapa"];
                    aux.Genero = new Genero();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Genero"))))
                        aux.Genero.Descripcion = (string)datos.Lector["Genero"];
                    aux.Usuario = new Usuario();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Dueña"))))
                        aux.Usuario.Nombre = (string)datos.Lector["Dueña"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Sinopsis"))))
                        aux.Sinopsis = (string)datos.Lector["Sinopsis"];

                    aux.Activo = (bool)datos.Lector["Activo"];


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




        public Libro ObtenerLibro(Int32 id)
        {
            Libro aux = new Libro();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select l.Id, l.Titulo, Aut.Id, Aut.Nombre as Autor, l.ImgTapa,l.Sinopsis,l.Activo, G.Id, G.Descripcion as Genero, u.Id,u.Email,u.Nombre as Dueña from LIBROS l, GENEROS G, AUTOR Aut, USUARIO u where  G.Id=l.IdGenero and  Aut.Id=l.IdAutor and u.Id=l.IdUsuarioDuena and l.Id=" + id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {


                    aux.Id = (Int32)datos.Lector["Id"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("titulo"))))
                        aux.Titulo = (string)datos.Lector["titulo"];

                    aux.Autor = new Autor();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Autor"))))
                        aux.Autor.Nombre = (string)datos.Lector["Autor"];


                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("ImgTapa"))))
                        aux.ImgTapa = (string)datos.Lector["ImgTapa"];

                    aux.Genero = new Genero();
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("genero"))))
                        aux.Genero.Descripcion = (string)datos.Lector["genero"];
                    aux.Usuario = new Usuario();

                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Sinopsis"))))
                        aux.Sinopsis = (string)datos.Lector["Sinopsis"];

                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Dueña"))))
                        aux.Usuario.Nombre = (string)datos.Lector["Dueña"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Email"))))
                        aux.Usuario.Email = (string)datos.Lector["Email"];

                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Activo"))))
                        aux.Activo = (bool)datos.Lector["Activo"];


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

        public void BajaLogica(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE LIBROS set Activo = 0 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el libro.", ex);
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
                datos.setearConsulta("UPDATE LIBROS SET Activo = 1 WHERE Id = @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }
            catch (SqlException ex)
            {
                // Manejar excepciones específicas de SQL
                throw new Exception("Error al dar de alta al Libro. Detalles: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                // Manejar excepciones generales
                throw new Exception("Error al dar de alta al Libro.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }




    }



}
