using System;
using System.Collections;
using System.Data.SqlClient;

namespace ControlExpedientesMedicos.Models
{
    public class ModeloClinica
    {
        private SqlConnection conn;
        private Cadena_Conexion cadena = new Cadena_Conexion();
        private String cadena_conexion = "";
        private String mensaje = "";

        public ModeloClinica()
        {
            cadena_conexion = cadena.Obtener_Cadena();
        }

        public ArrayList Obtener_Clinicas(int opcion)
        {
            ArrayList listaClinicas = new ArrayList();
            int cli_codigo = 0;
            String cli_nombre = "";

            try
            {
                conn = new SqlConnection(cadena_conexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.sp_obtener_clinicas", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("opcion", 1);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cli_codigo = reader.GetInt32(0);
                        cli_nombre = reader.GetString(1);
                        Clinica clinica = new Clinica(cli_codigo, cli_nombre);
                        listaClinicas.Add(clinica);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Modelo clinica: " + ex.StackTrace);
            }

            return listaClinicas;
        }
    }
}
