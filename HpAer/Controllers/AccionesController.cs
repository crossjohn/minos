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
    public class AccionesController : Controller
    {
        private HpAerDbEntities db = new HpAerDbEntities();

        // GET: Acciones
        public ActionResult Index()
        {
            return View(db.Acciones.ToList());
        }

        // GET: Acciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accione accione = db.Acciones.Find(id);
            if (accione == null)
            {
                return HttpNotFound();
            }
            return View(accione);
        }

        // GET: Acciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Acciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,descripcion,isSelected")] Accione accione)
        {
            if (ModelState.IsValid)
            {
             try 
                {
                db.Acciones.Add(accione);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Acciones", "Create"));
                }

            }

            return View(accione);
        }

        // GET: Acciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accione accione = db.Acciones.Find(id);
            if (accione == null)
            {
                return HttpNotFound();
            }
            return View(accione);
        }

        // POST: Acciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,descripcion,isSelected")] Accione accione)
        {
            if (ModelState.IsValid)
            {
             try {
                 db.Entry(accione).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Acciones", "Edit"));
                }
            }
            return View(accione);
        }

        // GET: Acciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accione accione = db.Acciones.Find(id);
            if (accione == null)
            {
                return HttpNotFound();
            }
            return View(accione);
        }

        // POST: Acciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
         try {
             Accione accione = db.Acciones.Find(id);
             db.Acciones.Remove(accione);
             db.SaveChanges();
             return RedirectToAction("Index");
            }
             catch(Exception ex)
            {
             return View("ErrorDeleteRef", new HandleErrorInfo(ex, "Acciones", "Delete"));
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
