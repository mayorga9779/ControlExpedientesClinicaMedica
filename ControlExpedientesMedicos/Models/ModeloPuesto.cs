using System;
using System.Collections;
using System.Data;
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
            catch (Exception ex)
            {
                Console.WriteLine("Modelo puesto: " + ex.StackTrace);
            }
            return listaPuestos;
        }

        public String Crear_Puesto(int opcion, string nombre_puesto, string descripcion)
        {
            try
            {
                conn = new SqlConnection(cadena_conexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.sp_agregar_puesto", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("opcion", opcion);
                cmd.Parameters.AddWithValue("pue_nombre", nombre_puesto);
                cmd.Parameters.AddWithValue("pue_descripcion", descripcion);

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
                Console.WriteLine("Modelo puesto: " + ex.StackTrace);
            }

            return mensaje;
        }
    }
}
