using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ControlExpedientesMedicos.Controllers
{
    public class ExpedienteController : Controller
    {
        public IActionResult NuevoExpediente()
        {
            return View();
        }

        public IActionResult ModificarExpediente()
        {
            return View();
        }
    }
}