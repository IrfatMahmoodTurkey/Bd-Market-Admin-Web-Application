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
    public class DesignationController : Controller
    {
        private DesignationManager designationManager;
        private UserAccessManager userAccessManager;

        public DesignationController()
        {
            designationManager = new DesignationManager();
            userAccessManager = new UserAccessManager();
        }

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

                if (userAccessManager.IsAccessExists(employee.Id, 3))
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
        public IActionResult Add(Designation designation)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 3))
                {
                    if (ModelState.IsValid)
                    {
                        designation.ActionBy = employee.UserName;
                        designation.ActionDone = ActionAttributes.ActionInsert;
                        designation.ActionTime = DateTime.Now.ToString("F");
                        designation.State = 1;

                        string saved = designationManager.Save(designation);
                        ViewData["Message"] = saved;
                        ModelState.Clear();
                        return View();
                    }
                    else
                    {
                        ViewData["Message"] = BootstrapMessages.Warning("Fill up all fields correctly");
                        return View(designation);
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // view all designation
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

                if (userAccessManager.IsAccessExists(employee.Id, 3))
                {
                    ViewBag.Designations = designationManager.GetAllDesignations();
                    return View();
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // update
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

                if (userAccessManager.IsAccessExists(employee.Id, 3))
                {
                    if (designationManager.IsExists(id))
                    {
                        Designation designation = designationManager.GetById(id);
                        return View(designation);
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
        public IActionResult Edit(Designation designation)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 3))
                {
                    if (designationManager.IsExists(designation.Id))
                    {
                        if (ModelState.IsValid)
                        {
                            designation.ActionBy = employee.UserName;
                            designation.ActionDone = ActionAttributes.ActionUpdate;
                            designation.ActionTime = DateTime.Now.ToString("F");
                            designation.State = 1;

                            string updated = designationManager.Update(designation);

                            if (updated.Equals("1"))
                            {
                                return RedirectToAction("ViewAll", "Designation");
                            }
                            else
                            {
                                ViewData["Message"] = updated;
                                return View(designation);
                            }
                        }
                        else
                        {
                            ViewData["Message"] = BootstrapMessages.Warning("Fill up all fields correctly");
                            Designation designationModel = designationManager.GetById(designation.Id);
                            return View(designationModel);
                        }
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
    }
}