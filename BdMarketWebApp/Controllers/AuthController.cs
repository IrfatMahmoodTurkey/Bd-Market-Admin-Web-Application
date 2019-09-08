using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Manager;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.ViewModels;
using BdMarketWebApp.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BdMarketWebApp.Controllers
{
    public class AuthController : Controller
    {
        private AuthManager authManager;

        public AuthController()
        {
            authManager = new AuthManager();
        }

        [HttpGet]
        public IActionResult Login()
        {
            HttpContext.Session.SetString("employee", "");
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = authManager.LogIn(model);

                if (employee != null)
                {
                    var userData = JsonConvert.SerializeObject(employee);
                    HttpContext.Session.SetString("employee", userData);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    HttpContext.Session.SetString("employee", "");

                    ViewData["Message"] = BootstrapMessages.Failed("Invalid User Name or Password");
                    return RedirectToAction("Login", "Auth");
                }
            }
            else
            {
                HttpContext.Session.SetString("employee", "");

                ViewData["Message"] = BootstrapMessages.Failed("Fill up all fields correctly");
                return RedirectToAction("Login", "Auth");
            }
        }

        // log out
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("employee", "");

            return RedirectToAction("Login", "Auth");
        }
    }
}