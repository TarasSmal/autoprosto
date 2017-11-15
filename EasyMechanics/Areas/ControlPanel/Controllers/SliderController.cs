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
    public class SliderController : Controller
    {
        // GET: ControlPanel/Slider
        public ActionResult Index(int Id)
        {
            TempData["PageId"] = Id;
            return View(Slider.GetAll().Where(f => f.PageId == Id && f.IdLanguage == 1).ToList());
        }

        [HttpGet]
        public ActionResult Edit(long Id)
        {
            return View(Slider.GetAll().Where(a => a.Id == Id || a.Id == Id+1).ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(List<Slider> sp, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowErrors = true;
                ModelState.AddModelError("", "Ошибка введения");
                return View(sp);
            }
            var old = Slider.GetOne(sp[0].Id);

            if (file != null)
            {
                sp[0].Image = ImageHelper.Save(file, Server.MapPath("/Content/img/"));
                sp[1].Image = sp[0].Image;
            }
            else
            {
                sp[0].Image = old.Image;
                sp[1].Image = sp[0].Image;
            }

            sp[0].PageId = old.PageId;
            sp[1].PageId = sp[0].PageId;

            sp[0].OriginalId = old.OriginalId;
            sp[1].OriginalId = sp[0].OriginalId;

            Slider.Update(sp[0]);
            Slider.Update(sp[1]);

            return RedirectToAction("Index", new { Id = sp[0].PageId.Value});
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(List<Slider> sp, HttpPostedFileBase file, int PageId)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowErrors = true;
                ModelState.AddModelError("", "Ошибка введения");
                return View(sp);
            }
            foreach (var item in sp)
            {
                item.OriginalId = PageId;
                item.UpdatedOn = DateTime.Now;
                item.CreatedOn = DateTime.Now;
                item.IdUpdatedBy = 1;
            }

            sp[0].Image = ImageHelper.Save(file, Server.MapPath("/Content/img/"));
            sp[1].Image = sp[0].Image;

            sp[0].PageId = PageId;
            sp[1].PageId = PageId;


            Slider.AddAll(sp);
           

            return RedirectToAction("Index", new {Id = sp[0].PageId.Value });
        }

        public ActionResult Delete(long Id)
        {
            var pageId = Slider.GetOne(Id).PageId;
            Slider.Delete(Id);
            Slider.Delete(Id+1);
            return RedirectToAction("Index", new { Id = pageId });
        }
    }
}