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
    public class citaVacunasController : Controller
    {
        private pfizerKidsHomeEntities db = new pfizerKidsHomeEntities();

        // GET: citaVacunas
        public ActionResult Index()
        {
            var citaVacuna = db.citaVacuna.Include(c => c.auxiliar).Include(c => c.infante).Include(c => c.vacuna);
            return View(citaVacuna.ToList());
        }

        // GET: citaVacunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citaVacuna citaVacuna = db.citaVacuna.Find(id);
            if (citaVacuna == null)
            {
                return HttpNotFound();
            }
            return View(citaVacuna);
        }

        // GET: citaVacunas/Create
        public ActionResult Create()
        {
            ViewBag.idAuxiliar = new SelectList(db.auxiliar, "idAuxiliar", "tarjetaProfesional");
            ViewBag.idInfante = new SelectList(db.infante, "idInfante", "eps");
            ViewBag.idVacuna = new SelectList(db.vacuna, "idVacuna", "modelo");
            return View();
        }

        // POST: citaVacunas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCitaVacuna,fecha,direccion,telefono,idInfante,idAuxiliar,idVacuna")] citaVacuna citaVacuna)
        {
            if (ModelState.IsValid)
            {
                db.citaVacuna.Add(citaVacuna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAuxiliar = new SelectList(db.auxiliar, "idAuxiliar", "tarjetaProfesional", citaVacuna.idAuxiliar);
            ViewBag.idInfante = new SelectList(db.infante, "idInfante", "eps", citaVacuna.idInfante);
            ViewBag.idVacuna = new SelectList(db.vacuna, "idVacuna", "modelo", citaVacuna.idVacuna);
            return View(citaVacuna);
        }

        // GET: citaVacunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citaVacuna citaVacuna = db.citaVacuna.Find(id);
            if (citaVacuna == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAuxiliar = new SelectList(db.auxiliar, "idAuxiliar", "tarjetaProfesional", citaVacuna.idAuxiliar);
            ViewBag.idInfante = new SelectList(db.infante, "idInfante", "eps", citaVacuna.idInfante);
            ViewBag.idVacuna = new SelectList(db.vacuna, "idVacuna", "modelo", citaVacuna.idVacuna);
            return View(citaVacuna);
        }

        // POST: citaVacunas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCitaVacuna,fecha,direccion,telefono,idInfante,idAuxiliar,idVacuna")] citaVacuna citaVacuna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citaVacuna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAuxiliar = new SelectList(db.auxiliar, "idAuxiliar", "tarjetaProfesional", citaVacuna.idAuxiliar);
            ViewBag.idInfante = new SelectList(db.infante, "idInfante", "eps", citaVacuna.idInfante);
            ViewBag.idVacuna = new SelectList(db.vacuna, "idVacuna", "modelo", citaVacuna.idVacuna);
            return View(citaVacuna);
        }

        // GET: citaVacunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            citaVacuna citaVacuna = db.citaVacuna.Find(id);
            if (citaVacuna == null)
            {
                return HttpNotFound();
            }
            return View(citaVacuna);
        }

        // POST: citaVacunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            citaVacuna citaVacuna = db.citaVacuna.Find(id);
            db.citaVacuna.Remove(citaVacuna);
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
