using DataContext.EDM;
using EasyMachanics.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EasyMachanics.Areas.ControlPanel.Controllers
{
    [Authenticate]
    public class UserController : Controller
    {
        // GET: ControlPanel/User
        public ActionResult Index()
        {
            return View(DataContext.EDM.User.GetAll());
        }

        [HttpGet]
        public ActionResult Edit(long Id)
        {
            return View(DataContext.EDM.User.GetOne(Id));
        }

        [HttpPost]
        public ActionResult Edit(User model)
        {
            try
            {
                model.Password = GetMd5Hash(model.Password);
                DataContext.EDM.User.Update(model);
            return RedirectToAction("Index", "Dashbord");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult CreateUser(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            //ViewBag.Roles = User.GetRoles();
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User model, string returnUrl, string Name)
        {
            ViewBag.returnUrl = returnUrl;
            User user = new User();
            user.Name = model.Name;
            user.Email = model.Email;
            user.Password = model.Password;
            user.IdRole = 1;
            //ставимо хешований пароль
            user.Password = GetMd5Hash(user.Password);

            DataContext.EDM.User.Add(user);
            return Redirect(returnUrl);
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