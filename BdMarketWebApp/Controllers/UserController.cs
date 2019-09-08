using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    public class UserController : Controller
    {
        private UserManager userManager;
        private Random random;
        private UserAccessManager userAccessManager;

        public UserController()
        {
            userManager = new UserManager();
            random = new Random();
            userAccessManager = new UserAccessManager();
        }

        // register manually user
        [HttpGet]
        public IActionResult RegisterUser()
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 7))
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
        public IActionResult RegisterUser(UserViewModel user)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 7))
                {
                    if (ModelState.IsValid)
                    {
                        User userModel = new User();
                        userModel.UserName = user.UserName;
                        userModel.Email = user.Email;
                        userModel.Password = "12345";
                        userModel.Phone = user.Phone;
                        userModel.VerificationCode = random.Next(1000, Int32.MaxValue).ToString();
                        userModel.Verify = 0;
                        userModel.AccountCreatingTime = DateTime.Now.ToString("F");
                        userModel.State = 1;

                        string saved = userManager.RegisterUser(userModel);

                        if (saved.Equals("1"))
                        {
                            string subject = "BD Market. Account Registration Verification";
                            string body = "<p>Dear " + user.UserName +
                                          "</p><p>Thank you for choosing our e-commerce site for shopping. To Open or Register New Account, you have to verify your account email address. Your verification code is <strong>" +
                                          userModel.VerificationCode + "</strong>.</p><p>Thank You. Happy Shopping.</p>";

                            MailMessage mail = new MailMessage();
                            mail.To.Add(user.Email);
                            mail.From = new MailAddress("to@mail.com");
                            mail.Subject = subject;
                            mail.Body = body;
                            mail.IsBodyHtml = true;

                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = 587;
                            smtp.UseDefaultCredentials = true;
                            smtp.Credentials = new System.Net.NetworkCredential
                                ("to@mail.com", "password");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);

                            ViewData["Message"] = BootstrapMessages.Success("Register Successful");
                        }
                        else if (saved.Equals("2"))
                        {
                            ViewData["Message"] = BootstrapMessages.Success("User Email already exists");
                        }
                        else
                        {
                            ViewData["Message"] = BootstrapMessages.Success("Failed to Register New User");
                        }

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

        // view all user
        [HttpGet]
        public IActionResult ViewAllUsers()
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 7))
                {
                    ViewBag.Users = userManager.GetAllUsers();
                    return View();
                }
                else
                {
                    return NotFound("No Access");
                }
            }
        }

        // banned or remove user account
        public IActionResult Banned(int id)
        {
            var employeeDataString = HttpContext.Session.GetString("employee");

            if (employeeDataString == "")
            {
                return RedirectToAction("Login", "Auth");
            }
            else
            {
                Employee employee = JsonConvert.DeserializeObject<Employee>(employeeDataString);

                if (userAccessManager.IsAccessExists(employee.Id, 7))
                {
                    if (userManager.IsIdExists(id))
                    {
                        User user = userManager.GetUserById(id);
                        user.State = 0;

                        userManager.Update(user);
                        return RedirectToAction("ViewAllUsers", "User");
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