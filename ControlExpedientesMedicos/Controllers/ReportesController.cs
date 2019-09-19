using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControlExpedientesMedicos.Controllers
{
    public class ReportesController : Controller
    {
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
    }
}