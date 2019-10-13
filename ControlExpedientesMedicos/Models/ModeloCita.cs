using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class ModeloCita
    {
        private SqlConnection conn;
        private Cadena_Conexion cadena = new Cadena_Conexion();
        private String cadena_conexion = "";
        private String mensaje = "";

        public ModeloCita()
        {
            cadena_conexion = cadena.Obtener_Cadena();
        }

        public String Crear_Cita(int opcion, String fecha_cita, String hora_inicial, String hora_final, String codigo_paciente)
        {
            try
            {
                conn = new SqlConnection(cadena_conexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.sp_agregar_cita", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("opcion", 1);
                cmd.Parameters.AddWithValue("fecha_cita", fecha_cita);
                cmd.Parameters.AddWithValue("hora_inicial", hora_inicial);
                cmd.Parameters.AddWithValue("hora_final", hora_final);
                cmd.Parameters.AddWithValue("codigo_paciente", codigo_paciente);

                SqlParameter pMensaje = new SqlParameter("mensaje", SqlDbType.VarChar, 8);
                pMensaje.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(pMensaje);

                cmd.ExecuteNonQuery();

                mensaje = (String)pMensaje.Value;
                conn.Close();
            }
            catch(Exception ex)
            {
                mensaje = "EXCEPTION";
            }

            return mensaje;
        }
    }
}
