using DataContext.EDM;
using DataContext.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMachanics.Controllers
{
    public class HomeController : BaseController
    {
        int pageId;
        int langId;

        // GET: Home
        public ActionResult Index()
        {
            pageId = (int)Enum.Parse(typeof(DataContext.Enums.SpecialPages), "Home");
            langId = (int)Enum.Parse(typeof(DataContext.Enums.Languages), CurrentLang);

            return View(SpecialPage.GetOne(pageId, (byte)langId));
        }
    }
}