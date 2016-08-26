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
    
    public class PaisesController : Controller
    {
        private HpAerDbEntities db = new HpAerDbEntities();
        

        // GET: Paises
        public ActionResult Index()
        {
            return View(db.Paises.OrderBy(x=>x.pais_nombre).ToList());
        }

        // GET: Paises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = db.Paises.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // GET: Paises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paises/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,pais_nombre")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                try
                {
                db.Paises.Add(pais);
                db.SaveChanges();
                
                 return RedirectToAction("Index");
             
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Paises", "Create"));
                }
            }

            return View(pais);
        }

        // GET: Paises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = db.Paises.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: Paises/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,pais_nombre")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                
                try
                {
                 db.Entry(pais).State = EntityState.Modified;
                 db.SaveChanges();
                return RedirectToAction("Index");
                 }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Paises", "Edit"));
                }
            }
            return View(pais);
        }

        // GET: Paises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pais pais = db.Paises.Find(id);
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           try {
                Pais pais = db.Paises.Find(id);
                db.Paises.Remove(pais);
                db.SaveChanges();

            
                return RedirectToAction("Index");
             
               }
                catch(Exception ex)
               {
                   return View("ErrorDeleteRef", new HandleErrorInfo(ex, "Paises", "Delete"));
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
