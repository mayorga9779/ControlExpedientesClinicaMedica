using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControlExpedientesMedicos.Controllers
{
    public class ClinicaController : Controller
    {
        public IActionResult NuevaClinica()
        {
            return View();
        }
    }
}