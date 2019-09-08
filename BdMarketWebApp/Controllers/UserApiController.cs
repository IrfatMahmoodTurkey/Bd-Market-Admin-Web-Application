using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using BdMarketWebApp.Gateway.UnitOfWorks;
using BdMarketWebApp.Manager;
using BdMarketWebApp.Models;
using BdMarketWebApp.Models.ViewModels;
using BdMarketWebApp.Utility;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlMatches;

namespace BdMarketWebApp.Controllers
{
    [EnableCors("AllowAll")]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private UserManager userManager;

        public UserApiController()
        {
            userManager = new UserManager();
        }

        [Route("Register")]
        [HttpPost]
        public object Register()
        {
            User user = new User();

            user.UserName = Request.Form["UserName"];
            user.Email = Request.Form["Email"];
            user.Password = Request.Form["Password"];
            user.Phone = Request.Form["Phone"];

            Random rand = new Random();
            user.VerificationCode = rand.Next(1000, Int32.MaxValue).ToString();
            user.Verify = 0;
            user.AccountCreatingTime = DateTime.Now.ToString("F");
            user.State = 1;

            string saved = userManager.RegisterUser(user);

            if (saved.Equals("1"))
            {
                string subject = "BD Market. Account Registration Verification";
                string body = "<p>Dear " + user.UserName +
                              "</p><p>Thank you for choosing our e-commerce site for shopping. To Open or Register New Account, you have to verify your account email address. Your verification code is <strong>" +
                              user.VerificationCode + "</strong>.</p><p>Thank You. Happy Shopping.</p>";

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
            }

            return saved;
        }

        [Route("Verify")]
        [HttpPost]
        public object VerifyAccount()
        {
            VerifyAccountViewModel model = new VerifyAccountViewModel();

            model.Email = Request.Form["email"];
            model.VerificationCode = Request.Form["verificationCode"];

            string message = userManager.VerifyAccount(model);

            return message;
        }

        // log in by email and verification code after register a new account
        [Route("LoginByActivation")]
        [HttpGet]
        public object LogInByActivationCode(string email, string code)
        {
            User user = userManager.LogInByVerificationCode(email, code);

            return user;
        }

        [Route("Login")]
        [HttpPost]
        public object Login()
        {
            UserLoginViewModel model = new UserLoginViewModel();

            model.Email = Request.Form["email"];
            model.Password = Request.Form["password"];

            User user = userManager.LogIn(model);

            if (user != null)
            {
                return user;
            }
            else
            {
                return "0";
            }
        }

        // for resend verification code via email
        [Route("ResendEmail")]
        [HttpGet]
        public object ResendEmail(string emailAddress)
        {
            User user = userManager.GetUserByEmail(emailAddress);

            if (user != null)
            {
                if (user.Verify == 0)
                {
                    string subject = "BD Market. Account Registration Verification";
                    string body = "<p>Dear " + user.UserName +
                                  "</p><p>Thank you for choosing our e-commerce site for shopping. To Open or Register New Account, you have to verify your account email address. Your verification code is <strong>" +
                                  user.VerificationCode + "</strong>.</p><p>Thank You. Happy Shopping.</p>";

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

                    // send
                    return "1";
                }
                else
                {
                    // already verified
                    return "2";
                }
            }
            else
            {
                // invalid user
                return "3";
            }
        }
        

        // forget password
        [Route("ForgetPassword")]
        [HttpGet]
        public object ForgetPasswordRequest(string email)
        {
            User user = userManager.GetUserByEmail(email);

            if (user != null)
            {
                Random rand = new Random();
                user.VerificationCode = rand.Next(1000, Int32.MaxValue).ToString();

                string message = userManager.Update(user);

                if (message.Equals("1"))
                {
                    string subject = "BD Market. Account Registration Verification";
                    string body = "<p>Dear " + user.UserName +
                                  "</p><p>Thank you for choosing our e-commerce site for shopping. To Change your password you have to enter verification code and new password. Your new verification code is <strong>" +
                                  user.VerificationCode + "</strong>.</p><p>Thank You. Happy Shopping.</p>";

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

                    // sended
                    return "1";
                }
                else
                {
                    // try again
                    return "0";
                }
            }
            else
            {
                // invalid user
                return "3";
            }
        }

        // change forgotten password
        [Route("ChangeForgottenPassword")]
        [HttpPost]
        public object ChangeForgottenPassword()
        {
            User user = new User();

            user.Email = Request.Form["Email"];
            user.VerificationCode = Request.Form["VerificationCode"];
            user.Password = Request.Form["Password"];

            User userModel = userManager.GetUserByEmail(user.Email);

            if (userModel != null)
            {
                if (userModel.VerificationCode.Equals(user.VerificationCode))
                {
                    userModel.Password = user.Password;

                    string message = userManager.Update(userModel);

                    return message;
                }
                else
                {
                    // wrong verification code
                    return "4";
                }
            }
            else
            {
                // invalid user
                return "3";
            }
        }

        //change password
        [Route("ChangePassword")]
        [HttpPost]
        public object ChangePassword()
        {
            User user = new User();
            User userOld = new User();

            user.Email = Request.Form["UserEmail"];
            user.Password = Request.Form["UserPassword"];
            userOld.Password = Request.Form["OldPassword"];

            User userModel = userManager.GetUserByEmail(user.Email);

            if (userModel.Password.Equals(userOld.Password))
            {
                userModel.Password = user.Password;
                string updated = userManager.Update(userModel);

                return updated;
            }
            else
            {
                return "3";
            }
        }
    }
}