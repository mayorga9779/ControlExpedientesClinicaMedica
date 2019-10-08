using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlExpedientesMedicos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ControlExpedientesMedicos.Controllers
{
    public class ClinicaController : Controller
    {
        private Conexion conn = new Conexion();
        private Login login = new Login();
        private ModeloClinica modeloClinica = new ModeloClinica();
        private String mensaje = "";

        public IActionResult NuevaClinica()
        {
            return View();
        }

        public JsonResult ObtenerClinicas()
        {
            ArrayList listaClinicas = new ArrayList();
            listaClinicas = modeloClinica.Obtener_Clinicas(1);
            
            return Json(listaClinicas);     //retorno la lista en formato Json
        }
    }
}