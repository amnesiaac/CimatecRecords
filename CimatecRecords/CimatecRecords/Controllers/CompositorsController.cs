using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CimatecRecords.Models;

namespace CimatecRecords.Controllers
{
    public class CompositorsController : Controller
    {
        private CimatecRecordsContext db = new CimatecRecordsContext();

        // GET: Compositors
        public ActionResult Index()
        {
            var compositors = db.Compositors.Include(c => c.Responsavel);
            return View(compositors.ToList());
        }

        // GET: Compositors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compositor compositor = db.Compositors.Find(id);
            if (compositor == null)
            {
                return HttpNotFound();
            }
            return View(compositor);
        }

        // GET: Compositors/Create
        public ActionResult Create()
        {
            ViewBag.Fk_Responsavel = new SelectList(db.Responsavels, "Pk_Responsavel", "Nome");
            return View();
        }

        // POST: Compositors/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pk_Compositor,Nome,Cpf,Idade,Fk_Responsavel")] Compositor compositor)
        {
            if (ModelState.IsValid)
            {
                db.Compositors.Add(compositor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fk_Responsavel = new SelectList(db.Responsavels, "Pk_Responsavel", "Nome", compositor.Fk_Responsavel);
            return View(compositor);
        }

        // GET: Compositors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compositor compositor = db.Compositors.Find(id);
            if (compositor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fk_Responsavel = new SelectList(db.Responsavels, "Pk_Responsavel", "Nome", compositor.Fk_Responsavel);
            return View(compositor);
        }

        // POST: Compositors/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pk_Compositor,Nome,Cpf,Idade,Fk_Responsavel")] Compositor compositor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compositor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fk_Responsavel = new SelectList(db.Responsavels, "Pk_Responsavel", "Nome", compositor.Fk_Responsavel);
            return View(compositor);
        }

        // GET: Compositors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compositor compositor = db.Compositors.Find(id);
            if (compositor == null)
            {
                return HttpNotFound();
            }
            return View(compositor);
        }

        // POST: Compositors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compositor compositor = db.Compositors.Find(id);
            db.Compositors.Remove(compositor);
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
