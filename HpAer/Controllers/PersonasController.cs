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
    public class PersonasController : Controller
    {
        private HpAerDbEntities db = new HpAerDbEntities();

        // GET: Personas

        [Authorize]
        public ActionResult Index()
        {
            return View(db.Personas.ToList());
        }


        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            //crea persona temporal para asignar direccion
            Persona persona = new Persona();
            persona.Nombre = "temporal ";
            persona.Apellido = "temporal";
            persona.fechaNac = Convert.ToDateTime("31/12/2999");
            persona.email = "temporal@temporal.com";
            persona.voluntario = false;
            persona.estadohab = false;
             if (ModelState.IsValid)
            {
                try
                {
                    db.Personas.Add(persona);
                    db.SaveChanges();     
                }
                catch (Exception ex)
                {
                    return View("ErrorCreateDup", new HandleErrorInfo(ex, "Personas", "Create"));
                }
 
             }

            return View(persona);

/*            return View();*/
        }
            
            
            

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,fechaNac,fechaAlta,fechaBaja,telefono,telefonoCel,puntaje,UsrId,email,estadoHab,voluntario")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                try
                {
           //         db.Personas.Add(persona);
                    db.Entry(persona).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View("ErrorCreateDup", new HandleErrorInfo(ex, "Personas", "Create"));
                }

             }

            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,fechaNac,fechaAlta,fechaBaja,telefono,telefonoCel,puntaje,UsrId,email,estadoHab,voluntario")] Persona persona)
        {
            if (ModelState.IsValid)
            {
             try
               {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View("ErrorCreateDup", new HandleErrorInfo(ex, "Personas", "Edit"));
                }
 
            }
            return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Personas.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
   //      try {
             Persona persona = db.Personas.Find(id);

             // Borra direccion  asignada
             //var direccion = db.Direccions.Where(d => d.personaId == persona.Id);
             //Direccion dir = persona.Direcciones.;
             if (persona.Direcciones.Count() > 0)
            {
                var v_dire = persona.Direcciones.First();
                Direccion direccion = db.Direccions.Find(v_dire.Id);
            //    direccion.personaId = null;
            //    db.Entry(persona).State = EntityState.Modified;
            //    db.SaveChanges();
                db.Direccions.Remove(direccion);
                db.SaveChanges();
             }
                //db.Entry(persona).State = EntityState.Modified;
                db.Personas.Remove(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
  //          }
  //           catch(Exception ex)
  //          {
  //           return View("ErrorDeleteRef", new HandleErrorInfo(ex, "Personas", "Delete"));
  //          }
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
