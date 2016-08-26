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
    public class AnimalesController : Controller
    {
        private HpAerDbEntities db = new HpAerDbEntities();

        // GET: Animales
        public ActionResult Index()
        {
            var animals = db.Animals.Include(a => a.Raza).Include(a => a.Tamanio).Where(a => a.fechaBaja==null);
            return View(animals.ToList());
        }

        // GET: Animales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // Animal animal = db.Animals.Find(id);
            Animal animal = db.Animals.Include(s => s.Files).SingleOrDefault(s => s.Id == id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animales/Create
        public ActionResult Create()
        {
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre");
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre");
            return View();
        }

        // POST: Animales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,fechaNac,fechaAlta,edad,fechaBaja,caracteristicas,tamanioId,razaId,enAdopcion,Discriminator,enTratamiento,estadoHab,fechaAdop,fechaTratamiento")] Animal animal,HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
             
                 if(upload!=null && upload.ContentLength > 0)
                 {
                     var avatar = new HpAer.Models.File
                     {
                         FileName = System.IO.Path.GetFileName(upload.FileName),
                         FileType = (Int32) FileType.Avatar,
                         ContentType = upload.ContentType
                     };
                     using(var reader = new System.IO.BinaryReader(upload.InputStream))
                     {
                         avatar.Content = reader.ReadBytes(upload.ContentLength);
                     }
                     animal.Files = new List<HpAer.Models.File> { avatar };
                 }
                 try
                 {
                 if (animal.estadoHab == false)
                 {
                     if (animal.fechaBaja == null)
                     {
                         animal.fechaBaja = DateTime.Now;
                     }
                 }
                 else
                 {
                     animal.fechaBaja = null;
                 }

                 if (animal.enAdopcion == true)
                 {
                     if (animal.fechaAdop == null)
                     {
                         animal.fechaAdop = DateTime.Now;
                     }
                 }
                 else
                 {
                     animal.fechaAdop = null;
                 }

                 if (animal.enTratamiento == true)
                 {
                     if (animal.fechaTratamiento == null)
                     {
                         animal.fechaTratamiento = DateTime.Now;
                     }
                 }
                 else
                 {
                     animal.fechaTratamiento = null;
                 }

                 animal.fechaAlta = DateTime.Now;

                 db.Animals.Add(animal);
                 db.SaveChanges();
                 return RedirectToAction("Index");
                 }
                  catch(Exception ex)
                 {
                    return View("ErrorCreateDup", new HandleErrorInfo(ex, "Animales", "Create"));
                 }

            }

            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre", animal.razaId);
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre", animal.tamanioId);
            return View(animal);
        }

        // GET: Animales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Include(s => s.Files).SingleOrDefault(s => s.Id == id);
            //Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre", animal.razaId);
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre", animal.tamanioId);
            return View(animal);
        }

        // POST: Animales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,fechaNac,fechaAlta,edad,fechaBaja,caracteristicas,tamanioId,razaId,enAdopcion,Discriminator,enTratamiento,estadoHab,fechaAdop,fechaTratamiento")] Animal animal, HttpPostedFileBase upload)
        {
            var animalToUpdate = db.Animals.Find(animal.Id);
            animalToUpdate.nombre = animal.nombre;
            animalToUpdate.fechaNac = animal.fechaNac;
            animalToUpdate.caracteristicas = animal.caracteristicas;
            animalToUpdate.tamanioId = animal.tamanioId;
            animalToUpdate.razaId = animal.razaId;
            animalToUpdate.enAdopcion = animal.enAdopcion;
            animalToUpdate.edad = animal.edad;
            animalToUpdate.estadoHab = animal.estadoHab;
            animalToUpdate.enTratamiento = animal.enTratamiento;

            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    if (animalToUpdate.Files.Any(f => f.FileType == (Int32)FileType.Avatar))
                    {
                        db.Files.Remove(animalToUpdate.Files.First(f => f.FileType == (Int32)FileType.Avatar));
                    }
                    var avatar = new HpAer.Models.File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = (Int32) FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    animalToUpdate.Files = new List<HpAer.Models.File> { avatar };
                }
             try {
                 
                 if (animal.estadoHab == false)
                 {
                     if (animal.fechaBaja == null)
                     {
                         animalToUpdate.fechaBaja = DateTime.Now;
                     }
                 }
                 else
                 {
                     animalToUpdate.fechaBaja = null;
                 }

                 if (animal.enAdopcion == true)
                 {
                     if (animal.fechaAdop == null)
                     {
                         animalToUpdate.fechaAdop = DateTime.Now;
                     }
                 }
                 else
                 {
                     animalToUpdate.fechaAdop = null;
                 }

                 if (animal.enTratamiento == true)
                 {
                     if (animal.fechaTratamiento == null)
                     {
                         animalToUpdate.fechaTratamiento = DateTime.Now;
                     }
                 }
                 else
                 {
                     animalToUpdate.fechaTratamiento = null;
                 }

                 db.Entry(animalToUpdate).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("Index");
                 }
                   catch(Exception ex)
                 {
                   return View("ErrorCreateDup", new HandleErrorInfo(ex, "Animales", "Edit"));
               }
            }

            ViewBag.razaId = new SelectList(db.Razas, "Id", "nombre", animal.razaId);
            ViewBag.tamanioId = new SelectList(db.Tamanios, "Id", "nombre", animal.tamanioId);
            return View(animalToUpdate);
        }

        // GET: Animales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
         try {
             Animal animal = db.Animals.Find(id);
             db.Animals.Remove(animal);
             db.SaveChanges();
             return RedirectToAction("Index");
            }
             catch(Exception ex)
            {
             return View("ErrorDeleteRef", new HandleErrorInfo(ex, "Animales", "Delete"));
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
