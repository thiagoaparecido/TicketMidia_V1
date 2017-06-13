using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketMidia.Models;

namespace TicketMidia.Controllers
{
    public class TB_MENSAGEM_ANCINEController : Controller
    {
        private TicketMidiaEntities db = new TicketMidiaEntities();

        // GET: TB_MENSAGEM_ANCINE
        public async Task<ActionResult> Index(long BIL_ID)
        {
            var tB_MENSAGEM_ANCINE = db.TB_MENSAGEM_ANCINE.Include(t => t.TB_BILHETERIA).Include(t => t.TB_SESSAO_ANCINE).Where(T => T.BIL_ID == BIL_ID).OrderByDescending(t => t.MSA_DT_HORA_MSG);
            return View(await tB_MENSAGEM_ANCINE.ToListAsync());
        }

        // GET: TB_MENSAGEM_ANCINE/Details/5
        public async Task<ActionResult> Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_MENSAGEM_ANCINE tB_MENSAGEM_ANCINE = await db.TB_MENSAGEM_ANCINE.FindAsync(id);
            if (tB_MENSAGEM_ANCINE == null)
            {
                return HttpNotFound();
            }
            return View(tB_MENSAGEM_ANCINE);
        }

        // GET: TB_MENSAGEM_ANCINE/Create
        public ActionResult Create()
        {
            ViewBag.BIL_ID = new SelectList(db.TB_BILHETERIA, "BIL_ID", "EMP_CD_ANCINE");
            ViewBag.SEA_ID = new SelectList(db.TB_SESSAO_ANCINE, "SEA_ID", "SAL_CD_ANCINE");
            return View();
        }

        // POST: TB_MENSAGEM_ANCINE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MSA_DT_MSG,MSA_DT_HORA_MSG,BIL_ID,SEA_ID,SAL_CD_ANCINE,SEA_DT_HR_INICIO,MSA_TP_MSG,MSA_CD_MSG,MSA_TXT_MSG")] TB_MENSAGEM_ANCINE tB_MENSAGEM_ANCINE)
        {
            if (ModelState.IsValid)
            {
                db.TB_MENSAGEM_ANCINE.Add(tB_MENSAGEM_ANCINE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BIL_ID = new SelectList(db.TB_BILHETERIA, "BIL_ID", "EMP_CD_ANCINE", tB_MENSAGEM_ANCINE.BIL_ID);
            ViewBag.SEA_ID = new SelectList(db.TB_SESSAO_ANCINE, "SEA_ID", "SAL_CD_ANCINE", tB_MENSAGEM_ANCINE.SEA_ID);
            return View(tB_MENSAGEM_ANCINE);
        }

        // GET: TB_MENSAGEM_ANCINE/Edit/5
        public async Task<ActionResult> Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_MENSAGEM_ANCINE tB_MENSAGEM_ANCINE = await db.TB_MENSAGEM_ANCINE.FindAsync(id);
            if (tB_MENSAGEM_ANCINE == null)
            {
                return HttpNotFound();
            }
            ViewBag.BIL_ID = new SelectList(db.TB_BILHETERIA, "BIL_ID", "EMP_CD_ANCINE", tB_MENSAGEM_ANCINE.BIL_ID);
            ViewBag.SEA_ID = new SelectList(db.TB_SESSAO_ANCINE, "SEA_ID", "SAL_CD_ANCINE", tB_MENSAGEM_ANCINE.SEA_ID);
            return View(tB_MENSAGEM_ANCINE);
        }

        // POST: TB_MENSAGEM_ANCINE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MSA_DT_MSG,MSA_DT_HORA_MSG,BIL_ID,SEA_ID,SAL_CD_ANCINE,SEA_DT_HR_INICIO,MSA_TP_MSG,MSA_CD_MSG,MSA_TXT_MSG")] TB_MENSAGEM_ANCINE tB_MENSAGEM_ANCINE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_MENSAGEM_ANCINE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BIL_ID = new SelectList(db.TB_BILHETERIA, "BIL_ID", "EMP_CD_ANCINE", tB_MENSAGEM_ANCINE.BIL_ID);
            ViewBag.SEA_ID = new SelectList(db.TB_SESSAO_ANCINE, "SEA_ID", "SAL_CD_ANCINE", tB_MENSAGEM_ANCINE.SEA_ID);
            return View(tB_MENSAGEM_ANCINE);
        }

        // GET: TB_MENSAGEM_ANCINE/Delete/5
        public async Task<ActionResult> Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_MENSAGEM_ANCINE tB_MENSAGEM_ANCINE = await db.TB_MENSAGEM_ANCINE.FindAsync(id);
            if (tB_MENSAGEM_ANCINE == null)
            {
                return HttpNotFound();
            }
            return View(tB_MENSAGEM_ANCINE);
        }

        // POST: TB_MENSAGEM_ANCINE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(DateTime id)
        {
            TB_MENSAGEM_ANCINE tB_MENSAGEM_ANCINE = await db.TB_MENSAGEM_ANCINE.FindAsync(id);
            db.TB_MENSAGEM_ANCINE.Remove(tB_MENSAGEM_ANCINE);
            await db.SaveChangesAsync();
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
