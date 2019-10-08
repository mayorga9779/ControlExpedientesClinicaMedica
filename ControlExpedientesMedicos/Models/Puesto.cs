using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class Puesto
    {
        private int pue_codigo = 0;
        private String pue_nombre = "";

        public Puesto(int pue_codigo, string pue_nombre)
        {
            this.Pue_codigo = pue_codigo;
            this.Pue_nombre = pue_nombre;
        }

        public int Pue_codigo { get => pue_codigo; set => pue_codigo = value; }
        public string Pue_nombre { get => pue_nombre; set => pue_nombre = value; }
    }
}
