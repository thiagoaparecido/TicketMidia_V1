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
    public class TB_TOT_MOD_PAGTOController : Controller
    {
        private TicketMidiaEntities db = new TicketMidiaEntities();

        // GET: TB_TOT_MOD_PAGTO
        public ActionResult Index()
        {
            var tB_TOT_MOD_PAGTO = db.TB_TOT_MOD_PAGTO.Include(t => t.TB_TOT_CATEG_ING);
            return View(tB_TOT_MOD_PAGTO.ToList());
        }

        // GET: TB_TOT_MOD_PAGTO/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_TOT_MOD_PAGTO tB_TOT_MOD_PAGTO = db.TB_TOT_MOD_PAGTO.Find(id);
            if (tB_TOT_MOD_PAGTO == null)
            {
                return HttpNotFound();
            }
            return View(tB_TOT_MOD_PAGTO);
        }

        // GET: TB_TOT_MOD_PAGTO/Create
        public ActionResult Create()
        {
            ViewBag.TCI_ID = new SelectList(db.TB_TOT_CATEG_ING, "TCI_ID", "TCI_ID");
            return View();
        }

        // POST: TB_TOT_MOD_PAGTO/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TMP_ID,TCI_ID,TMP_MOD_PAG,TMP_VLR_ARR")] TB_TOT_MOD_PAGTO tB_TOT_MOD_PAGTO)
        {
            if (ModelState.IsValid)
            {
                db.TB_TOT_MOD_PAGTO.Add(tB_TOT_MOD_PAGTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TCI_ID = new SelectList(db.TB_TOT_CATEG_ING, "TCI_ID", "TCI_ID", tB_TOT_MOD_PAGTO.TCI_ID);
            return View(tB_TOT_MOD_PAGTO);
        }

        // GET: TB_TOT_MOD_PAGTO/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_TOT_MOD_PAGTO tB_TOT_MOD_PAGTO = db.TB_TOT_MOD_PAGTO.Find(id);
            if (tB_TOT_MOD_PAGTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.TCI_ID = new SelectList(db.TB_TOT_CATEG_ING, "TCI_ID", "TCI_ID", tB_TOT_MOD_PAGTO.TCI_ID);
            return View(tB_TOT_MOD_PAGTO);
        }

        // POST: TB_TOT_MOD_PAGTO/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TMP_ID,TCI_ID,TMP_MOD_PAG,TMP_VLR_ARR")] TB_TOT_MOD_PAGTO tB_TOT_MOD_PAGTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_TOT_MOD_PAGTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TCI_ID = new SelectList(db.TB_TOT_CATEG_ING, "TCI_ID", "TCI_ID", tB_TOT_MOD_PAGTO.TCI_ID);
            return View(tB_TOT_MOD_PAGTO);
        }

        // GET: TB_TOT_MOD_PAGTO/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_TOT_MOD_PAGTO tB_TOT_MOD_PAGTO = db.TB_TOT_MOD_PAGTO.Find(id);
            if (tB_TOT_MOD_PAGTO == null)
            {
                return HttpNotFound();
            }
            return View(tB_TOT_MOD_PAGTO);
        }

        // POST: TB_TOT_MOD_PAGTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TB_TOT_MOD_PAGTO tB_TOT_MOD_PAGTO = db.TB_TOT_MOD_PAGTO.Find(id);
            db.TB_TOT_MOD_PAGTO.Remove(tB_TOT_MOD_PAGTO);
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
