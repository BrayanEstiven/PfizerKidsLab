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
    public class infantesController : Controller
    {
        private pfizerKidsHomeEntities db = new pfizerKidsHomeEntities();

        // GET: infantes
        public ActionResult Index()
        {
            var infante = db.infante.Include(i => i.persona);
            return View(infante.ToList());
        }

        // GET: infantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            infante infante = db.infante.Find(id);
            if (infante == null)
            {
                return HttpNotFound();
            }
            return View(infante);
        }

        // GET: infantes/Create
        public ActionResult Create()
        {
            ViewBag.idPersona = new SelectList(db.persona, "idPersona", "identificacion");
            return View();
        }

        // POST: infantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idInfante,numeroVacunacion,eps,idPersona")] infante infante)
        {
            if (ModelState.IsValid)
            {
                db.infante.Add(infante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPersona = new SelectList(db.persona, "idPersona", "identificacion", infante.idPersona);
            return View(infante);
        }

        // GET: infantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            infante infante = db.infante.Find(id);
            if (infante == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPersona = new SelectList(db.persona, "idPersona", "identificacion", infante.idPersona);
            return View(infante);
        }

        // POST: infantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idInfante,numeroVacunacion,eps,idPersona")] infante infante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(infante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPersona = new SelectList(db.persona, "idPersona", "identificacion", infante.idPersona);
            return View(infante);
        }

        // GET: infantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            infante infante = db.infante.Find(id);
            if (infante == null)
            {
                return HttpNotFound();
            }
            return View(infante);
        }

        // POST: infantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            infante infante = db.infante.Find(id);
            db.infante.Remove(infante);
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
