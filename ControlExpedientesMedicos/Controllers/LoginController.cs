using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ControlExpedientesMedicos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlExpedientesMedicos.Controllers
{
    public class LoginController : Controller
    {
        private Conexion conn = new Conexion();
        private DataTable dt = null;
        //[HttpPost]
        public IActionResult Login(IFormCollection formCollection)
        {
            String usuario = formCollection["txtUsuario"];
            String password = formCollection["txtPassword"];

            if(usuario != "" && password != "")
            {
                
            }

            return View();
        }
    }
}