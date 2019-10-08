using System;
using System.Collections;
using System.Data.SqlClient;

namespace ControlExpedientesMedicos.Models
{
    public class ModeloPuesto
    {
        private SqlConnection conn;
        private Cadena_Conexion cadena = new Cadena_Conexion();
        private String cadena_conexion = "";
        private String mensaje = "";

        public ModeloPuesto()
        {
            cadena_conexion = cadena.Obtener_Cadena();
        }

        public ArrayList Obtener_Puestos(int opcion)
        {
            ArrayList listaPuestos = new ArrayList();
            int pue_codigo = 0;
            String pue_nombre = "";

            try
            {
                conn = new SqlConnection(cadena_conexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.sp_obtener_puestos", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("opcion", opcion);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pue_codigo = reader.GetInt32(0);
                        pue_nombre = reader.GetString(1);
                        Puesto puesto = new Puesto(pue_codigo, pue_nombre);
                        listaPuestos.Add(puesto);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Modelo puesto: " + ex.StackTrace);
            }
            return listaPuestos;
        }
    }
}
