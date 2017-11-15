using DataContext.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EasyMachanics.Extensions;

namespace EasyMachanics.Controllers
{
    public class ContactsController : BaseController
    {
        // GET: Contacts
        public ActionResult Index()
        {
            var pageId = (int)Enum.Parse(typeof(DataContext.Enums.SpecialPages), "Contacts");
            var langId = (int)Enum.Parse(typeof(DataContext.Enums.Languages), CurrentLang);

            return View(SpecialPage.GetOne(pageId, (byte)langId));

        }

        public ActionResult Send(string Name, string Email,  string Message)
        {
            var SysEmail = Setting.GetOne((int)Enum.Parse(typeof(DataContext.Enums.Settings), "Email")).Values;
            var pass = @Setting.GetOne((int)Enum.Parse(typeof(DataContext.Enums.Settings), "EmailPassword")).Values;

            var body = "<p>" + Name + "</p>"
                        + "<p>" + Email + "</p>"
                        + "<p>" + Message + "</p>";
            Notification mess = new Notification(Name, SysEmail, pass, SysEmail, body);
            return Redirect("Index");
        }
    }
}