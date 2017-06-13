using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketMidia.Models;

namespace TicketMidia.Controllers
{
    public class TB_TOT_TP_ASSENTOController : Controller
    {
        private TicketMidiaEntities db = new TicketMidiaEntities();

        // GET: TB_TOT_TP_ASSENTO
        public ActionResult Index()
        {
            var tB_TOT_TP_ASSENTO = db.TB_TOT_TP_ASSENTO.Include(t => t.TB_SESSAO_ANCINE);
            return View(tB_TOT_TP_ASSENTO.ToList());
        }

        // GET: TB_TOT_TP_ASSENTO/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_TOT_TP_ASSENTO tB_TOT_TP_ASSENTO = db.TB_TOT_TP_ASSENTO.Find(id);
            if (tB_TOT_TP_ASSENTO == null)
            {
                return HttpNotFound();
            }
            return View(tB_TOT_TP_ASSENTO);
        }

        // GET: TB_TOT_TP_ASSENTO/Create
        public ActionResult Create()
        {
            ViewBag.SEA_ID = new SelectList(db.TB_SESSAO_ANCINE, "SEA_ID", "SAL_CD_ANCINE");
            return View();
        }

        // POST: TB_TOT_TP_ASSENTO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TTA_ID,SEA_ID,TTA_TP_ASSENTO,TTA_QTD_DISP")] TB_TOT_TP_ASSENTO tB_TOT_TP_ASSENTO)
        {
            if (ModelState.IsValid)
            {
                db.TB_TOT_TP_ASSENTO.Add(tB_TOT_TP_ASSENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SEA_ID = new SelectList(db.TB_SESSAO_ANCINE, "SEA_ID", "SAL_CD_ANCINE", tB_TOT_TP_ASSENTO.SEA_ID);
            return View(tB_TOT_TP_ASSENTO);
        }

        // GET: TB_TOT_TP_ASSENTO/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_TOT_TP_ASSENTO tB_TOT_TP_ASSENTO = db.TB_TOT_TP_ASSENTO.Find(id);
            if (tB_TOT_TP_ASSENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.SEA_ID = new SelectList(db.TB_SESSAO_ANCINE, "SEA_ID", "SAL_CD_ANCINE", tB_TOT_TP_ASSENTO.SEA_ID);
            return View(tB_TOT_TP_ASSENTO);
        }

        // POST: TB_TOT_TP_ASSENTO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TTA_ID,SEA_ID,TTA_TP_ASSENTO,TTA_QTD_DISP")] TB_TOT_TP_ASSENTO tB_TOT_TP_ASSENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_TOT_TP_ASSENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SEA_ID = new SelectList(db.TB_SESSAO_ANCINE, "SEA_ID", "SAL_CD_ANCINE", tB_TOT_TP_ASSENTO.SEA_ID);
            return View(tB_TOT_TP_ASSENTO);
        }

        // GET: TB_TOT_TP_ASSENTO/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_TOT_TP_ASSENTO tB_TOT_TP_ASSENTO = db.TB_TOT_TP_ASSENTO.Find(id);
            if (tB_TOT_TP_ASSENTO == null)
            {
                return HttpNotFound();
            }
            return View(tB_TOT_TP_ASSENTO);
        }

        // POST: TB_TOT_TP_ASSENTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TB_TOT_TP_ASSENTO tB_TOT_TP_ASSENTO = db.TB_TOT_TP_ASSENTO.Find(id);
            db.TB_TOT_TP_ASSENTO.Remove(tB_TOT_TP_ASSENTO);
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
