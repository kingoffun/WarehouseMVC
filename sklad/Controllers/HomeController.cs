using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sklad.Models;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;

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



            //var str = from t in db.Things
            //          where !t.Includes.Any() || (t.Includes.Any() && t.Quantity >= 1)
            //          select new SelectListItem { Text = t.Name, Value = t.Name };
            var includs = db.Things.SelectMany(p => p.Includes).Select(p => p.Name);
            var str1 = from t in db.Things
                      where !includs.Contains(t.Name) 
                      select new SelectListItem { Text = t.Name + " s/n:" + t.SerialNumber, Value = t.Name };
            ViewBag.ForIncludes = str1;//.ToList<string>();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Thing thing, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var c1 = form["ta_includs"].Split(',').ToList();

                foreach (var t in c1)
                {
                    thing.Includes.Add(
                        db.Things.Where(x => x.Name == t).FirstOrDefault());
                }

                db.Things.Add(thing);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                //Thing th = new Thing { Name = form["Includes"].ToString() };
                //var c = form["ta_includs"];
                //var errors = ModelState.Values.SelectMany(v => v.Errors);

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

            ViewBag.Includes = thing.Includes.Select(p => new SelectListItem { Text = p.Name + " s/n:" + p.SerialNumber, Value = p.Name }).ToList();

            var includs = db.Things.SelectMany(p => p.Includes).Select(p => p.Name);
            var str1 = from t in db.Things
                       where !includs.Contains(t.Name) && t.Id != id
                       select new SelectListItem { Text = t.Name + " s/n:" + t.SerialNumber, Value = t.Name };

            ViewBag.ForIncludes = str1;//.ToList<string>();

            return View(thing);
        }

        [HttpPost]
        public ActionResult Edit(Thing thing, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                //var c1 = thing.SelIncludes;
                db.Things.Attach(thing);

                if (!thing.Includes.Any())
                {
                    var pt1 = db.Things.Where(th => th.Id == thing.Id).Include(i => i.Includes).FirstOrDefault();

                    foreach (var t in thing.SelIncludes)
                    {
                        
                    var pt = db.Things.Where(th => th.Id == thing.Id).Include(i => i.Includes);

                        //if (! thing.Includes.Contains(db.Things.Where(x => x.Name == t).FirstOrDefault()))
                        if (! pt.Includes.Contains(db.Things.Where(x => x.Name == t).FirstOrDefault()))
                        {
                            thing.Includes.Add(db.Things.Where(x => x.Name == t).FirstOrDefault());
                        }

                    }
                }

                //using (var db_tmp = new WarehouseContext())
                //{
                //    var thing_tmp = thing;
                //    var includs_tmp = thing.Includes;

                //    db_tmp.Attach(thing_tmp);

                //}

                //DbSet.Attach(thing);
                //db.Entry(thing).State = EntityState.Modified;
                //db.Entry(thing.Includes).State = EntityState.Modified;
                //var st = db.Entry(thing).State;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thing);
        }
    }
}