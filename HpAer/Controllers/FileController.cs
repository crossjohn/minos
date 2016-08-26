using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HpAer.Models;

namespace HpAer.Controllers
{
    public class FileController : Controller
    {
        private HpAerDbEntities db = new HpAerDbEntities();
        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}