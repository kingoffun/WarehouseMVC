using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sklad.Models;

namespace sklad.Controllers
{
    public class HomeController : Controller
    {
        WarehouseContext db = new WarehouseContext();
        public ActionResult Index()
        {
            var property = db.Things;
            return View(property);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ParentthingSL = new SelectList(db.Things,"Id","Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Thing thing)
        {
            if (ModelState.IsValid)
            {
                //db.Things.Find(thing.ParentThingId).ParentThingId = thing.Id;
                db.Things.Add(thing);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(thing);
            }

        }
    }
}