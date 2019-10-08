using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class Cadena_Conexion
    {
        public Cadena_Conexion()
        {

        }

        public String Obtener_Cadena()
        {
            String cadena_conexion;
            var configuracion = GetConfiguracion();
            cadena_conexion = configuracion.GetSection("ConnectionStrings").GetSection("cadena_conexion").Value;

            return cadena_conexion;
        }

        public IConfigurationRoot GetConfiguracion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
