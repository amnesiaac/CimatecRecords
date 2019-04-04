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
    public class PublicacoesController : Controller
    {
        private CimatecRecordsContext db = new CimatecRecordsContext();

        // GET: Publicacoes
        public ActionResult Index()
        {
            var publicacaos = db.Publicacaos.Include(p => p.Letra);
            return View(publicacaos.ToList());
        }

        // GET: Publicacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacao publicacao = db.Publicacaos.Find(id);
            if (publicacao == null)
            {
                return HttpNotFound();
            }
            return View(publicacao);
        }

        // GET: Publicacoes/Create
        public ActionResult Create()
        {
            ViewBag.Fk_Letra = new SelectList(db.Letras, "Pk_Letra", "Titulo");
            return View();
        }

        // POST: Publicacoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PK_Publicacao,Data,Fk_Letra")] Publicacao publicacao)
        {
            if (ModelState.IsValid)
            {
                Letra letra = db.Letras.Find(publicacao.Fk_Letra);
                publicacao.Letra = letra;
                if (publicacao.validaPublicacao())
                {
                    db.Publicacaos.Add(publicacao);
                    db.SaveChanges();
                    letra.Publicada = true;
                    db.Entry(letra).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Fk_Letra = new SelectList(db.Letras, "Pk_Letra", "Titulo", publicacao.Fk_Letra);
            return View(publicacao);
        }

        // GET: Publicacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacao publicacao = db.Publicacaos.Find(id);
            if (publicacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fk_Letra = new SelectList(db.Letras, "Pk_Letra", "Titulo", publicacao.Fk_Letra);
            return View(publicacao);
        }

        // POST: Publicacoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PK_Publicacao,Data,Fk_Letra")] Publicacao publicacao)
        {
            if (ModelState.IsValid)
            {
                
                
                db.Entry(publicacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fk_Letra = new SelectList(db.Letras, "Pk_Letra", "Titulo", publicacao.Fk_Letra);
            return View(publicacao);
        }

        // GET: Publicacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacao publicacao = db.Publicacaos.Find(id);
            if (publicacao == null)
            {
                return HttpNotFound();
            }
            return View(publicacao);
        }

        // POST: Publicacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publicacao publicacao = db.Publicacaos.Find(id);
            db.Publicacaos.Remove(publicacao);
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
