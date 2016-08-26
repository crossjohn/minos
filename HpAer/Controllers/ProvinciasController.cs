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
    public class ProvinciasController : Controller
    {
        private HpAerDbEntities db = new HpAerDbEntities();

        // GET: Provincias
        public ActionResult Index()
        {
            var provincias = db.Provincias.Include(p => p.Pais);
            return View(provincias.ToList());
        }

        // GET: Provincias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // GET: Provincias/Create
        public ActionResult Create()
        {
            ViewBag.paisId = new SelectList(db.Paises, "Id", "pais_nombre");
            return View();
        }

        // POST: Provincias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,paisId")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
               try 
               {
                db.Provincias.Add(provincia);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Provincias", "Create"));
                }

            }

            ViewBag.paisId = new SelectList(db.Paises, "Id", "pais_nombre", provincia.paisId);
            return View(provincia);
        }

        // GET: Provincias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            ViewBag.paisId = new SelectList(db.Paises, "Id", "pais_nombre", provincia.paisId);
            return View(provincia);
        }

        // POST: Provincias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,paisId")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                try
                {
                db.Entry(provincia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Provincias", "Edit"));
                }

            }
            ViewBag.paisId = new SelectList(db.Paises, "Id", "pais_nombre", provincia.paisId);
            return View(provincia);
        }

        // GET: Provincias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
              Provincia provincia = db.Provincias.Find(id);
              db.Provincias.Remove(provincia);
              db.SaveChanges();
              return RedirectToAction("Index");     
            }
              catch(Exception ex)
            {
             return View("ErrorDeleteRef", new HandleErrorInfo(ex, "Provincias", "Delete"));
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
