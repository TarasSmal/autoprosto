using DataContext.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMachanics.Controllers
{
    public class AboutUsController : BaseController
    {
        // GET: AboutUs
        public ActionResult Index()
        {
            var pageId = (int)Enum.Parse(typeof(DataContext.Enums.SpecialPages), "AboutUs");
            var langId = (int)Enum.Parse(typeof(DataContext.Enums.Languages), CurrentLang);

            return View(SpecialPage.GetOne(pageId, (byte)langId));
        }
    }
}