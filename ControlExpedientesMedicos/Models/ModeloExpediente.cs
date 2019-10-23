using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace ControlExpedientesMedicos.Models
{
    public class ModeloExpediente
    {
        private SqlConnection conn;
        private Cadena_Conexion cadena = new Cadena_Conexion();
        private String cadena_conexion = "";
        private String mensaje = "";

        public ModeloExpediente()
        {
            cadena_conexion = cadena.Obtener_Cadena();
        }

        public String Crear_Expediente(int opcion, String descripcion, String codigo_paciente)
        {
            try
            {
                conn = new SqlConnection(cadena_conexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.sp_agregar_expediente", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("opcion", 1);
                cmd.Parameters.AddWithValue("descripcion", descripcion);
                cmd.Parameters.AddWithValue("codigo_paciente", codigo_paciente);

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

        public Expediente Obtener_Expediente(int codigo_paciente)
        {
            Expediente expediente = null;
            conn = new SqlConnection(cadena_conexion);
            conn.Open();
            SqlCommand cmd = new SqlCommand("dbo.sp_obtener_datos_personales_expediente", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("opcion", 1);
            cmd.Parameters.AddWithValue("codigo_paciente", codigo_paciente);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int codigo_expediente = reader.GetInt32(0);
                    String descripcion = reader.GetString(1);
                    String nombres = reader.GetString(2);
                    String apellidos = reader.GetString(3);
                    String direccion = reader.GetString(4);
                    String telefono = reader.GetString(5);
                    DateTime fecha_nacimiento = reader.GetDateTime(6);
                    String seguro_social = reader.GetString(7);
                    String genero = reader.GetString(8);
                    String email = reader.GetString(9);

                    if (genero.Equals("F"))
                    {
                        genero = "FEMENINO";
                    }
                    if (genero.Equals("M"))
                    {
                        genero = "MASCULINO";
                    }

                    expediente = new Expediente(codigo_expediente, descripcion, nombres, apellidos, direccion, telefono, fecha_nacimiento, seguro_social, genero, email);
                }
            }

            return expediente;
        }
    }
}
