using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlExpedientesMedicos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlExpedientesMedicos.Controllers
{
    public class ReportesController : Controller
    {
        private ModeloReportePacientes modeloReportePacientes = new ModeloReportePacientes();

        public IActionResult ReportePacientes()
        {
            return View();
        }

        public IActionResult ReporteMedicos()
        {
            return View();
        }

        public IActionResult ReporteCitas()
        {
            return View();
        }

        public JsonResult ObtenerListadoPacientes(int opcion, String fecha_inicio, String fecha_fin, String genero)
        {
            ArrayList listaReportePacientes = new ArrayList();

            if (fecha_inicio.Equals("null"))
            {
                fecha_inicio = null;
            }
            if (fecha_fin.Equals("null"))
            {
                fecha_fin = null;
            }
            if (genero.Equals("null"))
            {
                genero = null;
            }

            listaReportePacientes = modeloReportePacientes.ObtenerPacientes(opcion, fecha_inicio, fecha_fin, genero);

            return Json(listaReportePacientes);
        }
    }
}