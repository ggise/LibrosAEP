using Dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class GeneroNegocio
    {

        public List<Genero> listar(bool Activo = true)
        {
            List<Genero> lista = new List<Genero>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (Activo)
                {
                    datos.setearConsulta("Select Id,Descripcion,activo from GENEROS where activo=1 ");

                }
                else
                {
                    datos.setearConsulta("Select Id,Descripcion,activo from GENEROS");
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Genero aux = new Genero();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
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
        public List<Genero> listarxorden(bool orden = false)
        {
            List<Genero> lista = new List<Genero>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (orden)
                {
                    datos.setearConsulta("Select Id,Descripcion,activo from GENEROS ORDER BY Descripcion ASC");

                }
                else
                {
                    datos.setearConsulta("Select Id,Descripcion,activo from GENEROS");
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Genero aux = new Genero();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
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
        public Genero ObtenerPorId(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id,Descripcion from GENEROS where Id=" + Id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Genero genero = new Genero();
                    genero.Id = Id;
                    genero.Descripcion = datos.Lector.GetString(1);

                    return genero;
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

        public int agregar(Genero nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "INSERT INTO Generos (Descripcion) VALUES (@Descripcion); SELECT SCOPE_IDENTITY();";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.comando.Connection = datos.conexion; // Asignar la conexión al objeto SqlCommand

                datos.conexion.Open(); // Abre la conexión a la base de datos

                int idgenero = Convert.ToInt32(datos.comando.ExecuteScalar());

                // Asignar el ID generado al objeto Autor
                nuevo.Id = idgenero;

                return idgenero;
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
                datos.setearConsulta("UPDATE GENEROS set Activo = 0 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja el genero.", ex);
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
                datos.setearConsulta("UPDATE GENEROS set Activo = 1 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el genero.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void modificar(Genero genero)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_modificarGenero");
                datos.setearParametro("@Id", genero.Id);
                datos.setearParametro("@Descripcion", genero.Descripcion);

                datos.ejectutarAccion();


            }

            catch (Exception ex)
            {
                throw new Exception("Error al modificar el genero.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }


        }
    }
}
