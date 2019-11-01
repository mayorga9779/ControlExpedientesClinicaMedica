using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class ReportePaciente
    {
        int codigo_expediente;
        int codigo_paciente;
        String paciente;
        String fecha_alta;
        String genero;
        String fecha_nacimiento;
        String direccion;
        String telefono;

        public ReportePaciente()
        {
        }

        public ReportePaciente(int codigo_expediente, int codigo_paciente, string paciente, string fecha_alta, string genero, string fecha_nacimiento, string direccion, string telefono)
        {
            this.Codigo_expediente = codigo_expediente;
            this.Codigo_paciente = codigo_paciente;
            this.Paciente = paciente;
            this.Fecha_alta = fecha_alta;
            this.Genero = genero;
            this.Fecha_nacimiento = fecha_nacimiento;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }

        public int Codigo_expediente { get => codigo_expediente; set => codigo_expediente = value; }
        public int Codigo_paciente { get => codigo_paciente; set => codigo_paciente = value; }
        public string Paciente { get => paciente; set => paciente = value; }
        public string Fecha_alta { get => fecha_alta; set => fecha_alta = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
