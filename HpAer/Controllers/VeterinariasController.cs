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
    public class VeterinariasController : Controller
    {
        private HpAerDbEntities db = new HpAerDbEntities();

        // GET: Veterinarias
        public ActionResult Index()
        {
            return View(db.Veterinarias.ToList());
        }

        // GET: Veterinarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinaria veterinaria = db.Veterinarias.Find(id);
            if (veterinaria == null)
            {
                return HttpNotFound();
            }
            return View(veterinaria);
        }

        // GET: Veterinarias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veterinarias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,direccion,telefono,fechaBaja")] Veterinaria veterinaria)
        {
            if (ModelState.IsValid)
            {
              try {
                   db.Veterinarias.Add(veterinaria);
                   db.SaveChanges();
                   return RedirectToAction("Index");
                }
                  catch(Exception ex)
                {
                  return View("ErrorCreateDup", new HandleErrorInfo(ex, "Veterinarias", "Create"));
                }

            }

            return View(veterinaria);
        }

        // GET: Veterinarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinaria veterinaria = db.Veterinarias.Find(id);
            if (veterinaria == null)
            {
                return HttpNotFound();
            }
            return View(veterinaria);
        }

        // POST: Veterinarias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,direccion,telefono,fechaBaja")] Veterinaria veterinaria)
        {
            if (ModelState.IsValid)
            {
             try {
                 db.Entry(veterinaria).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Veterinarias", "Edit"));
                }

            }
            return View(veterinaria);
        }

        // GET: Veterinarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Veterinaria veterinaria = db.Veterinarias.Find(id);
            if (veterinaria == null)
            {
                return HttpNotFound();
            }
            return View(veterinaria);
        }

        // POST: Veterinarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
         try {
             Veterinaria veterinaria = db.Veterinarias.Find(id);
             db.Veterinarias.Remove(veterinaria);
             db.SaveChanges();
             return RedirectToAction("Index");
            }
              catch(Exception ex)
            {
             return View("ErrorDeleteRef", new HandleErrorInfo(ex, "Veterinarias", "Delete"));
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
