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
    public class TB_TOT_CATEG_INGController : Controller
    {
        private TicketMidiaEntities db = new TicketMidiaEntities();

        // GET: TB_TOT_CATEG_ING
        public ActionResult Index()
        {
            var tB_TOT_CATEG_ING = db.TB_TOT_CATEG_ING.Include(t => t.TB_TOT_TP_ASSENTO);
            return View(tB_TOT_CATEG_ING.ToList());
        }

        // GET: TB_TOT_CATEG_ING/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_TOT_CATEG_ING tB_TOT_CATEG_ING = db.TB_TOT_CATEG_ING.Find(id);
            if (tB_TOT_CATEG_ING == null)
            {
                return HttpNotFound();
            }
            return View(tB_TOT_CATEG_ING);
        }

        // GET: TB_TOT_CATEG_ING/Create
        public ActionResult Create()
        {
            ViewBag.TTA_ID = new SelectList(db.TB_TOT_TP_ASSENTO, "TTA_ID", "TTA_TP_ASSENTO");
            return View();
        }

        // POST: TB_TOT_CATEG_ING/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TCI_ID,TTA_ID,TCI_QTD_ESPECT")] TB_TOT_CATEG_ING tB_TOT_CATEG_ING)
        {
            if (ModelState.IsValid)
            {
                db.TB_TOT_CATEG_ING.Add(tB_TOT_CATEG_ING);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TTA_ID = new SelectList(db.TB_TOT_TP_ASSENTO, "TTA_ID", "TTA_TP_ASSENTO", tB_TOT_CATEG_ING.TTA_ID);
            return View(tB_TOT_CATEG_ING);
        }

        // GET: TB_TOT_CATEG_ING/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_TOT_CATEG_ING tB_TOT_CATEG_ING = db.TB_TOT_CATEG_ING.Find(id);
            if (tB_TOT_CATEG_ING == null)
            {
                return HttpNotFound();
            }
            ViewBag.TTA_ID = new SelectList(db.TB_TOT_TP_ASSENTO, "TTA_ID", "TTA_TP_ASSENTO", tB_TOT_CATEG_ING.TTA_ID);
            return View(tB_TOT_CATEG_ING);
        }

        // POST: TB_TOT_CATEG_ING/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TCI_ID,TTA_ID,TCI_QTD_ESPECT")] TB_TOT_CATEG_ING tB_TOT_CATEG_ING)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_TOT_CATEG_ING).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TTA_ID = new SelectList(db.TB_TOT_TP_ASSENTO, "TTA_ID", "TTA_TP_ASSENTO", tB_TOT_CATEG_ING.TTA_ID);
            return View(tB_TOT_CATEG_ING);
        }

        // GET: TB_TOT_CATEG_ING/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_TOT_CATEG_ING tB_TOT_CATEG_ING = db.TB_TOT_CATEG_ING.Find(id);
            if (tB_TOT_CATEG_ING == null)
            {
                return HttpNotFound();
            }
            return View(tB_TOT_CATEG_ING);
        }

        // POST: TB_TOT_CATEG_ING/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TB_TOT_CATEG_ING tB_TOT_CATEG_ING = db.TB_TOT_CATEG_ING.Find(id);
            db.TB_TOT_CATEG_ING.Remove(tB_TOT_CATEG_ING);
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
