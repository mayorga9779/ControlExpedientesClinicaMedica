using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlExpedientesMedicos.Models
{
    public class Cita
    {
        DateTime fecha_cita;
        String hora_inicio;
        String hora_fin;

        public Cita()
        {
        }

        public Cita(DateTime fecha_cita, string hora_inicio, string hora_fin)
        {
            this.Fecha_cita = fecha_cita;
            this.Hora_inicio = hora_inicio;
            this.Hora_fin = hora_fin;
        }

        public DateTime Fecha_cita { get => fecha_cita; set => fecha_cita = value; }
        public string Hora_inicio { get => hora_inicio; set => hora_inicio = value; }
        public string Hora_fin { get => hora_fin; set => hora_fin = value; }
    }
}
