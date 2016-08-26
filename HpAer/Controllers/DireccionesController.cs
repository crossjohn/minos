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
    public class DireccionesController : Controller
    {
        private HpAerDbEntities db = new HpAerDbEntities();

        private IDireccionRepository _repository;
        public DireccionesController() : this(new DireccionRepository())
        {
        }
 
        // GET: Direcciones

         public ActionResult IndexVp(int id)
         {
             ViewBag.PersonaId= id;
             var direccions = db.Direccions.Where(d => d.personaId == id).OrderBy(d => d.Barrio.nombre).Include(d => d.Barrio).Include(d => d.Calle).Include(d => d.Localidad).Include(d => d.Pais).Include(d => d.Provincia).Include(d => d.Incidente).Include(d => d.Persona).Include(d => d.Veterinaria);
             return PartialView("_IndexVp", direccions.ToList());
             //  return View(direccions.ToList());
         }
         public ActionResult Index()
         {
             var direccions = db.Direccions.Include(d => d.Barrio).Include(d => d.Calle).Include(d => d.Localidad).Include(d => d.Pais).Include(d => d.Provincia);
             return View(direccions.ToList());
         }

        // GET: Direcciones/Create
        public ActionResult CreateVp(int PersonaId)
        {

            Direccion model = new Direccion();
            model.personaId = PersonaId;
            var direccion = db.Direccions.Where(d => d.personaId == PersonaId);
            if (direccion.Count() > 0)
            {
                 //return PartialView("_Alerta", new { msg = "Existe una direccion registrada" });
                return PartialView("_Alerta");
            }
            ViewBag.calleId = new SelectList(db.Calles, "Id", "calle_nombre");
      
            model.AvailablePaises.Add(new SelectListItem { Text = "-Seleccione un Valor -", Value = "Selects items" });
            var paises = _repository.GetAllPaises();
            foreach (var pais in paises)
            {
                model.AvailablePaises.Add(new SelectListItem()
                {
                    Text = pais.pais_nombre,
                    Value = pais.Id.ToString()
                });
            }
            
            return PartialView("_CreateVp", model);

/*            return View();*/
        }

        public ActionResult Create()
        {
            /*        ViewBag.barrioId = new SelectList(db.Barrios, "Id", "nombre");
            
                    ViewBag.localidadId = new SelectList(db.Localidads, "Id", "nombre");
                    ViewBag.paisId = new SelectList(db.Paises, "Id", "pais_nombre");
                    ViewBag.provinciaId = new SelectList(db.Provincias, "Id", "nombre"); 
             */
            ViewBag.calleId = new SelectList(db.Calles, "Id", "calle_nombre");

            Direccion model = new Direccion();
            model.AvailablePaises.Add(new SelectListItem { Text = "-Seleccione un Valor -", Value = "Selects items" });
            var paises = _repository.GetAllPaises();
            foreach (var pais in paises)
            {
                model.AvailablePaises.Add(new SelectListItem()
                {
                    Text = pais.pais_nombre,
                    Value = pais.Id.ToString()
                });
            }
            return View(model);

            /*            return View();*/
        }

        
        // POST: Direcciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVp([Bind(Include = "Id,paisId,provinciaId,localidadId,barrioId,calleId,numero,piso,Torre,depto,personaId,veterinariaId,incidenteId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Direccions.Add(direccion);
                string url = Url.Action("IndexVp", "Direcciones", new { Id = direccion.personaId });
                try
                {
           
                db.SaveChanges();
                return Json(new { success = true, url = url });
    
                }
  
                 catch(Exception ex)
               {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Direcciones", "Create"));
                }
            }
   
            ViewBag.barrioId = new SelectList(db.Barrios, "Id", "nombre", direccion.barrioId);
            ViewBag.calleId = new SelectList(db.Calles, "Id", "calle_nombre", direccion.calleId);
            ViewBag.localidadId = new SelectList(db.Localidads, "Id", "nombre", direccion.localidadId);
            ViewBag.paisId = new SelectList(db.Paises, "Id", "pais_nombre", direccion.paisId);
            ViewBag.provinciaId = new SelectList(db.Provincias, "Id", "nombre", direccion.provinciaId);
           // return View(direccion);
            return PartialView("_CreateVp", direccion);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,paisId,provinciaId,localidadId,barrioId,calleId,numero,piso,Torre,depto")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Direccions.Add(direccion);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View("ErrorCreateDup", new HandleErrorInfo(ex, "Direcciones", "Create"));
                }

            }

            ViewBag.barrioId = new SelectList(db.Barrios, "Id", "nombre", direccion.barrioId);
            ViewBag.calleId = new SelectList(db.Calles, "Id", "calle_nombre", direccion.calleId);
            ViewBag.localidadId = new SelectList(db.Localidads, "Id", "nombre", direccion.localidadId);
            ViewBag.paisId = new SelectList(db.Paises, "Id", "pais_nombre", direccion.paisId);
            ViewBag.provinciaId = new SelectList(db.Provincias, "Id", "nombre", direccion.provinciaId);
            return View(direccion);
        }
        // GET: Direcciones/Edit/5
        public ActionResult EditVp(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccions.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
          
            ViewBag.paisId = new SelectList(db.Paises, "Id", "pais_nombre", direccion.paisId);
            ViewBag.provinciaId = new SelectList(GetAllProvinciasByPaisId(direccion.paisId), "Id", "nombre", direccion.provinciaId);
            ViewBag.barrioId = new SelectList(GetAllBarriosByLocalidadId(direccion.localidadId), "Id", "nombre", direccion.barrioId);
            ViewBag.calleId = new SelectList(db.Calles, "Id", "calle_nombre", direccion.calleId);
            ViewBag.localidadId = new SelectList(GetAllLocalidadesByProvinciaId(direccion.provinciaId), "Id", "nombre", direccion.localidadId);
            return PartialView("_EditVp", direccion);
         //   return View(direccion);
        }

        // POST: Direcciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditVp([Bind(Include = "Id,paisId,provinciaId,localidadId,barrioId,calleId,numero,piso,Torre,depto,personaId,veterinariaId,incidenteId")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccion).State = EntityState.Modified;
                string url = Url.Action("IndexVp", "Direcciones", new { Id = direccion.personaId});
                try
                {
                db.SaveChanges();           
                return Json(new { success = true, url = url });
            //    return RedirectToAction("Index");
                }
                 catch(Exception ex)
                {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Direcciones", "Edit"));
                }

            }
            ViewBag.paisId = new SelectList(db.Paises, "Id", "pais_nombre", direccion.paisId);
            ViewBag.provinciaId = new SelectList(GetAllProvinciasByPaisId(direccion.paisId), "Id", "nombre", direccion.provinciaId);
            ViewBag.barrioId = new SelectList(GetAllBarriosByLocalidadId(direccion.localidadId), "Id", "nombre", direccion.barrioId);
            ViewBag.calleId = new SelectList(db.Calles, "Id", "calle_nombre", direccion.calleId);
            ViewBag.localidadId = new SelectList(GetAllLocalidadesByProvinciaId(direccion.provinciaId), "Id", "nombre", direccion.localidadId);
            return PartialView("_EditVp", direccion);
            //return View(direccion);
        }

        // GET: Direcciones/Delete/5
        public ActionResult DeleteVp(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccions.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeleteVp", direccion);
           // return View(direccion);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("DeleteVp")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedVp(int id)
        {

            Direccion direccion = db.Direccions.Find(id);
            string url = Url.Action("IndexVp", "Direcciones", new { Id = direccion.personaId });
            db.Direccions.Remove(direccion);
            try
            {
            db.SaveChanges();
            return Json(new { success = true, url = url });
        
         //   return RedirectToAction("Index");
         //   return RedirectToAction("Index", new { personaId = direccion.personaId });
            }
             catch(Exception ex)
            {
              return View("ErrorDeleteDup", new HandleErrorInfo(ex, "Direcciones", "Delete"));
            }
        }

        // GET: Direcciones/Details/5
        public ActionResult DetailsVp(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccions.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DetailsVp", direccion);
   //         return View(direccion);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccions.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccions.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }

            ViewBag.paisId = new SelectList(db.Paises, "Id", "pais_nombre", direccion.paisId);
            ViewBag.provinciaId = new SelectList(GetAllProvinciasByPaisId(direccion.paisId), "Id", "nombre", direccion.provinciaId);
            ViewBag.barrioId = new SelectList(GetAllBarriosByLocalidadId(direccion.localidadId), "Id", "nombre", direccion.barrioId);
            ViewBag.calleId = new SelectList(db.Calles, "Id", "calle_nombre", direccion.calleId);
            ViewBag.localidadId = new SelectList(GetAllLocalidadesByProvinciaId(direccion.provinciaId), "Id", "nombre", direccion.localidadId);


            return View(direccion);
        }

        // POST: Direcciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,paisId,provinciaId,localidadId,barrioId,calleId,numero,piso,Torre,depto")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(direccion).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View("ErrorCreateDup", new HandleErrorInfo(ex, "Direcciones", "Edit"));
                }

            }
            ViewBag.paisId = new SelectList(db.Paises, "Id", "pais_nombre", direccion.paisId);
            ViewBag.provinciaId = new SelectList(GetAllProvinciasByPaisId(direccion.paisId), "Id", "nombre", direccion.provinciaId);
            ViewBag.barrioId = new SelectList(GetAllBarriosByLocalidadId(direccion.localidadId), "Id", "nombre", direccion.barrioId);
            ViewBag.calleId = new SelectList(db.Calles, "Id", "calle_nombre", direccion.calleId);
            ViewBag.localidadId = new SelectList(GetAllLocalidadesByProvinciaId(direccion.provinciaId), "Id", "nombre", direccion.localidadId);
            return View(direccion);
        }

        // GET: Direcciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = db.Direccions.Find(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Direccion direccion = db.Direccions.Find(id);
                db.Direccions.Remove(direccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("ErrorDeleteDup", new HandleErrorInfo(ex, "Direcciones", "Delete"));
            }

        }
        public DireccionesController(IDireccionRepository repository)
        {
            _repository = repository;
        }

        public IList<Pais> GetAllpaises()
        {
            var query = from paises in db.Paises
                        select paises;
            var content = query.ToList<Pais>();
            return content;
        }

        public IList<Provincia> GetAllProvinciasByPaisId(int paisId)
        {
            var query = from provincias in db.Provincias
                        where provincias.paisId == paisId
                        select provincias;
            var content = query.ToList<Provincia>();
            return content;
        }

        public IList<Localidad> GetAllLocalidadesByProvinciaId(int provinciaId)
        {
            var query = from localidades in db.Localidads
                        where localidades.provinciaId == provinciaId
                        select localidades;
            var content = query.ToList<Localidad>();
            return content;
        }

        public IList<Barrio> GetAllBarriosByLocalidadId(int localidadId)
        {
            var query = from barrios in db.Barrios
                        where barrios.localidadId == localidadId
                        select barrios;
            var content = query.ToList<Barrio>();
            return content;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetProvinciasByPaisId(string paisId)
        {
            if (String.IsNullOrEmpty(paisId))
            {
                throw new ArgumentNullException("paisId");
            }
            int id = 0;
            bool isValid = Int32.TryParse(paisId, out id);
            var provincias = _repository.GetAllProvinciasByPaisId(id);

            var result = (from s in provincias
                          select new
                          {
                              id = s.Id,
                              name = s.nombre
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetLocalidadesByProvinciaId(string provinciaId)
        {
            if (String.IsNullOrEmpty(provinciaId))
            {
                throw new ArgumentNullException("provinciaId");
            }
            int id = 0;
            bool isValid = Int32.TryParse(provinciaId, out id);
            var localidades = _repository.GetAllLocalidadesByProvinciaId(id);
            var result = (from s in localidades
                          select new
                          {
                              id = s.Id,
                              name = s.nombre
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetBarriosByLocalidadId(string localidadId)
        {
            if (String.IsNullOrEmpty(localidadId))
            {
                throw new ArgumentNullException("localidadId");
            }
            int id = 0;
            bool isValid = Int32.TryParse(localidadId, out id);
            var barrios = _repository.GetAllBarriosByLocalidadId(id);
            var result = (from s in barrios
                          select new
                          {
                              id = s.Id,
                              name = s.nombre
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
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
