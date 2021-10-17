using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PfizerKidsLab;

namespace PfizerKidsLab.Controllers
{
    public class vacunasController : Controller
    {
        private pfizerKidsHomeEntities db = new pfizerKidsHomeEntities();

        // GET: vacunas
        public ActionResult Index()
        {
            return View(db.vacuna.ToList());
        }

        // GET: vacunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacuna vacuna = db.vacuna.Find(id);
            if (vacuna == null)
            {
                return HttpNotFound();
            }
            return View(vacuna);
        }

        // GET: vacunas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: vacunas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVacuna,modelo,lote,fechaVencimiento")] vacuna vacuna)
        {
            if (ModelState.IsValid)
            {
                db.vacuna.Add(vacuna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vacuna);
        }

        // GET: vacunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacuna vacuna = db.vacuna.Find(id);
            if (vacuna == null)
            {
                return HttpNotFound();
            }
            return View(vacuna);
        }

        // POST: vacunas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVacuna,modelo,lote,fechaVencimiento")] vacuna vacuna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacuna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vacuna);
        }

        // GET: vacunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacuna vacuna = db.vacuna.Find(id);
            if (vacuna == null)
            {
                return HttpNotFound();
            }
            return View(vacuna);
        }

        // POST: vacunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vacuna vacuna = db.vacuna.Find(id);
            db.vacuna.Remove(vacuna);
            db.SaveChanges();
            return RedirectToAction("Index");
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
