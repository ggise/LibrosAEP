using Dominio;
using System;
using System.Collections.Generic;


namespace Negocio
{
    public class AutorNegocio
    {

        public List<Autor> listar(bool porOrdenAlfabetico = false)

        {
            List<Autor> lista = new List<Autor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {



                if (porOrdenAlfabetico)
                    datos.setearConsulta("Select Id,Nombre,Activo from Autor ORDER BY Nombre ASC");
                else
                    datos.setearConsulta("Select Id,Nombre,Activo from Autor");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Autor aux = new Autor();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
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

        public List<Autor> listar(string buscar)
        {
            List<Autor> lista = new List<Autor>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select aut.Id,aut.Nombre,aut.Activo from AUTOR aut inner join LIBROS l on l.IdAutor=aut.Id where l.Activo=1 and aut.Activo=1  and Nombre like '%" + buscar + "%'");
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Autor aux = new Autor();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
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

        public int agregar(Autor nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "INSERT INTO AUTOR (Nombre) VALUES (@Nombre); SELECT SCOPE_IDENTITY();";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", nuevo.Nombre);

                datos.comando.Connection = datos.conexion; // Asignar la conexión al objeto SqlCommand

                datos.conexion.Open(); // Abre la conexión a la base de datos

                int idAutor = Convert.ToInt32(datos.comando.ExecuteScalar());

                // Asignar el ID generado al objeto Autor
                nuevo.Id = idAutor;

                return idAutor;
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


        public Autor ObtenerAutorPorId(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id,Nombre from AUTOR where Id=" + Id);



                datos.ejecutarLectura(); // Agregar esta línea para abrir la conexión y ejecutar la consulta

                if (datos.Lector.Read())
                {
                    Autor Autor = new Autor();
                    Autor.Id = Id;
                    Autor.Nombre = datos.Lector.GetString(1);

                    return Autor;
                }
                else
                {
                    return null;
                }
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
                datos.setearConsulta("UPDATE AUTOR set Activo = 0 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja al Autor.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void modificar(Autor Autor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_modificarAutor");
                datos.setearParametro("@Id", Autor.Id);
                datos.setearParametro("@Nombre", Autor.Nombre);

                datos.ejectutarAccion();


            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja al Autor.", ex);
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
                datos.setearConsulta("UPDATE AUTOR set Activo = 1 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta al Autor.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

    }
}

