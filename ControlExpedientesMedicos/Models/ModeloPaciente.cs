using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class ModeloPaciente
    {
        private SqlConnection conn;
        private Cadena_Conexion cadena = new Cadena_Conexion();
        private String cadena_conexion = "";
        private String mensaje = "";

        public ModeloPaciente()
        {
            cadena_conexion = cadena.Obtener_Cadena();
        }

        public String Crear_Paciente(int opcion, String nombres, String apellidos, String direccion, String telefono, String fecha_nacimiento, String seguro_social, String genero, String email)
        {
            try
            {
                conn = new SqlConnection(cadena_conexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.sp_agregar_paciente", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("opcion", 1);
                cmd.Parameters.AddWithValue("nombres", nombres);
                cmd.Parameters.AddWithValue("apellidos", apellidos);
                cmd.Parameters.AddWithValue("direccion", direccion);
                cmd.Parameters.AddWithValue("telefono", telefono);
                cmd.Parameters.AddWithValue("fecha_nacimiento", fecha_nacimiento);
                cmd.Parameters.AddWithValue("seguro_social", seguro_social);
                cmd.Parameters.AddWithValue("genero", genero);
                cmd.Parameters.AddWithValue("email", email);

                SqlParameter pMensaje = new SqlParameter("mensaje", SqlDbType.VarChar, 8);
                pMensaje.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pMensaje);

                cmd.ExecuteNonQuery();

                mensaje = (String)pMensaje.Value;
                conn.Close();
            }
            catch (Exception ex)
            {
                mensaje = "EXCEPTION";
            }

            return mensaje;
        }
    }
}