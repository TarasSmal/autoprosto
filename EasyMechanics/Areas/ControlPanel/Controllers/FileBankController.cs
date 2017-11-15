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
    public class FileBankController : Controller
    {
        // GET: ControlPanel/Bank
        public ActionResult Photos()
        {
            ViewBag.Title = "Банк Фото";
            return View("Index", FileBank.GetAll().Where(a => a.IdType == 1).OrderByDescending(f => f.Id).ToList());
        }

        public ActionResult Files()
        {
            ViewBag.Title = "Банк Файлів";
            return View("Index", FileBank.GetAll().Where(a => a.IdType == 2).OrderByDescending(f => f.Id).ToList());
        }

        [HttpPost]
        public ActionResult Add(FileBank model, string returnUrl, HttpPostedFileBase File)
        {
            if (File != null && !string.IsNullOrEmpty(File.FileName))
            {
                model.Path = ImageHelper.Save(File, Server.MapPath("~/Content/img/"));
            }
            model.IsActive = true;
            model.IdUpdatedBy = 1;
            model.UpdatedOn = DateTime.Now;
            model.CreatedOn = DateTime.Now;
            FileBank.Add(model);

            return Redirect(returnUrl);
        }
        [HttpGet]
        public ActionResult Edit(int Id, string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(FileBank.GetOne(Id));
        }
        [HttpPost]
        public ActionResult Edit(FileBank model, string returnUrl, HttpPostedFileBase File)
        {
            if (File != null && !string.IsNullOrEmpty(File.FileName))
            {
                model.Path = ImageHelper.Save(File, Server.MapPath("~/Content/img/"));
            }
            FileBank.Update(model);
            return Redirect(returnUrl);
        }

        public ActionResult Delete(int Id, string returnUrl)
        {
            FileBank.Delete(Id);
            return Redirect(returnUrl);
        }
    }
}