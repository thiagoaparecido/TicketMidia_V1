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
    public class TB_SESSAO_ANCINEController : Controller
    {
        private TicketMidiaEntities db = new TicketMidiaEntities();

        // GET: TB_SESSAO_ANCINE
        public ActionResult Index()
        {
            var tB_SESSAO_ANCINE = db.TB_SESSAO_ANCINE.Include(t => t.TB_BILHETERIA).Include(t => t.TB_FILME).Include(t => t.TB_SALA);
            return View(tB_SESSAO_ANCINE.ToList());
        }

        // GET: TB_SESSAO_ANCINE/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_SESSAO_ANCINE tB_SESSAO_ANCINE = db.TB_SESSAO_ANCINE.Find(id);
            if (tB_SESSAO_ANCINE == null)
            {
                return HttpNotFound();
            }
            return View(tB_SESSAO_ANCINE);
        }

        // GET: TB_SESSAO_ANCINE/Create
        public ActionResult Create()
        {
            ViewBag.BIL_ID = new SelectList(db.TB_BILHETERIA, "BIL_ID", "EMP_CD_ANCINE");
            ViewBag.FIL_CD_ANCINE = new SelectList(db.TB_FILME, "FIL_CD_ANCINE", "FIL_NM");
            ViewBag.SAL_CD_ANCINE = new SelectList(db.TB_SALA, "SAL_CD_ANCINE", "EMP_CD_ANCINE");
            return View();
        }

        // POST: TB_SESSAO_ANCINE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SEA_ID,BIL_ID,SAL_CD_ANCINE,FIL_CD_ANCINE,SEA_DT_HR_INICIO,SEA_MODAL,SEA_FIL_NM,SEA_FIL_TP_TELA,SEA_FIL_DIGITAL,SEA_FIL_TP_PROJECAO,SEA_FIL_AUDIO,SEA_FIL_LEG,SEA_FIL_PRO_LIBRA,SEA_FIL_LEG_DESC_CC,SEA_FIL_AUDIO_DESC,SEA_DIS_CNPJ,SEA_DIS_NM,SEA_VRE_CNPJ,SEA_RZ_SOCIAL")] TB_SESSAO_ANCINE tB_SESSAO_ANCINE)
        {
            if (ModelState.IsValid)
            {
                db.TB_SESSAO_ANCINE.Add(tB_SESSAO_ANCINE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BIL_ID = new SelectList(db.TB_BILHETERIA, "BIL_ID", "EMP_CD_ANCINE", tB_SESSAO_ANCINE.BIL_ID);
            ViewBag.FIL_CD_ANCINE = new SelectList(db.TB_FILME, "FIL_CD_ANCINE", "FIL_NM", tB_SESSAO_ANCINE.FIL_CD_ANCINE);
            ViewBag.SAL_CD_ANCINE = new SelectList(db.TB_SALA, "SAL_CD_ANCINE", "EMP_CD_ANCINE", tB_SESSAO_ANCINE.SAL_CD_ANCINE);
            return View(tB_SESSAO_ANCINE);
        }

        // GET: TB_SESSAO_ANCINE/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_SESSAO_ANCINE tB_SESSAO_ANCINE = db.TB_SESSAO_ANCINE.Find(id);
            if (tB_SESSAO_ANCINE == null)
            {
                return HttpNotFound();
            }
            ViewBag.BIL_ID = new SelectList(db.TB_BILHETERIA, "BIL_ID", "EMP_CD_ANCINE", tB_SESSAO_ANCINE.BIL_ID);
            ViewBag.FIL_CD_ANCINE = new SelectList(db.TB_FILME, "FIL_CD_ANCINE", "FIL_NM", tB_SESSAO_ANCINE.FIL_CD_ANCINE);
            ViewBag.SAL_CD_ANCINE = new SelectList(db.TB_SALA, "SAL_CD_ANCINE", "EMP_CD_ANCINE", tB_SESSAO_ANCINE.SAL_CD_ANCINE);
            return View(tB_SESSAO_ANCINE);
        }

        // POST: TB_SESSAO_ANCINE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SEA_ID,BIL_ID,SAL_CD_ANCINE,FIL_CD_ANCINE,SEA_DT_HR_INICIO,SEA_MODAL,SEA_FIL_NM,SEA_FIL_TP_TELA,SEA_FIL_DIGITAL,SEA_FIL_TP_PROJECAO,SEA_FIL_AUDIO,SEA_FIL_LEG,SEA_FIL_PRO_LIBRA,SEA_FIL_LEG_DESC_CC,SEA_FIL_AUDIO_DESC,SEA_DIS_CNPJ,SEA_DIS_NM,SEA_VRE_CNPJ,SEA_RZ_SOCIAL")] TB_SESSAO_ANCINE tB_SESSAO_ANCINE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_SESSAO_ANCINE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BIL_ID = new SelectList(db.TB_BILHETERIA, "BIL_ID", "EMP_CD_ANCINE", tB_SESSAO_ANCINE.BIL_ID);
            ViewBag.FIL_CD_ANCINE = new SelectList(db.TB_FILME, "FIL_CD_ANCINE", "FIL_NM", tB_SESSAO_ANCINE.FIL_CD_ANCINE);
            ViewBag.SAL_CD_ANCINE = new SelectList(db.TB_SALA, "SAL_CD_ANCINE", "EMP_CD_ANCINE", tB_SESSAO_ANCINE.SAL_CD_ANCINE);
            return View(tB_SESSAO_ANCINE);
        }

        // GET: TB_SESSAO_ANCINE/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_SESSAO_ANCINE tB_SESSAO_ANCINE = db.TB_SESSAO_ANCINE.Find(id);
            if (tB_SESSAO_ANCINE == null)
            {
                return HttpNotFound();
            }
            return View(tB_SESSAO_ANCINE);
        }

        // POST: TB_SESSAO_ANCINE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            TB_SESSAO_ANCINE tB_SESSAO_ANCINE = db.TB_SESSAO_ANCINE.Find(id);
            db.TB_SESSAO_ANCINE.Remove(tB_SESSAO_ANCINE);
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
