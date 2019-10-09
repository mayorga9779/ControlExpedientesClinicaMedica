using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlExpedientesMedicos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlExpedientesMedicos.Controllers
{
    public class EmpleadoController : Controller
    {
        private ModeloEmpleado modeloEmpleado = new ModeloEmpleado();
        private String mensaje = "";

        public IActionResult NuevoEmpleado(IFormCollection formCollection)
        {
            mensaje = "";
            ViewData["mensaje"] = mensaje;

            try
            {
                int opcion = 1;
                String nombres = formCollection["txtNombres"].ToString();
                String apellidos = formCollection["txtApellidos"].ToString();
                String direccion = formCollection["txtDireccionE"].ToString();
                String telefono = formCollection["txtTelefonoE"].ToString();
                DateTime fecha;
                String fecha_nacimiento = "";
                if (formCollection["txtFecNacE"].ToString().Equals(""))
                {
                    //fecha = DateTime.Now;

                }
                else
                {
                    fecha = Convert.ToDateTime(formCollection["txtFecNacE"].ToString());
                    fecha_nacimiento = fecha.ToString("yyyyMMdd");
                }
                //String fecha_nacimiento = formCollection["txtFecNacE"].ToString();
                int dpi = 0;
                String fotografia = "";
                int codigo_clinica = 0;
                int codigo_puesto = 0;

                if (formCollection["txtDpi"].ToString().Equals(""))
                {
                    dpi = 0;
                }
                else
                {
                    dpi = Convert.ToInt32(formCollection["txtDpi"].ToString());
                }
                if(formCollection["fFotoE"].ToString().Equals(""))
                {
                    fotografia = null;
                }
                else
                {
                    fotografia  = formCollection["fFotoE"].ToString();
                }
                if (formCollection["cbClinica"].ToString().Equals(""))
                {
                    codigo_clinica = 0;
                }
                else
                {
                    codigo_clinica = Convert.ToInt32(formCollection["cbClinica"].ToString());
                }
                if (formCollection["cbPuesto"].ToString().Equals(""))
                {
                    codigo_puesto = 0;
                }
                else
                {
                    codigo_puesto = Convert.ToInt32(formCollection["cbPuesto"].ToString());
                }

                if (!nombres.Equals("") && !apellidos.Equals("") && !direccion.Equals("") && !telefono.Equals("") && !fecha_nacimiento.Equals("") && !dpi.Equals("") && !codigo_clinica.Equals("") && !codigo_puesto.Equals(""))
                {
                    mensaje = modeloEmpleado.Crear_Empleado(opcion, nombres, apellidos, direccion, telefono, fecha_nacimiento, dpi, fotografia, codigo_clinica, codigo_puesto);
                    ViewData["mensaje"] = mensaje;
                    return View(ViewData["mensaje"]);
                }
            }
            catch (Exception ex)
            {
                mensaje = "EXCEPTION";
                ViewData["mensaje"] = mensaje;
                return View(ViewData["mensaje"]);
                //Console.WriteLine("Controlador Emplado: " + ex.StackTrace);
            }

            return View();
        }
    }
}