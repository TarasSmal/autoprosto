using DataContext.EDM;
using EasyMachanics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMachanics.Controllers
{
    public class ResponsesController : BaseController
    {
        // GET: Sesponses
        public ActionResult Index()
        {
            var pageId = (int)Enum.Parse(typeof(DataContext.Enums.SpecialPages), "Responses");
           var  langId = (int)Enum.Parse(typeof(DataContext.Enums.Languages), CurrentLang);

            ResponsesViewModel model = new ResponsesViewModel
            {
                Responses = Respons.GetAll(),   
                SpecialPages = SpecialPage.GetOne(pageId, (byte)langId)
            };

            return View(model);
        }
    }
}