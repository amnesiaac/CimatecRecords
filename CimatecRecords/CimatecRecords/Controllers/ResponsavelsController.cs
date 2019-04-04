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
    public class ResponsavelsController : Controller
    {
        private CimatecRecordsContext db = new CimatecRecordsContext();

        // GET: Responsavels
        public ActionResult Index()
        {
            return View(db.Responsavels.ToList());
        }

        // GET: Responsavels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsavel responsavel = db.Responsavels.Find(id);
            if (responsavel == null)
            {
                return HttpNotFound();
            }
            return View(responsavel);
        }

        // GET: Responsavels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Responsavels/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pk_Responsavel,Nome,Idade")] Responsavel responsavel)
        {
            if (ModelState.IsValid)
            {
                db.Responsavels.Add(responsavel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(responsavel);
        }

        // GET: Responsavels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsavel responsavel = db.Responsavels.Find(id);
            if (responsavel == null)
            {
                return HttpNotFound();
            }
            return View(responsavel);
        }

        // POST: Responsavels/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pk_Responsavel,Nome,Idade")] Responsavel responsavel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsavel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(responsavel);
        }

        // GET: Responsavels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsavel responsavel = db.Responsavels.Find(id);
            if (responsavel == null)
            {
                return HttpNotFound();
            }
            return View(responsavel);
        }

        // POST: Responsavels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Responsavel responsavel = db.Responsavels.Find(id);
            db.Responsavels.Remove(responsavel);
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
