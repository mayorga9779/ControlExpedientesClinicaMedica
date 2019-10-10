using System;
using System.Collections;
using ControlExpedientesMedicos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlExpedientesMedicos.Controllers
{
    public class PuestoController : Controller
    {
        private Conexion conn = new Conexion();
        private Login login = new Login();
        private ModeloPuesto modeloPuesto = new ModeloPuesto();
        private String mensaje = "";

        public IActionResult NuevoPuesto(IFormCollection formCollection)
        {
            mensaje = "";
            ViewData["mensaje"] = mensaje;

            try
            {
                int opcion = 1;
                String pue_nombre = formCollection["txtPuesto"].ToString();
                String pue_descripcion = formCollection["taDescripcion"].ToString();

                if (!pue_nombre.Equals("") && !pue_descripcion.Equals(""))
                {
                    mensaje = modeloPuesto.Crear_Puesto(opcion, pue_nombre, pue_descripcion);
                    ViewData["mensaje"] = mensaje;
                    return View(ViewData["mensaje"]);
                }
            }
            catch (Exception ex)
            {
                mensaje = "EXCEPTION";
                ViewData["mensaje"] = mensaje;
                return View(ViewData["mensaje"]);
            }

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