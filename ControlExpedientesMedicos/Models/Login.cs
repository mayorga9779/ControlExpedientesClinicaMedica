using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class Login
    {
        private Conexion conn = new Conexion();
        private DataTable dt = null;

        public Login()
        {
            conn.ConexionSql(conn.CadenaConexionBD());
        }

        public String Validar_Usuario(String usuario, String password)
        {
            String mensaje = "";

            if(usuario != "" && password != "")
            {

            }

            return mensaje;
        }
    }
}
