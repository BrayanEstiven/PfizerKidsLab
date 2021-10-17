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
    public class auxiliarsController : Controller
    {
        private pfizerKidsHomeEntities db = new pfizerKidsHomeEntities();

        // GET: auxiliars
        public ActionResult Index()
        {
            var auxiliar = db.auxiliar.Include(a => a.persona);
            return View(auxiliar.ToList());
        }

        // GET: auxiliars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auxiliar auxiliar = db.auxiliar.Find(id);
            if (auxiliar == null)
            {
                return HttpNotFound();
            }
            return View(auxiliar);
        }

        // GET: auxiliars/Create
        public ActionResult Create()
        {
            ViewBag.idPersona = new SelectList(db.persona, "idPersona", "identificacion");
            return View();
        }

        // POST: auxiliars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAuxiliar,tarjetaProfesional,idPersona")] auxiliar auxiliar)
        {
            if (ModelState.IsValid)
            {
                db.auxiliar.Add(auxiliar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPersona = new SelectList(db.persona, "idPersona", "identificacion", auxiliar.idPersona);
            return View(auxiliar);
        }

        // GET: auxiliars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auxiliar auxiliar = db.auxiliar.Find(id);
            if (auxiliar == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPersona = new SelectList(db.persona, "idPersona", "identificacion", auxiliar.idPersona);
            return View(auxiliar);
        }

        // POST: auxiliars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAuxiliar,tarjetaProfesional,idPersona")] auxiliar auxiliar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auxiliar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPersona = new SelectList(db.persona, "idPersona", "identificacion", auxiliar.idPersona);
            return View(auxiliar);
        }

        // GET: auxiliars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            auxiliar auxiliar = db.auxiliar.Find(id);
            if (auxiliar == null)
            {
                return HttpNotFound();
            }
            return View(auxiliar);
        }

        // POST: auxiliars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            auxiliar auxiliar = db.auxiliar.Find(id);
            db.auxiliar.Remove(auxiliar);
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
