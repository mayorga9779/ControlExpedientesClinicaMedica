using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class Expediente
    {
        int codigo_expediente;
        String descripcion_expediente;
        String nombres_paciente;
        String apellidos_paciente;
        String direccion_paciente;
        String telefono_paciente;
        DateTime fecha_nacimiento;
        String seguro_social;
        String genero;
        String email;

        public Expediente()
        {
        }

        public Expediente(int codigo_expediente, string descripcion_expediente, string nombres_paciente, string apellidos_paciente, string direccion_paciente, string telefono_paciente, DateTime fecha_nacimiento, string seguro_social, string genero, string email)
        {
            this.Codigo_expediente = codigo_expediente;
            this.Descripcion_expediente = descripcion_expediente;
            this.Nombres_paciente = nombres_paciente;
            this.Apellidos_paciente = apellidos_paciente;
            this.Direccion_paciente = direccion_paciente;
            this.Telefono_paciente = telefono_paciente;
            this.Fecha_nacimiento = fecha_nacimiento;
            this.Seguro_social = seguro_social;
            this.Genero = genero;
            this.Email = email;
        }

        public int Codigo_expediente { get => codigo_expediente; set => codigo_expediente = value; }
        public string Descripcion_expediente { get => descripcion_expediente; set => descripcion_expediente = value; }
        public string Nombres_paciente { get => nombres_paciente; set => nombres_paciente = value; }
        public string Apellidos_paciente { get => apellidos_paciente; set => apellidos_paciente = value; }
        public string Direccion_paciente { get => direccion_paciente; set => direccion_paciente = value; }
        public string Telefono_paciente { get => telefono_paciente; set => telefono_paciente = value; }
        public DateTime Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public string Seguro_social { get => seguro_social; set => seguro_social = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Email { get => email; set => email = value; }
    }
}
