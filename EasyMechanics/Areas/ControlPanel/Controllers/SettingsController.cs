using DataContext.EDM;
using EasyMachanics.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMachanics.Areas.ControlPanel.Controllers
{
    [Authenticate]
    public class SettingsController : Controller
    {
        // GET: ControlPanel/Settings
        public ActionResult Index()
        {
            return View(Setting.GetAll());
        }

        [ValidateInput(false)]
        public ActionResult Edit(long Id, string Values)
        {
            var s = Setting.GetOne(Id);
            s.Values = Values;
            Setting.Update(s);
            return RedirectToAction("Index");
        }
    }
}