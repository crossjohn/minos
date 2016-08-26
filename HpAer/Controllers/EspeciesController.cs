using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HpAer.Models;

namespace HpAer.Controllers
{
    public class EspeciesController : Controller
    {
        private HpAerDbEntities db = new HpAerDbEntities();

        // GET: Especies
        public ActionResult Index()
        {
            return View(db.Especies.ToList());
        }

        // GET: Especies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especy especy = db.Especies.Find(id);
            if (especy == null)
            {
                return HttpNotFound();
            }
            return View(especy);
        }

        // GET: Especies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especies/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,descripcion,fechaBaja")] Especy especy)
        {
            if (ModelState.IsValid)
            {
             try {
                 if (especy.estadoHab == false) 
                 {
                     if (especy.fechaBaja == null)
                     {
                         especy.fechaBaja = DateTime.Now;
                     }
                 }
                 else
                 {
                     especy.fechaBaja = null;
                 }
                 db.Especies.Add(especy);
                 db.SaveChanges();
                 return RedirectToAction("Index");
                 }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Especies", "Create"));
                }
            }

            return View(especy);
        }

        // GET: Especies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especy especy = db.Especies.Find(id);
            if (especy == null)
            {
                return HttpNotFound();
            }
            return View(especy);
        }

        // POST: Especies/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,descripcion,fechaBaja,estadoHab")] Especy especy)
        {
            if (ModelState.IsValid)
            {
             try {
                 if (especy.estadoHab == false)
                   {
                       if (especy.fechaBaja == null)
                       {
                           especy.fechaBaja = DateTime.Now;
                       }

                   }
                 else
                   {
                       especy.fechaBaja = null;
                   }
                     db.Entry(especy).State = EntityState.Modified;
                     db.SaveChanges();
                     return RedirectToAction("Index");
                  }
                 catch(Exception ex)
                {
                 return View("ErrorCreateDup", new HandleErrorInfo(ex, "Especies", "Edit"));
                }

            }
            return View(especy);
        }

        // GET: Especies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especy especy = db.Especies.Find(id);
            if (especy == null)
            {
                return HttpNotFound();
            }
            return View(especy);
        }

        // POST: Especies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
         try { 
             Especy especy = db.Especies.Find(id);
             db.Especies.Remove(especy);
             db.SaveChanges();
             return RedirectToAction("Index");
            }
             catch(Exception ex)
            {
             return View("ErrorDeleteRef", new HandleErrorInfo(ex, "Especies", "Delete"));
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
