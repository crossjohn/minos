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
    public class BarriosController : Controller
    {
        private HpAerDbEntities db = new HpAerDbEntities();

        // GET: Barrios
        public ActionResult Index()
        {
            var barrios = db.Barrios.Include(b => b.Localidade);
            return View(barrios.ToList());
        }

        // GET: Barrios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrio barrio = db.Barrios.Find(id);
            if (barrio == null)
            {
                return HttpNotFound();
            }
            return View(barrio);
        }

        // GET: Barrios/Create
        public ActionResult Create()
        {
            ViewBag.localidadId = new SelectList(db.Localidads, "Id", "nombre");
            return View();
        }

        // POST: Barrios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,codigoPostal,localidadId,Zona")] Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                try
                {
                db.Barrios.Add(barrio);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Barrios", "Create"));
                }
            }

            ViewBag.localidadId = new SelectList(db.Localidads, "Id", "nombre", barrio.localidadId);
            return View(barrio);
        }

        // GET: Barrios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrio barrio = db.Barrios.Find(id);
            if (barrio == null)
            {
                return HttpNotFound();
            }
            ViewBag.localidadId = new SelectList(db.Localidads, "Id", "nombre", barrio.localidadId);
            return View(barrio);
        }

        // POST: Barrios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,codigoPostal,localidadId,Zona")] Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                try
                {
                db.Entry(barrio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Barrios", "Edit"));
                }
            }
            ViewBag.localidadId = new SelectList(db.Localidads, "Id", "nombre", barrio.localidadId);
            return View(barrio);
        }

        // GET: Barrios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barrio barrio = db.Barrios.Find(id);
            if (barrio == null)
            {
                return HttpNotFound();
            }
            return View(barrio);
        }

        // POST: Barrios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
            Barrio barrio = db.Barrios.Find(id);
            db.Barrios.Remove(barrio);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
              catch(Exception ex)
            {
             return View("ErrorDeleteRef", new HandleErrorInfo(ex, "Barrios", "Delete"));
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
