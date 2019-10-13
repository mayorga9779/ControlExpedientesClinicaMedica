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
    public class PacienteController : Controller
    {
        private ModeloPaciente modeloPaciente = new ModeloPaciente();
        private String mensaje = "";

        public IActionResult NuevoPaciente(IFormCollection formCollection)
        {
            mensaje = "";
            ViewData["mensaje"] = mensaje;

            try
            {
                int opcion = 1;
                String nombres = formCollection["txtNombresP"].ToString();
                String apellidos = formCollection["txtApellidosP"].ToString();
                String direccion = formCollection["txtDireccionP"].ToString();
                String telefono = formCollection["txtTelefonoP"].ToString();
                DateTime fecha;
                String fecha_nacimiento = "";
                String seguro_social = "";
                String genero = "";
                String email = "";

                if (!formCollection["txtFecNacP"].ToString().Equals(""))
                {
                    fecha = Convert.ToDateTime(formCollection["txtFecNacP"].ToString());
                    fecha_nacimiento = fecha.ToString("yyyyMMdd");

                }

                if (formCollection["txtSeguroSocial"].ToString().Equals(""))
                {
                    seguro_social = null;
                }
                else
                {
                    seguro_social = formCollection["txtSeguroSocial"].ToString();
                }

                if (formCollection["cbGenero"].ToString().Equals(""))
                {
                    genero = null;
                }
                else
                {
                    genero = formCollection["cbGenero"].ToString();
                }

                if (formCollection["txtEmailP"].ToString().Equals(""))
                {
                    email = null;
                }
                else
                {
                    email = formCollection["txtEmailP"].ToString();
                }

                if (!nombres.Equals("") && !apellidos.Equals("") && !direccion.Equals("") && !telefono.Equals("") && !fecha_nacimiento.Equals("") && !genero.Equals("") && !email.Equals(""))
                {
                    mensaje = modeloPaciente.Crear_Paciente(opcion, nombres, apellidos, direccion, telefono, fecha_nacimiento, seguro_social, genero, email);
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

        public JsonResult ObtenerPacientes()
        {
            ArrayList listaPacientes = new ArrayList();
            listaPacientes = modeloPaciente.Obtener_Pacientes(1);

            return Json(listaPacientes);     //retorno la lista en formato Json
        }
    }
}