using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class ModeloEmpleado
    {
        private SqlConnection conn;
        private Cadena_Conexion cadena = new Cadena_Conexion();
        private String cadena_conexion = "";
        private String mensaje = "";

        public ModeloEmpleado()
        {
            cadena_conexion = cadena.Obtener_Cadena();
        }

        public String Crear_Empleado(int opcion, String nombres, String apellidos, String direccion, String telefono, String fecha_nacimiento, int dpi, String fotografia, int codigo_clinica, int codigo_puesto)
        {
            try
            {
                conn = new SqlConnection(cadena_conexion);
                conn.Open();
                SqlCommand cmd = new SqlCommand("dbo.sp_agregar_empleado", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("opcion", 1);
                cmd.Parameters.AddWithValue("nombres", nombres);
                cmd.Parameters.AddWithValue("apellidos", apellidos);
                cmd.Parameters.AddWithValue("direccion", direccion);
                cmd.Parameters.AddWithValue("telefono", telefono);
                cmd.Parameters.AddWithValue("fecha_nacimiento", fecha_nacimiento);
                cmd.Parameters.AddWithValue("dpi", dpi);
                cmd.Parameters.AddWithValue("fotografia", fotografia);
                cmd.Parameters.AddWithValue("codigo_clinica", codigo_clinica);
                cmd.Parameters.AddWithValue("codigo_puesto", codigo_puesto);

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
