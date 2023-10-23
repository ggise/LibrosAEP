using System;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        public SqlConnection conexion;
        public SqlCommand comando;
        public SqlDataReader lector;


        public AccesoDatos()
        {
            conexion = new SqlConnection("workstation id=LibrosDB.mssql.somee.com;packet size=4096;user id=GIGISUERO_SQLLogin_1;pwd=975p1oo25p;data source=LibrosDB.mssql.somee.com;persist security info=False;initial catalog=LibrosDB");
            //conexion = new SqlConnection("data source=.\\SQLEXPRESS; initial catalog=LibrosDB; integrated security=true");
            comando = new SqlCommand();
        }



        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void setearProcedimiento(string nombreProcedimiento)
        {
            comando = new SqlCommand();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreProcedimiento;
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            conexion.Open();
            lector = comando.ExecuteReader();
        }
        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (lector != null && !lector.IsClosed)
            {
                lector.Close();
            }

            if (conexion != null && conexion.State != ConnectionState.Closed)
            {
                conexion.Close();
            }
        }


        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public void ejectutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public int ejectutarAccionScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }



    }
}
