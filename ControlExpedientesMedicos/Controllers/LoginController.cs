using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ControlExpedientesMedicos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ControlExpedientesMedicos.Controllers
{
    public class LoginController : Controller
    {
        private Conexion conn = new Conexion();
        private Login login = new Login();
        private String mensaje = "";

        public IActionResult Login(IFormCollection formCollection)
        {
            String usuario = formCollection["txtUsuario"].ToString();
            String password = formCollection["txtPassword"].ToString();

            if (!usuario.Equals("") && !password.Equals(""))
            {
                mensaje = login.Validar_Usuario(usuario, password);

                if (mensaje.Equals("VALIDO"))
                {
                    return RedirectToAction("Inicio", "Default");
                }
                else
                {
                    mensaje = "Usuario o password invalido!";
                    TempData["mensaje"] = mensaje;
                    ViewData["mensaje"] = mensaje;
                    //return RedirectToAction("Login", "Login");
                    return View(ViewData["mensaje"]);
                    //return RedirectToAction("Accion2");
                    //return View("Login");
                }
            }

            return View();
        }
    }
}