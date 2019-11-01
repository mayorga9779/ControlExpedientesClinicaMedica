using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class Consulta
    {
        int codigo_consulta;
        String motivo;
        String sintoma;
        String diagnostico;
        int codigo_paciente;
        DateTime fecha_consulta;

        public Consulta()
        {
        }

        public Consulta(string motivo, string sintoma, string diagnostico, int codigo_paciente, DateTime fecha_consulta)
        {
            this.Motivo = motivo;
            this.Sintoma = sintoma;
            this.Diagnostico = diagnostico;
            this.Codigo_paciente = codigo_paciente;
            this.Fecha_consulta = fecha_consulta;
        }

        public Consulta(int codigo_consulta, string motivo, string sintoma, string diagnostico, int codigo_paciente)
        {
            this.Codigo_consulta = codigo_consulta;
            this.Motivo = motivo;
            this.Sintoma = sintoma;
            this.Diagnostico = diagnostico;
            this.Codigo_paciente = codigo_paciente;
        }

        public int Codigo_consulta { get => codigo_consulta; set => codigo_consulta = value; }
        public string Motivo { get => motivo; set => motivo = value; }
        public string Sintoma { get => sintoma; set => sintoma = value; }
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }
        public int Codigo_paciente { get => codigo_paciente; set => codigo_paciente = value; }
        public DateTime Fecha_consulta { get => fecha_consulta; set => fecha_consulta = value; }
    }
}
