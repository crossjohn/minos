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
    public class RazasController : Controller
    {
        private HpAerDbEntities db = new HpAerDbEntities();

        // GET: Razas
        public ActionResult Index()
        {
            var razas = db.Razas.Include(r => r.Especy);
            return View(razas.ToList());
        }

        // GET: Razas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raza raza = db.Razas.Find(id);
            if (raza == null)
            {
                return HttpNotFound();
            }
            return View(raza);
        }

        // GET: Razas/Create
        public ActionResult Create()
        {
            ViewBag.especieID = new SelectList(db.Especies, "Id", "nombre");
            return View();
        }

        // POST: Razas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,descripcion,especieID,fechaBaja,estadoHab")] Raza raza)
        {
            if (ModelState.IsValid)
            {
            try {
                if (raza.estadoHab == false)
                {
                    if (raza.fechaBaja == null)
                    {
                        raza.fechaBaja = DateTime.Now;
                    }
                }
                else
                {
                    raza.fechaBaja = null;
                }
                 db.Razas.Add(raza);
                 db.SaveChanges();
                 return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Razas", "Create"));
                }
            }

            ViewBag.especieID = new SelectList(db.Especies, "Id", "nombre", raza.especieID);
            return View(raza);
        }

        // GET: Razas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raza raza = db.Razas.Find(id);
            if (raza == null)
            {
                return HttpNotFound();
            }
            ViewBag.especieID = new SelectList(db.Especies, "Id", "nombre", raza.especieID);
            return View(raza);
        }

        // POST: Razas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,descripcion,especieID,fechaBaja, estadoHab")] Raza raza)
        {
            if (ModelState.IsValid)
            {
              try{
                  if (raza.estadoHab == false)
                  {
                      if (raza.fechaBaja == null)
                      {
                          raza.fechaBaja = DateTime.Now;
                      }
                  }
                  else
                  {
                      raza.fechaBaja = null;
                  }
                 db.Entry(raza).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Razas", "Edit"));
                }
            }
            ViewBag.especieID = new SelectList(db.Especies, "Id", "nombre", raza.especieID);
            return View(raza);
        }

        // GET: Razas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raza raza = db.Razas.Find(id);
            if (raza == null)
            {
                return HttpNotFound();
            }
            return View(raza);
        }

        // POST: Razas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
              Raza raza = db.Razas.Find(id);
              db.Razas.Remove(raza);
              db.SaveChanges();
              return RedirectToAction("Index");
            }
              catch(Exception ex)
            {
             return View("ErrorDeleteRef", new HandleErrorInfo(ex, "Razas", "Delete"));
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
