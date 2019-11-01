using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlExpedientesMedicos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlExpedientesMedicos.Controllers
{
    public class ConsultaController : Controller
    {
        private ModeloConsulta modeloConsulta = new ModeloConsulta();
        private String mensaje = "";

        public IActionResult NuevaConsulta(IFormCollection formCollection)
        {
            mensaje = "";
            ViewData["mensaje"] = mensaje;

            if (HttpContext.Session.GetString("codigo_paciente") != null)
            {
                ViewBag.codigo_paciente = HttpContext.Session.GetString("codigo_paciente");
                ViewBag.nombre_paciente = HttpContext.Session.GetString("nombre_paciente");

                HttpContext.Session.Remove("codigo_paciente");
                HttpContext.Session.Remove("nombre_paciente");
            }
            else
            {
                ViewBag.codigo_paciente = 0;
                ViewBag.nombre_paciente = 0;
            }

            try
            {
                int opcion = 1;
                String motivo = formCollection["taMotivo"].ToString();
                String sintoma = formCollection["taSintomas"].ToString();
                String diagnostico = formCollection["taDiagnostico"].ToString();
                String codigo_paciente = formCollection["cbPaciente"].ToString();


                if (!motivo.Equals("") && !sintoma.Equals("") && !diagnostico.Equals("") && !codigo_paciente.Equals(""))
                {
                    mensaje = modeloConsulta.Crear_Consulta(motivo, sintoma, diagnostico, Convert.ToInt32(codigo_paciente));
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
    }
}