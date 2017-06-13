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
    public class TB_TESTEController : Controller
    {
        private TicketMidiaEntities db = new TicketMidiaEntities();

        // GET: TB_TESTE
        public async Task<ActionResult> Index()
        {
            var tB_VENDEDOR_REMOTO = db.TB_VENDEDOR_REMOTO.Include(t => t.TB_EMPRESA_COMPLEXO);
            return View(await tB_VENDEDOR_REMOTO.ToListAsync());
        }

        // GET: TB_TESTE/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_VENDEDOR_REMOTO tB_VENDEDOR_REMOTO = await db.TB_VENDEDOR_REMOTO.FindAsync(id);
            if (tB_VENDEDOR_REMOTO == null)
            {
                return HttpNotFound();
            }
            return View(tB_VENDEDOR_REMOTO);
        }

        // GET: TB_TESTE/Create
        public ActionResult Create()
        {
            ViewBag.EMP_CD_ANCINE = new SelectList(db.TB_EMPRESA_COMPLEXO, "EMP_CD_ANCINE", "EMP_RZ_SOCIAL");
            return View();
        }

        // POST: TB_TESTE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VRE_CNPJ,EMP_CD_ANCINE,VRE_RZ_SOCIAL")] TB_VENDEDOR_REMOTO tB_VENDEDOR_REMOTO)
        {
            if (ModelState.IsValid)
            {
                db.TB_VENDEDOR_REMOTO.Add(tB_VENDEDOR_REMOTO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EMP_CD_ANCINE = new SelectList(db.TB_EMPRESA_COMPLEXO, "EMP_CD_ANCINE", "EMP_RZ_SOCIAL", tB_VENDEDOR_REMOTO.EMP_CD_ANCINE);
            return View(tB_VENDEDOR_REMOTO);
        }

        // GET: TB_TESTE/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_VENDEDOR_REMOTO tB_VENDEDOR_REMOTO = await db.TB_VENDEDOR_REMOTO.FindAsync(id);
            if (tB_VENDEDOR_REMOTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMP_CD_ANCINE = new SelectList(db.TB_EMPRESA_COMPLEXO, "EMP_CD_ANCINE", "EMP_RZ_SOCIAL", tB_VENDEDOR_REMOTO.EMP_CD_ANCINE);
            return View(tB_VENDEDOR_REMOTO);
        }

        // POST: TB_TESTE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VRE_CNPJ,EMP_CD_ANCINE,VRE_RZ_SOCIAL")] TB_VENDEDOR_REMOTO tB_VENDEDOR_REMOTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_VENDEDOR_REMOTO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EMP_CD_ANCINE = new SelectList(db.TB_EMPRESA_COMPLEXO, "EMP_CD_ANCINE", "EMP_RZ_SOCIAL", tB_VENDEDOR_REMOTO.EMP_CD_ANCINE);
            return View(tB_VENDEDOR_REMOTO);
        }

        // GET: TB_TESTE/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_VENDEDOR_REMOTO tB_VENDEDOR_REMOTO = await db.TB_VENDEDOR_REMOTO.FindAsync(id);
            if (tB_VENDEDOR_REMOTO == null)
            {
                return HttpNotFound();
            }
            return View(tB_VENDEDOR_REMOTO);
        }

        // POST: TB_TESTE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            TB_VENDEDOR_REMOTO tB_VENDEDOR_REMOTO = await db.TB_VENDEDOR_REMOTO.FindAsync(id);
            db.TB_VENDEDOR_REMOTO.Remove(tB_VENDEDOR_REMOTO);
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
