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
    public class ProductosVeterinariosController : Controller
    {
        private HpAerDbEntities db = new HpAerDbEntities();

        // GET: ProductosVeterinarios
        public ActionResult Index()
        {
            return View(db.ProductoVeterinarias.ToList());
        }

        // GET: ProductosVeterinarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoVeterinaria productoVeterinaria = db.ProductoVeterinarias.Find(id);
            if (productoVeterinaria == null)
            {
                return HttpNotFound();
            }
            return View(productoVeterinaria);
        }

        // GET: ProductosVeterinarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductosVeterinarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,cantidad,descripcion,fechaBaja")] ProductoVeterinaria productoVeterinaria)
        {
            if (ModelState.IsValid)
            {
             try {
                 db.ProductoVeterinarias.Add(productoVeterinaria);
                 db.SaveChanges();
                 return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                 return View("ErrorCreateDup", new HandleErrorInfo(ex, "ProductosVeterinarios", "Create"));
                }

            }

            return View(productoVeterinaria);
        }

        // GET: ProductosVeterinarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoVeterinaria productoVeterinaria = db.ProductoVeterinarias.Find(id);
            if (productoVeterinaria == null)
            {
                return HttpNotFound();
            }
            return View(productoVeterinaria);
        }

        // POST: ProductosVeterinarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,cantidad,descripcion,fechaBaja")] ProductoVeterinaria productoVeterinaria)
        {
            if (ModelState.IsValid)
            {
             try {
                 db.Entry(productoVeterinaria).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "ProductosVeterinarios", "Edit"));
                }
            }
            return View(productoVeterinaria);
        }

        // GET: ProductosVeterinarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoVeterinaria productoVeterinaria = db.ProductoVeterinarias.Find(id);
            if (productoVeterinaria == null)
            {
                return HttpNotFound();
            }
            return View(productoVeterinaria);
        }

        // POST: ProductosVeterinarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          try{
             ProductoVeterinaria productoVeterinaria = db.ProductoVeterinarias.Find(id);
             db.ProductoVeterinarias.Remove(productoVeterinaria);
             db.SaveChanges();
             return RedirectToAction("Index");
            }
             catch(Exception ex)
            {
             return View("ErrorDeleteRef", new HandleErrorInfo(ex, "ProductosVeterinarios", "Delete"));
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
