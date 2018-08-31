using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sklad.Models;
using System.Data.Entity;

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
            //ViewBag.ParentthingSL = new SelectList(db.Things,"Id","Name");
            //IEnumerable<string> includs = (from t in db.Things
            //                      where t.Includes != null || (t.Includes == null && t.Quantity >= 1)
            //                      select t.Name).ToList();



            var str = from t in db.Things
                      where !t.Includes.Any() || (t.Includes.Any() && t.Quantity >= 1)
                      select new SelectListItem { Text = t.Name, Value = t.Name };
            ViewBag.ForIncludes = str;//.ToList<string>();
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

        public ActionResult Details(int id)
        {
            Thing thing = db.Things.Find(id);

            if (thing == null)
            {
                return HttpNotFound();
            }

            return View(thing);
        }

        public ActionResult Edit(int id = 0)
        {
            Thing thing = db.Things.Find(id);

            if (thing == null)
            {
                return HttpNotFound();
            }
            ViewBag.Includes = db.Things.ToList();
            return View(thing);
        }

        [HttpPost]
        public ActionResult Edit(Thing thing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thing);
        }
    }
}