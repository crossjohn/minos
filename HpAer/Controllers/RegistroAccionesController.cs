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
    public class RegistroAccionesController : Controller
    {
        private HpAerDbEntities db = new HpAerDbEntities();

        // GET: RegistroAcciones
        public ActionResult Index()
        {
            var registroAcciones = db.RegistroAcciones.Include(r => r.Accione).Include(r => r.Persona);
            return View(registroAcciones.ToList());
        }

        public ActionResult IndexVp(int id)
        {
            ViewBag.PersonaId = id;
            var registroAcciones = db.RegistroAcciones.Where(d => d.personaId == id).OrderBy(d => d.Accione.nombre).Include(r => r.Accione).Include(r => r.Persona);
            return PartialView("_IndexVp", registroAcciones.ToList());
        }
                // GET: RegistroAcciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroAccione registroAccione = db.RegistroAcciones.Find(id);
            if (registroAccione == null)
            {
                return HttpNotFound();
            }
            return View(registroAccione);
        }

        public ActionResult DetailsVp(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroAccione registroAccione = db.RegistroAcciones.Find(id);
            if (registroAccione == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DetailsVp", registroAccione);
        }


        // GET: RegistroAcciones/Create
        public ActionResult Create()
        {
            ViewBag.accionesId = new SelectList(db.Acciones, "Id", "nombre");
            ViewBag.personaId = new SelectList(db.Personas, "Id", "Nombre");
            return View();
        }

        public ActionResult CreateVp(int PersonaId)
        {
            RegistroAccione model = new RegistroAccione();
            model.personaId = PersonaId;
            ViewBag.accionesId = new SelectList(db.Acciones, "Id", "nombre");
            ViewBag.personaId = new SelectList(db.Personas, "Id", "Nombre");
            return PartialView("_CreateVp", model);
            //      return View();
        }

        // POST: RegistroAcciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVp([Bind(Include = "Id,fechaAlta,fechcaBaja,comentario,personaId,accionesId,estadoHab")] RegistroAccione registroAccione)
        {
            registroAccione.fechaAlta = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.RegistroAcciones.Add(registroAccione);
                string url = Url.Action("IndexVp", "RegistroAcciones", new { id = registroAccione.personaId });
                db.SaveChanges();
                return Json(new { success = true, url = url });
//                return RedirectToAction("Index");
            }

            ViewBag.accionesId = new SelectList(db.Acciones, "Id", "nombre", registroAccione.accionesId);
            ViewBag.personaId = new SelectList(db.Personas, "Id", "Nombre", registroAccione.personaId);
            return PartialView("_CreateVp", registroAccione);
 //           return View(registroAccione);
        }

        // GET: RegistroAcciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroAccione registroAccione = db.RegistroAcciones.Find(id);
            if (registroAccione == null)
            {
                return HttpNotFound();
            }
            ViewBag.accionesId = new SelectList(db.Acciones, "Id", "nombre", registroAccione.accionesId);
            ViewBag.personaId = new SelectList(db.Personas, "Id", "Nombre", registroAccione.personaId);
            return View(registroAccione);
        }

        // POST: RegistroAcciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,fechaAlta,fechcaBaja,comentario,personaId,accionesId,estadoHab")] RegistroAccione registroAccione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroAccione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accionesId = new SelectList(db.Acciones, "Id", "nombre", registroAccione.accionesId);
            ViewBag.personaId = new SelectList(db.Personas, "Id", "Nombre", registroAccione.personaId);
            return View(registroAccione);
        }


        public ActionResult EditVp(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroAccione registroAccione = db.RegistroAcciones.Find(id);
            if (registroAccione == null)
            {
                return HttpNotFound();
            }
            ViewBag.accionesId = new SelectList(db.Acciones, "Id", "nombre", registroAccione.accionesId);
            ViewBag.personaId = new SelectList(db.Personas, "Id", "Nombre", registroAccione.personaId);
            return PartialView("_EditVp", registroAccione);
        }

        // POST: RegistroAcciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditVp([Bind(Include = "Id,fechaAlta,fechcaBaja,comentario,personaId,accionesId,estadoHab")] RegistroAccione registroAccione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroAccione).State = EntityState.Modified;
                string url = Url.Action("IndexVp", "RegistroAcciones", new { id = registroAccione.personaId });
              try
                {
                  db.SaveChanges();
                  return Json(new { success = true, url = url });
                }
               catch (Exception ex)
               {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Direcciones", "Edit"));
               }

            }
            ViewBag.accionesId = new SelectList(db.Acciones, "Id", "nombre", registroAccione.accionesId);
            ViewBag.personaId = new SelectList(db.Personas, "Id", "Nombre", registroAccione.personaId);
            return PartialView("_EditVp", registroAccione);
            //return View(registroAccione);
        }
        // GET: RegistroAcciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroAccione registroAccione = db.RegistroAcciones.Find(id);
            if (registroAccione == null)
            {
                return HttpNotFound();
            }
            return View(registroAccione);
        }

        // POST: RegistroAcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroAccione registroAccione = db.RegistroAcciones.Find(id);
            db.RegistroAcciones.Remove(registroAccione);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteVp(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroAccione registroAccione = db.RegistroAcciones.Find(id);
            if (registroAccione == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeleteVp", registroAccione);
        }

        // POST: RegistroAcciones/Delete/5
        [HttpPost, ActionName("DeleteVp")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedVp(int id)
        {
            RegistroAccione registroAccione = db.RegistroAcciones.Find(id);
            try
            {
             string url = Url.Action("IndexVp", "RegistroAcciones", new { Id = registroAccione.personaId });
             db.RegistroAcciones.Remove(registroAccione);
             db.SaveChanges();
             return Json(new { success = true, url = url });
            }
             catch(Exception ex)
            {
              return View("ErrorDeleteDup", new HandleErrorInfo(ex, "Direcciones", "Delete"));
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
