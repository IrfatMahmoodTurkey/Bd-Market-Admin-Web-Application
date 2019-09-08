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
    public class CategoryController : Controller
    {
        private CategoryManager categoryManager;
        private UserAccessManager userAccessManager;

        public CategoryController()
        {
            categoryManager = new CategoryManager();
            userAccessManager = new UserAccessManager();
        }

        // add category
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

                if (userAccessManager.IsAccessExists(employee.Id, 1))
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
        public IActionResult Add(Category category)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 1))
                {
                    if (ModelState.IsValid)
                    {
                        category.ActionBy = employee.UserName;
                        category.ActionName = ActionAttributes.ActionInsert;
                        category.ActionTime = DateTime.Now.ToString("F");
                        category.State = 1;

                        ViewData["Message"] = categoryManager.Add(category);
                        ModelState.Clear();
                        return View();
                    }
                    else
                    {
                        ViewData["Message"] = BootstrapMessages.Warning("Fill up all fields correctly");
                        return View();
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // view all category
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

                if (userAccessManager.IsAccessExists(employee.Id, 1))
                {
                    ViewBag.Categories = categoryManager.GetAll();
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

                if (userAccessManager.IsAccessExists(employee.Id, 1))
                {
                    if (categoryManager.IsExists(id))
                    {
                        Category category = categoryManager.GetCategoryById(id);
                        return View(category);
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
        public IActionResult Edit(Category category)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 1))
                {
                    if (categoryManager.IsExists(category.Id))
                    {
                        if (ModelState.IsValid)
                        {
                            category.ActionBy = employee.UserName;
                            category.ActionName = ActionAttributes.ActionUpdate;
                            category.ActionTime = DateTime.Now.ToString("F");
                            category.State = 1;

                            string updated = categoryManager.Update(category);

                            if (updated.Equals("1"))
                            {
                                return RedirectToAction("ViewAll", "Category");
                            }
                            else
                            {
                                Category categoryModel = categoryManager.GetCategoryById(category.Id);
                                ViewData["Message"] = updated;
                                return View(categoryModel);
                            }
                        }
                        else
                        {
                            Category categoryModel = categoryManager.GetCategoryById(category.Id);
                            ViewData["Message"] = BootstrapMessages.Warning("Fill up all fields correctly");
                            return View(categoryModel);
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