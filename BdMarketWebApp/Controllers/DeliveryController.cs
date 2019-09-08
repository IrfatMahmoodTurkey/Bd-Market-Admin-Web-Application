using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BdMarketWebApp.Manager;
using BdMarketWebApp.Models;
using BdMarketWebApp.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BdMarketWebApp.Controllers
{
    public class DeliveryController : Controller
    {
        private DeliveryManager deliveryManager;
        private UserAccessManager userAccessManager;

        public DeliveryController()
        {
            deliveryManager = new DeliveryManager();
            userAccessManager = new UserAccessManager();
        }

        // add delivery info
        [HttpGet]
        public IActionResult Add()
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 2))
                {
                    return View();
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        [HttpPost]
        public IActionResult Add(Delivery delivery)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 2))
                {
                    if (ModelState.IsValid)
                    {
                        delivery.ActionBy = employee.UserName;
                        delivery.ActionTime = DateTime.Now.ToString("F");
                        delivery.ActionDone = ActionAttributes.ActionInsert;
                        delivery.State = 1;

                        ViewData["Message"] = deliveryManager.Save(delivery);
                        ModelState.Clear();
                        return View();
                    }
                    else
                    {
                        ViewData["Message"] = BootstrapMessages.Failed("Fill up all fields correctly");
                        return View();
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // view all delivery
        [HttpGet]
        public IActionResult ViewAll()
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 2))
                {
                    ViewBag.Deliveries = deliveryManager.ViewAllDeliveries();
                    return View();
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // update all delivery
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 2))
                {
                    if (deliveryManager.IsIdExists(id))
                    {
                        Delivery delivery = deliveryManager.GetById(id);

                        return View(delivery);
                    }
                    else
                    {
                        return NotFound("404- Not Found");
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        [HttpPost]
        public IActionResult Edit(Delivery delivery)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 2))
                {
                    if (ModelState.IsValid)
                    {
                        delivery.ActionBy = employee.UserName;
                        delivery.ActionTime = DateTime.Now.ToString("F");
                        delivery.ActionDone = ActionAttributes.ActionUpdate;
                        delivery.State = 1;

                        string updated = deliveryManager.Update(delivery);

                        if (updated.Equals("1"))
                        {
                            return RedirectToAction("ViewAll", "Delivery");
                        }
                        else
                        {
                            ViewData["Message"] = updated;
                            return View(delivery);
                        }
                    }
                    else
                    {
                        ViewData["Message"] = BootstrapMessages.Failed("Fill up all fields correctly");
                        return View(delivery);
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }
    }
}