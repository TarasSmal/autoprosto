using DataContext.EDM;
using DataContext.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EasyMachanics.Models;
using EasyMachanics.Authorization;

namespace EasyMachanics.Controllers
{
    public class AccountController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (FormsAuthenticationService.User != null)
                return RedirectToAction("Index", "Dashboard", new { Id = FormsAuthenticationService.User.Id });
            return RedirectToAction("Login");

        }

        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            //ViewBag.Login = SpecialPage.GetAll().FirstOrDefault(a => a.Id == 9);
            ViewBag.Url = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string ReturnUrl)
        {
            //ViewBag.Login = SpecialPage.GetAll().FirstOrDefault(a => a.Id == 9);

            if (!ModelState.IsValid)
                ModelState.AddModelError("", "Please fill the required fields");
            else
            {
                string pswd = GetMd5Hash(model.Password);
                var user = DataContext.EDM.User.GetOne(model.Login, pswd);

                if (user != null)
                {
                    FormsAuthenticationService.Login(user, model.RememberMe);
                    string decodedUrl = "";
                    if (!string.IsNullOrEmpty(ReturnUrl))
                        decodedUrl = Server.UrlDecode(ReturnUrl);
                    if (Url.IsLocalUrl(decodedUrl))
                        return Redirect(decodedUrl);
                    else
                        return RedirectToAction("Index", "Dashbord", new { area = "ControlPanel" });
                }
                else
                    ModelState.AddModelError("", "Please fill the required fields");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthenticationService.Logout();
            //виходимо
            return Redirect("~/Home/Index/");
        }


        [HttpGet]
        [Authenticate]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        // [Authenticate]
        public ActionResult ChangePassword(PasswordViewModel pass)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowErrors = true;
                ModelState.AddModelError("", "Please fill the required fields");
                return View(pass);
            }
            if (GetMd5Hash(pass.OldPassword) != FormsAuthenticationService.User.Password)
            {
                ViewBag.ShowErrors = true;
                ModelState.AddModelError("", "Enter old password");
                return View(pass);
            }

            DataContext.EDM.User.UpdatePassword(FormsAuthenticationService.User.Id, GetMd5Hash(pass.NewPassword));
            return RedirectToAction("Index", "ControlPanel", new { Id = FormsAuthenticationService.User.Id });
        }

        [HttpGet]
        public ActionResult RestorePassword()
        {
            ViewBag.RestorePassword = SpecialPage.GetAll().FirstOrDefault(a => a.Id == 11);
            return PartialView();
        }

        [HttpPost]
        public ActionResult RestorePassword(RestorePasswordViewModel model)
        {
            //send an email to the model.Email
            //that email must contain a password to the user Account

            var user = DataContext.EDM.User.GetAll().FirstOrDefault(u => u.Email == model.EmailRestore);
            if (user == null)
                return RedirectToAction("Login");

            var fromAddress = new MailAddress("rug199992@mail.ua", "PAS");
            var toAddress = new MailAddress(user.Email);
            const string fromPassword = "rerehelpf";
            const string subject = "Password";
            string body = "go to - http://www.capitalpas.eu/Account/SetPassword?email=" + user.Email + "&hash=" + user.Password;
            var smtp = new SmtpClient
            {
                Host = "smtp.mail.ru",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var msп = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(msп);
            }

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult SetPassword(string email, string hash)
        {
            ViewBag.RestorePassword = SpecialPage.GetAll().FirstOrDefault(a => a.Id == 11);
            var user = DataContext.EDM.User.GetAll().FirstOrDefault(u => u.Email == email && u.Password == hash);

            if (user == null)
                return RedirectToAction("RestorePassword");
            ViewBag.Id = user.Id;

            return View();
        }

        [HttpPost]
        public ActionResult SetPassword(int? Id, string password)
        {
            if (!Id.HasValue || string.IsNullOrEmpty(password))
                return RedirectToAction("RestorePassword");

            DataContext.EDM.User.UpdatePassword(Id.Value, GetMd5Hash(password));
            return RedirectToAction("Login");
        }

        private string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}