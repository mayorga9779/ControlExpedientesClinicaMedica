using System;
using System.Collections;
using ControlExpedientesMedicos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Nancy.Session;

namespace ControlExpedientesMedicos.Controllers
{
    public class ExpedienteController : Controller
    {
        private ModeloExpediente modeloExpediente = new ModeloExpediente();
        private ModeloCita modeloCita = new ModeloCita();
        private Expediente expediente = null;
        private String mensaje = "";

        public IActionResult NuevoExpediente(IFormCollection formCollection)
        {
            mensaje = "";
            ViewData["mensaje"] = mensaje;

            try
            {
                int opcion = 1;
                String descripcion = "";
                String codigo_paciente = "";

                if (formCollection["taDescripcion"].ToString().Equals(""))
                {
                    descripcion = "";
                }
                else
                {
                    descripcion = formCollection["taDescripcion"].ToString();
                }
                if (formCollection["cbPaciente"].ToString().Equals(""))
                {
                    codigo_paciente = "";
                }
                else
                {
                    codigo_paciente = formCollection["cbPaciente"].ToString();
                }

                if (!descripcion.Equals("") && !codigo_paciente.Equals(""))
                {
                    mensaje = modeloExpediente.Crear_Expediente(opcion, descripcion, codigo_paciente);
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

        public IActionResult BuscarExpediente(IFormCollection formCollection)
        {
            return View();
        }

        public IActionResult ModificarExpediente(int radiobtn)  //radiobtn es el nombre de la variable que recibo desde el javascript en BuscarExpediente.cshtml
        {
            expediente = new Expediente();
            int codigo_paciente = radiobtn;

            expediente = modeloExpediente.Obtener_Expediente(codigo_paciente);

            if (expediente != null)
            {
                ViewBag.codigo_expediente = expediente.Codigo_expediente;
                ViewBag.descripcion = expediente.Descripcion_expediente;
                ViewBag.nombres = expediente.Nombres_paciente;
                ViewBag.apellidos = expediente.Apellidos_paciente;
                ViewBag.direccion = expediente.Direccion_paciente;
                ViewBag.telefono = expediente.Telefono_paciente;
                DateTime fecha = expediente.Fecha_nacimiento;
                ViewBag.fecha_nacimiento = fecha.ToString("yyyy-MM-dd");
                ViewBag.seguro_social = expediente.Seguro_social;
                ViewBag.genero = expediente.Genero;
                ViewBag.email = expediente.Email;
            }

            return View();
        }

        public JsonResult ModificarExpedienteCitas(int codigo_paciente, String nombre_paciente) //en javascript el nombre de parametro que envio es codigo_paciente
        {
            ArrayList listaCitas = new ArrayList();
            HttpContext.Session.SetString("codigo_paciente", codigo_paciente.ToString());
            HttpContext.Session.SetString("nombre_paciente", nombre_paciente);

            listaCitas = modeloCita.ObtenerDetalleCitas(codigo_paciente);

            return Json(listaCitas);
        }
    }
}