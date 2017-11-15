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
    public class ResponsesController : Controller
    {
        // GET: ControlPanel/Responses
        public ActionResult Index()
        {
            return View(Respons.GetAll());
        }


        // GET: ControlPanel/Responses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ControlPanel/Responses/Create
        [HttpPost]
        public ActionResult Create(Respons collection)
        {
            try
            {
                Respons.Add(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ControlPanel/Responses/Edit/5
        public ActionResult Edit(int Id)
        {
            return View(Respons.GetOne(Id));
        }

        // POST: ControlPanel/Responses/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, Respons collection)
        {
            try
            {
                Respons.Update(collection);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ControlPanel/Responses/Delete/5
        public ActionResult Delete(int Id)
        {
            Respons.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}
