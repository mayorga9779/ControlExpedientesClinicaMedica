using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class ModeloConsulta
    {
        private SqlConnection conn;
        private Cadena_Conexion cadena = new Cadena_Conexion();
        private String cadena_conexion = "";
        private String mensaje = "";

        public ModeloConsulta()
        {
            cadena_conexion = cadena.Obtener_Cadena();
        }

        public String Crear_Consulta(String motivo, String sintoma, String diagnostico, int codigo_paciente)
        {
            try
            {
                conn = new SqlConnection(cadena_conexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.sp_agregar_consulta", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("opcion", 1);
                cmd.Parameters.AddWithValue("motivo", motivo);
                cmd.Parameters.AddWithValue("sintoma", sintoma);
                cmd.Parameters.AddWithValue("diagnostico", diagnostico);
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

        public ArrayList ObtenerDetalleConsultas(int codigo_paciente)
        {
            ArrayList listaConsultas = new ArrayList();
            int opcion = 1;
            String motivo;
            String sintoma;
            String diagnostico;
            DateTime fecha_consulta;

            try
            {
                conn = new SqlConnection(cadena_conexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.sp_obtener_detalle_consultas", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("opcion", opcion);
                cmd.Parameters.AddWithValue("codigo_paciente", codigo_paciente);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        motivo = reader.GetString(0);
                        sintoma = reader.GetString(1);
                        diagnostico = reader.GetString(2);
                        fecha_consulta = reader.GetDateTime(3);

                        Consulta consulta = new Consulta(motivo, sintoma, diagnostico, codigo_paciente, fecha_consulta);
                        listaConsultas.Add(consulta);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Modelo consulta: " + ex.StackTrace);
            }

            return listaConsultas;
        }
    }
}
