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
    public class CitaController : Controller
    {
        private ModeloCita modeloCita = new ModeloCita();
        private String mensaje = "";

        public IActionResult NuevaCita(IFormCollection formCollection)
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
                DateTime fecha;
                String fecha_cita = "";
                String hora_inicial = "";
                String hora_final = "";
                String codigo_paciente = "";

                if (!formCollection["dpFechaCita"].ToString().Equals(""))
                {
                    fecha = Convert.ToDateTime(formCollection["dpFechaCita"].ToString());
                    fecha_cita = fecha.ToString("yyyyMMdd");
                }
                if (formCollection["txtHoraInicial"].ToString().Equals(""))
                {
                    hora_inicial = null;
                }
                else
                {
                    hora_inicial = formCollection["txtHoraInicial"].ToString();
                }
                if (formCollection["txtHoraFinal"].ToString().Equals(""))
                {
                    hora_final = null;
                }
                else
                {
                    hora_final = formCollection["txtHoraFinal"].ToString();
                }
                if (formCollection["cbPaciente"].ToString().Equals(""))
                {
                    codigo_paciente = null;
                }
                else
                {
                    codigo_paciente = formCollection["cbPaciente"].ToString();
                }

                if (!fecha_cita.Equals("") && !hora_inicial.Equals("") && !hora_final.Equals("") && !codigo_paciente.Equals(""))
                {
                    mensaje = modeloCita.Crear_Cita(opcion, fecha_cita, hora_inicial, hora_final, codigo_paciente);
                    ViewData["mensaje"] = mensaje;
                    return View(ViewData["mensaje"]);
                }
            }
            catch(Exception ex)
            {
                mensaje = "EXCEPTION";
                ViewData["mensaje"] = mensaje;
                return View(ViewData["mensaje"]);
            }

            return View();
        }
    }
}