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
    public class LocalidadesController : Controller
    {
        private HpAerDbEntities db = new HpAerDbEntities();

        // GET: Localidades
        public ActionResult Index()
        {
            var localidads = db.Localidads.Include(l => l.Provincia);
            return View(localidads.ToList());
        }

        // GET: Localidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidad localidad = db.Localidads.Find(id);
            if (localidad == null)
            {
                return HttpNotFound();
            }
            return View(localidad);
        }

        // GET: Localidades/Create
        public ActionResult Create()
        {
            ViewBag.provinciaId = new SelectList(db.Provincias, "Id", "nombre");
            return View();
        }

        // POST: Localidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,provinciaId")] Localidad localidad)
        {
            if (ModelState.IsValid)
            {
                try
                {
                db.Localidads.Add(localidad);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Localidades", "Create"));
                }
 
            }

            ViewBag.provinciaId = new SelectList(db.Provincias, "Id", "nombre", localidad.provinciaId);
            return View(localidad);
        }

        // GET: Localidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidad localidad = db.Localidads.Find(id);
            if (localidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.provinciaId = new SelectList(db.Provincias, "Id", "nombre", localidad.provinciaId);
            return View(localidad);
        }

        // POST: Localidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,provinciaId")] Localidad localidad)
        {
            if (ModelState.IsValid)
            {
                try
                {
                db.Entry(localidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Localidades", "Edit"));
                }
            }
            ViewBag.provinciaId = new SelectList(db.Provincias, "Id", "nombre", localidad.provinciaId);
            return View(localidad);
        }

        // GET: Localidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidad localidad = db.Localidads.Find(id);
            if (localidad == null)
            {
                return HttpNotFound();
            }
            return View(localidad);
        }

        // POST: Localidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
            Localidad localidad = db.Localidads.Find(id);
            db.Localidads.Remove(localidad);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
             catch(Exception ex)
            {
             return View("ErrorDeleteRef", new HandleErrorInfo(ex, "Localidades", "Delete"));
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
