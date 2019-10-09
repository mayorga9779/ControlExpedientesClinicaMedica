using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class Empleado
    {
        private String emp_nombres;
        private String emp_apellidos;
        private String emp_direccion;
        private String emp_telefono;
        private String emp_fechaNacimiento;
        private int emp_dpi;
        private String emp_fotografia;
        private int cli_codigo;
        private int pue_codigo;

        public Empleado()
        {
        }

        public Empleado(string emp_nombres, string emp_apellidos, string emp_direccion, string emp_telefono, string emp_fechaNacimiento, int emp_dpi, string emp_fotografia, int cli_codigo, int pue_codigo)
        {
            this.Emp_nombres = emp_nombres;
            this.Emp_apellidos = emp_apellidos;
            this.Emp_direccion = emp_direccion;
            this.Emp_telefono = emp_telefono;
            this.Emp_fechaNacimiento = emp_fechaNacimiento;
            this.Emp_dpi = emp_dpi;
            this.Emp_fotografia = emp_fotografia;
            this.Cli_codigo = cli_codigo;
            this.Pue_codigo = pue_codigo;
        }

        public string Emp_nombres { get => emp_nombres; set => emp_nombres = value; }
        public string Emp_apellidos { get => emp_apellidos; set => emp_apellidos = value; }
        public string Emp_direccion { get => emp_direccion; set => emp_direccion = value; }
        public string Emp_telefono { get => emp_telefono; set => emp_telefono = value; }
        public string Emp_fechaNacimiento { get => emp_fechaNacimiento; set => emp_fechaNacimiento = value; }
        public int Emp_dpi { get => emp_dpi; set => emp_dpi = value; }
        public string Emp_fotografia { get => emp_fotografia; set => emp_fotografia = value; }
        public int Cli_codigo { get => cli_codigo; set => cli_codigo = value; }
        public int Pue_codigo { get => pue_codigo; set => pue_codigo = value; }
    }
}
