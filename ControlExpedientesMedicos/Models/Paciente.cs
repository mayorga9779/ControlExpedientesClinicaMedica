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
        String pac_apellido = "";
        String pac_telefono = "";
        String pac_direccion = "";
        String pac_email = "";

        public Paciente()
        {
        }

        public Paciente(int pac_codigo, string pac_nombre)
        {
            this.Pac_codigo = pac_codigo;
            this.Pac_nombre = pac_nombre;
        }

        public Paciente(int pac_codigo, string pac_nombre, string pac_apellido, string pac_telefono, string pac_direccion, string pac_email)
        {
            this.pac_codigo = pac_codigo;
            this.pac_nombre = pac_nombre;
            this.pac_apellido = pac_apellido;
            this.pac_telefono = pac_telefono;
            this.pac_direccion = pac_direccion;
            this.pac_email = pac_email;
        }

        public int Pac_codigo { get => pac_codigo; set => pac_codigo = value; }
        public string Pac_nombre { get => pac_nombre; set => pac_nombre = value; }
        public string Pac_apellido { get => pac_apellido; set => pac_apellido = value; }
        public string Pac_telefono { get => pac_telefono; set => pac_telefono = value; }
        public string Pac_direccion { get => pac_direccion; set => pac_direccion = value; }
        public string Pac_email { get => pac_email; set => pac_email = value; }
    }
}
