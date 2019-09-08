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
    public class EmployeeController : Controller
    {
        private DesignationManager designationManager;
        private FTPFileUpload fileUpload;
        private EmployeeManager employeeManager;
        private UserAccessManager userAccessManager;

        public EmployeeController()
        {
            designationManager = new DesignationManager();
            fileUpload = new FTPFileUpload();
            employeeManager = new EmployeeManager();
            userAccessManager = new UserAccessManager();
        }

        // save employee
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


                if (userAccessManager.IsAccessExists(employee.Id, 4))
                {
                    ViewBag.Desigantions = designationManager.GetDesignationForDropDown();
                    return View();
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }
        
        [HttpPost]
        public IActionResult Add(Employee employee, IFormFile picture)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employeeData = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employeeData.Id, 4))
                {
                    if (ModelState.IsValid)
                    {
                        employee.Password = "12345";
                        employee.ActionBy = employeeData.UserName;
                        employee.ActionDone = ActionAttributes.ActionInsert;
                        employee.ActionTime = DateTime.Now.ToString("F");
                        employee.State = 1;

                        if (picture == null)
                        {
                            employee.ProfilePicture = "http://www.ecom.somee.com/EmployeeProfile/avater.jpg";
                        }
                        else
                        {
                            string fileName = Guid.NewGuid().ToString() + "_" + picture.FileName;
                            string response = fileUpload.UploadEmployeeProfilePicture(picture, fileName);

                            if (response.Equals("1"))
                            {
                                employee.ProfilePicture = "http://www.ecom.somee.com/EmployeeProfile/" + fileName;
                                ViewData["PictureMessage"] =
                                    BootstrapMessages.Success("Picture Uploaded Successfully.");
                            }
                            else
                            {
                                employee.ProfilePicture = "http://www.ecom.somee.com/EmployeeProfile/avater.jpg";
                                ViewData["PictureMessage"] =
                                    BootstrapMessages.Failed("Picture Uploaded Failed. Reason: " + response);
                            }
                        }

                        string saved = employeeManager.Save(employee);
                        ViewData["Message"] = saved;

                        ViewBag.Desigantions = designationManager.GetDesignationForDropDown();
                        ModelState.Clear();
                        return View();
                    }
                    else
                    {
                        ViewData["Message"] = BootstrapMessages.Warning("Fill up all fields correctly");
                        ViewBag.Desigantions = designationManager.GetDesignationForDropDown();
                        return View();
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // view all employee
        [HttpGet]
        public IActionResult ViewEmployee()
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 4))
                {
                    ViewBag.Employees = employeeManager.GetAllEmployees();
                    return View();
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // edit employee
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
                Employee employeeData = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employeeData.Id, 4))
                {
                    if (employeeManager.IsIdExists(id))
                    {
                        ViewBag.Desigantions = designationManager.GetDesignationForDropDown();
                        Employee employee = employeeManager.GetEmployeeById(id);

                        return View(employee);
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
        public IActionResult Edit(Employee employee)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employeeData = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employeeData.Id, 4))
                {
                    if (ModelState.IsValid)
                    {
                        employee.ActionBy = employeeData.UserName;
                        employee.ActionTime = DateTime.Now.ToString("F");
                        employee.ActionDone = ActionAttributes.ActionUpdate;
                        employee.State = 1;

                        string updated = employeeManager.Update(employee);

                        if (updated.Equals("1"))
                        {
                            return RedirectToAction("ViewEmployee", "Employee");
                        }
                        else
                        {
                            ViewBag.Desigantions = designationManager.GetDesignationForDropDown();
                            ViewData["Message"] = updated;

                            return View(employee);
                        }
                    }
                    else
                    {
                        ViewBag.Desigantions = designationManager.GetDesignationForDropDown();
                        ViewData["Message"] = BootstrapMessages.Failed("Fill up all fields correctly");

                        return View(employee);
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // reset password
        public IActionResult ResetPassword(int id)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employeeData = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employeeData.Id, 4))
                {
                    if (employeeManager.IsIdExists(id))
                    {
                        Employee employee = employeeManager.GetEmployeeById(id);
                        employee.Password = "12345";
                        employee.ActionDone = ActionAttributes.ActionUpdate;
                        employee.ActionBy = employeeData.UserName;
                        employee.ActionDone = DateTime.Now.ToString("F");
                        employee.State = 1;

                        employeeManager.Update(employee);
                        return RedirectToAction("ViewEmployee", "Employee");
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

        // remove user
        public IActionResult Remove(int id)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employeeData = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employeeData.Id, 4))
                {
                    if (employeeManager.IsIdExists(id))
                    {
                        Employee employee = employeeManager.GetEmployeeById(id);
                        employee.ActionDone = ActionAttributes.ActionRemove;
                        employee.ActionBy = employeeData.UserName;
                        employee.ActionDone = DateTime.Now.ToString("F");
                        employee.State = 0;

                        employeeManager.Update(employee);
                        return RedirectToAction("ViewEmployee", "Employee");
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

        // give access
        [HttpGet]
        public IActionResult UserAccess(int id)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 4))
                {
                    if (employeeManager.IsIdExists(id))
                    {
                        ViewData["userId"] = id;
                        ViewBag.UserAccesses = userAccessManager.GetAccessByUserId(id);

                        return View();
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
        public IActionResult UserAccess(UserAccess userAccess)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 4))
                {
                    if (ModelState.IsValid)
                    {
                        userAccess.Id = 0;
                        userAccess.ActionBy = employee.UserName;
                        userAccess.ActionTime = DateTime.Now.ToString("F");
                        userAccess.ActionDone = ActionAttributes.ActionInsert;
                        userAccess.State = 1;

                        string saved = userAccessManager.SaveUserAccess(userAccess);
                        ViewData["userId"] = userAccess.UserId;

                        if (saved.Equals("1"))
                        {
                            return RedirectToAction("UserAccess", "Employee", new { id = userAccess.UserId });
                        }
                        else
                        {
                            ViewData["Message"] = saved;
                        }

                        ViewBag.UserAccesses = userAccessManager.GetAccessByUserId(userAccess.UserId);
                        ModelState.Clear();
                        return View();
                    }
                    else
                    {
                        ViewData["Message"] = BootstrapMessages.Failed("Fill up all fields correctly");
                        ViewData["userId"] = userAccess.UserId;
                        ViewBag.UserAccesses = userAccessManager.GetAccessByUserId(userAccess.UserId);

                        return View();
                    }
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // remove access
        public IActionResult RemoveAccess(int id)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 4))
                {
                    if (userAccessManager.IsIdExists(id))
                    {
                        Models.UserAccess userAccess = userAccessManager.GetById(id);
                        userAccess.ActionBy = employee.UserName;
                        userAccess.ActionTime = DateTime.Now.ToString("F");
                        userAccess.ActionDone = ActionAttributes.ActionRemove;
                        userAccess.State = 0;

                        userAccessManager.Update(userAccess);

                        return RedirectToAction("UserAccess", "Employee", new { id = userAccess.UserId });
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

        // change password
        [HttpGet]
        public IActionResult ChangePassword()
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);
                return View();
            }
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (ModelState.IsValid)
                {
                    if (employee.Password.Equals(changePasswordViewModel.OldPassword))
                    {
                        if (changePasswordViewModel.NewPassword.Equals(changePasswordViewModel.ReEnterPassword))
                        {
                            Employee employeeModel = employeeManager.GetEmployeeById(employee.Id);

                            employeeModel.Password = changePasswordViewModel.NewPassword;
                            employeeModel.ActionBy = employee.UserName;
                            employeeModel.ActionDone = ActionAttributes.ActionUpdate;
                            employeeModel.ActionTime = DateTime.Now.ToString("F");

                            string updated = employeeManager.Update(employeeModel);

                            if (updated.Equals("1"))
                            {
                                return RedirectToAction("Logout", "Auth");
                            }
                            else
                            {
                                ViewData["Message"] = updated;
                            }
                        }
                        else
                        {
                            ViewData["Message"] = BootstrapMessages.Warning("New and Re Entered Password does not matched");
                        }
                    }
                    else
                    {
                        ViewData["Message"] = BootstrapMessages.Failed("Invalid Old Password");
                    }
                }
                else
                {
                    ViewData["Message"] = BootstrapMessages.Failed("Fill up all fields correctly");
                }

                return View();
            }
        }

        // change profile picture
        [HttpGet]
        public IActionResult ChangeProfilePicture()
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                ViewData["ProfilePicture"] = employee.ProfilePicture;

                return View();
            }
        }

        [HttpPost]
        public IActionResult ChangeProfilePicture(IFormFile profilePicture)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (profilePicture != null)
                {
                    string fileName = Guid.NewGuid()+"_"+profilePicture.FileName;

                    string uploaded = fileUpload.UploadEmployeeProfilePicture(profilePicture, fileName);

                    if (uploaded.Equals("1"))
                    {
                        Employee employeeModel = employeeManager.GetEmployeeById(employee.Id);

                        employeeModel.ProfilePicture = "http://www.ecom.somee.com/EmployeeProfile/" + fileName;
                        employeeModel.ActionBy = employee.UserName;
                        employeeModel.ActionDone = ActionAttributes.ActionUpdate;
                        employeeModel.ActionTime = DateTime.Now.ToString("F");

                        string updated = employeeManager.Update(employeeModel);

                        if (updated.Equals("1"))
                        {
                            ViewData["ProfilePicture"] = employeeModel.ProfilePicture;
                            var userData = JsonConvert.SerializeObject(employeeModel);
                            HttpContext.Session.SetString("employee", userData);
                        }
                        else
                        {
                            ViewData["ProfilePicture"] = employee.ProfilePicture;
                            ViewData["Message"] = updated;
                        }
                    }
                    else
                    {
                        ViewData["ProfilePicture"] = employee.ProfilePicture;
                        ViewData["Message"] = BootstrapMessages.Failed(" Failed to Upload New Profile Picture");
                    }
                    
                }
                else
                {
                    ViewData["ProfilePicture"] = employee.ProfilePicture;
                    ViewData["Message"] = BootstrapMessages.Failed(" Browse one file");
                }

                return View();
            }
        }
    }
}