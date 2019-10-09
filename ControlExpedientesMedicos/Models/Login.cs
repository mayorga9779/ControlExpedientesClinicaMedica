using System;
using System.Data;
using System.Data.SqlClient;

namespace ControlExpedientesMedicos.Models
{
    public class Login
    {
        private SqlConnection conn;
        private Cadena_Conexion cadena = new Cadena_Conexion();
        private String cadena_conexion = "";
        private String mensaje = "";
        

        public Login()
        {
            cadena_conexion = cadena.Obtener_Cadena();
        }

        public String Validar_Usuario(String usuario, String password)
        {
            try
            {
                conn = new SqlConnection(cadena_conexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.sp_validar_usuario", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("opcion", 1);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("password", password);

                //SqlParameter pOpcion = new SqlParameter("@opcion", SqlDbType.Int);
                //pOpcion.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(pOpcion);

                //SqlParameter pUsuario = new SqlParameter("@usuario", SqlDbType.VarChar, 25);
                //pUsuario.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(pUsuario);

                //SqlParameter pPassword = new SqlParameter("@password", SqlDbType.VarChar, 25);
                //pPassword.Direction = ParameterDirection.Input;
                //cmd.Parameters.Add(pPassword);

                SqlParameter pMensaje = new SqlParameter("mensaje", SqlDbType.VarChar, 8);
                pMensaje.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pMensaje);

                cmd.ExecuteNonQuery();

                mensaje = (String)pMensaje.Value;
                conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Modelo login: " + ex.StackTrace);
            }

            return mensaje;
        }
    }
}
