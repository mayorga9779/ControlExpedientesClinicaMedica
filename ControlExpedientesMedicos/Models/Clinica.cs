using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class Clinica
    {
        private int cli_codigo;
        private String cli_nombre;

        public Clinica()
        {

        }

        public Clinica(int cli_codigo, string cli_nombre)
        {
            this.cli_codigo = cli_codigo;
            this.cli_nombre = cli_nombre;
        }

        public int Cli_codigo { get => cli_codigo; set => cli_codigo = value; }
        public string Cli_nombre { get => cli_nombre; set => cli_nombre = value; }
    }
}
