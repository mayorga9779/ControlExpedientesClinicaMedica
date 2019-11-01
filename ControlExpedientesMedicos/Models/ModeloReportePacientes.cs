using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class ModeloReportePacientes
    {
        private SqlConnection conn;
        private Cadena_Conexion cadena = new Cadena_Conexion();
        private String cadena_conexion = "";
        private String mensaje = "";

        public ModeloReportePacientes()
        {
            cadena_conexion = cadena.Obtener_Cadena();
        }

        public ArrayList ObtenerPacientes(int opcion, String fecha_inicio, String fecha_fin, String genero)
        {
             ArrayList listaPacientes = new ArrayList();

            try
            {
                conn = new SqlConnection(cadena_conexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.sp_reporte_pacientes", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("opcion", opcion);
                cmd.Parameters.AddWithValue("fecha_ingreso_inicio", fecha_inicio);
                cmd.Parameters.AddWithValue("fecha_ingreso_fin", fecha_fin);
                cmd.Parameters.AddWithValue("genero", genero);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int codigo_expediente = reader.GetInt32(0);
                        int codigo_paciente = reader.GetInt32(1);
                        String paciente = reader.GetString(2);
                        String direccion = reader.GetString(3);
                        String telefono = reader.GetString(4);
                        DateTime fecha_nacimiento = reader.GetDateTime(5);
                        String genero2 = reader.GetString(6);
                        DateTime fecha_alta = reader.GetDateTime(7);

                        ReportePaciente reporte = new ReportePaciente(codigo_expediente, codigo_paciente, paciente, fecha_alta.ToString(), genero2, fecha_nacimiento.ToString(), direccion, telefono);
                        listaPacientes.Add(reporte);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Modelo puesto: " + ex.StackTrace);
            }

            return listaPacientes;
        }
    }
}
