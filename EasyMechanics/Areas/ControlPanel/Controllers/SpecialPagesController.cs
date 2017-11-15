using DataContext;
using DataContext.EDM;
using EasyMachanics.Authorization;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyMachanics.Areas.ControlPanel.Controllers
{
    [Authenticate]
    public class SpecialPagesController : Controller
    {
        // GET: ControlPanel/SpecialPages
        public ActionResult Index()
        {
            ViewBag.Title = "Страницы";
            return View(SpecialPage.GetAll().Where(f=>f.IdLanguage == 1).ToList());
        }

        public ActionResult Edit(int Id)
        {
            return View(SpecialPage.GetAll().Where(a => a.OriginalId == Id).ToList());
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(List<SpecialPage> sp, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowErrors = true;
                ModelState.AddModelError("", "Ошибка введения");
                return View(sp);
            }
            try
            {
                var old = SpecialPage.GetOne(sp[0].Id);
                if (file == null)
                    sp[0].PageImage = old.PageImage;
                else
                    sp[0].PageImage = ImageHelper.Save(file, Server.MapPath("/Content/img/"));

                sp[0].PageId = old.PageId;
                sp[1].PageId = sp[0].PageId;

                sp[0].OriginalId = old.OriginalId;
                sp[1].OriginalId = sp[0].OriginalId;

                sp[1].PageImage = sp[0].PageImage;

                SpecialPage.Update(sp[0]);
                SpecialPage.Update(sp[1]);
                return RedirectToAction("Index", new { Id = sp[0].PageId });

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                throw;
            }

        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult Create(SpecialPage model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    try
        //    {
        //        SpecialPage.Add(model);
        //        return RedirectToAction("Index", "SpecialPages");
        //    }
        //    catch { }
        //    return View();
        //}

        //public ActionResult Delete(int id)
        //{
        //    var specialPage = SpecialPage.GetOne(id);
        //    if (specialPage != null)
        //    {
        //        SpecialPage.Delete(specialPage);
        //        return RedirectToAction("Index");
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}