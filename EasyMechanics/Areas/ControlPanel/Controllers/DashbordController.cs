using EasyMachanics.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMachanics.Areas.ControlPanel.Controllers
{
    [Authenticate]
    public class DashbordController : Controller
    {
        // GET: ControlPanel/Dashbord
        public ActionResult Index()
        {
            return View();
        }
    }
}