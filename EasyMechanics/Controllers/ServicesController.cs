using DataContext.EDM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMachanics.Controllers
{
    public class ServicesController : BaseController
    {
        int pageId;
        int langId;
        
        // GET: Services
        public ActionResult Index()
        {
            pageId = (int)Enum.Parse(typeof(DataContext.Enums.SpecialPages), "Services");
            langId = (int)Enum.Parse(typeof(DataContext.Enums.Languages), CurrentLang);

            return View(SpecialPage.GetOne(pageId, (byte)langId));

        }

        public ActionResult Check()
        {
            pageId = (int)Enum.Parse(typeof(DataContext.Enums.SpecialPages), "Check");
            langId = (int)Enum.Parse(typeof(DataContext.Enums.Languages), CurrentLang);

            return View(SpecialPage.GetOne(pageId, (byte)langId));

        }
        public ActionResult Auction()
        {
            pageId = (int)Enum.Parse(typeof(DataContext.Enums.SpecialPages), "Auction");
            langId = (int)Enum.Parse(typeof(DataContext.Enums.Languages), CurrentLang);

            return View(SpecialPage.GetOne(pageId, (byte)langId));

        }
        public ActionResult Parts()
        {
            pageId = (int)Enum.Parse(typeof(DataContext.Enums.SpecialPages), "Parts");
            langId = (int)Enum.Parse(typeof(DataContext.Enums.Languages), CurrentLang);

            return View(SpecialPage.GetOne(pageId, (byte)langId));

        }
    }
}