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
    public class CallesController : Controller
    {
        private HpAerDbEntities db = new HpAerDbEntities();

        // GET: Calles
        public ActionResult Index()
        {
            var calles = db.Calles.Include(c => c.Localidade);
            return View(calles.ToList());
        }

        // GET: Calles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calle calle = db.Calles.Find(id);
            if (calle == null)
            {
                return HttpNotFound();
            }
            return View(calle);
        }

        // GET: Calles/Create
        public ActionResult Create()
        {
            ViewBag.localidadId = new SelectList(db.Localidads, "Id", "nombre");
            return View();
        }

        // POST: Calles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,calle_nombre,localidadId")] Calle calle)
        {
            if (ModelState.IsValid)
            {
                try
                {
                db.Calles.Add(calle);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Calles", "Create"));
                }

            }

            ViewBag.localidadId = new SelectList(db.Localidads, "Id", "nombre", calle.localidadId);
            return View(calle);
        }

        // GET: Calles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calle calle = db.Calles.Find(id);
            if (calle == null)
            {
                return HttpNotFound();
            }
            ViewBag.localidadId = new SelectList(db.Localidads, "Id", "nombre", calle.localidadId);
            return View(calle);
        }

        // POST: Calles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,calle_nombre,localidadId")] Calle calle)
        {
            if (ModelState.IsValid)
            {
                try
                {
                db.Entry(calle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Calles", "Edit"));
                }
            }
            ViewBag.localidadId = new SelectList(db.Localidads, "Id", "nombre", calle.localidadId);
            return View(calle);
        }

        // GET: Calles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calle calle = db.Calles.Find(id);
            if (calle == null)
            {
                return HttpNotFound();
            }
            return View(calle);
        }

        // POST: Calles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
            Calle calle = db.Calles.Find(id);
            db.Calles.Remove(calle);
            db.SaveChanges();
            return RedirectToAction("Index");
           }
             catch(Exception ex)
           {
            return View("ErrorDeleteRef", new HandleErrorInfo(ex, "Calles", "Delete"));
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
