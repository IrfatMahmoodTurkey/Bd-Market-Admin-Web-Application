using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Manager;
using Microsoft.AspNetCore.Mvc;
using BdMarketWebApp.Models;
using BdMarketWebApp.Utility;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BdMarketWebApp.Controllers
{
    public class HomeController : Controller
    {
        private DashboardManager dashboardManager;

        public HomeController()
        {
            dashboardManager = new DashboardManager();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                HttpContext.Session.SetString("UserName", employee.UserName);

                ViewData["Items"] = dashboardManager.ItemsCount();
                ViewData["Stock"] = dashboardManager.StockOutItemCount();
                ViewData["NewOrder"] = dashboardManager.NewOrdersCount();
                ViewData["Users"] = dashboardManager.NumberOfUsers();

                ViewBag.YearlyAmountByMonth = dashboardManager.YearlySoldAmount();
                ViewBag.YearProfitByMonth = dashboardManager.YearlyProfit();
                ViewBag.YearAmount = dashboardManager.SoldAmountHistory();
                ViewBag.YearProfit = dashboardManager.SoldProfitHistory();
                ViewBag.Years = dashboardManager.GetYears();

                return View();
            }
        }
    }
}
