using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class Conexion
    {
        private SqlConnection conexionBD;

        public Conexion()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        public void ConexionSql(string cadena)
        {
            conexionBD = new SqlConnection();
            conexionBD.ConnectionString = cadena;
        }

        public string CadenaConexionBD()
        {
            string cadena_conexion = "";
            cadena_conexion += " Data Source=DELL_MAYORGA\\SQLEXPRESS; Initial Catalog=CONTROL_EXPEDIENTES_MEDICOS;Persist Security Info=True;User ID=sa; Password=@ndroid9779";

            return cadena_conexion;
        }

        public DataTable Tabla(String consulta)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = conexionBD;
                cmd.Connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                cmd.CommandTimeout = 120;
                da.SelectCommand = cmd;
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                dt = null;
            }
            finally
            {
                dt.Dispose();
                cmd.Connection.Close();
            }

            return dt;
        }
    }
}
