using System;
using System.Collections;
using ControlExpedientesMedicos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControlExpedientesMedicos.Controllers
{
    public class PuestoController : Controller
    {
        private Conexion conn = new Conexion();
        private Login login = new Login();
        private ModeloPuesto modeloPuesto = new ModeloPuesto();
        private String mensaje = "";

        public IActionResult NuevoPuesto()
        {
            return View();
        }

        public JsonResult ObtenerPuestos()
        {
            ArrayList listaPuestos = new ArrayList();
            listaPuestos = modeloPuesto.Obtener_Puestos(1);

            return Json(listaPuestos);     //retorno la lista en formato Json
        }
    }
}