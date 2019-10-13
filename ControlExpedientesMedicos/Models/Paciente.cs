using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class Paciente
    {
        int pac_codigo = 0;
        String pac_nombre = "";

        public Paciente()
        {
        }

        public Paciente(int pac_codigo, string pac_nombre)
        {
            this.Pac_codigo = pac_codigo;
            this.Pac_nombre = pac_nombre;
        }

        public int Pac_codigo { get => pac_codigo; set => pac_codigo = value; }
        public string Pac_nombre { get => pac_nombre; set => pac_nombre = value; }
    }
}
