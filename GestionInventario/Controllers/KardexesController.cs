using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionInventario.Models;

namespace GestionInventario.Controllers
{
    public class KardexesController : Controller
    {
        private DB_A41D6A_GestionInventarioEntities db = new DB_A41D6A_GestionInventarioEntities();

        // GET: Kardexes
        public async Task<ActionResult> Index()
        {
            var kardexes = db.Kardexes.Include(k => k.Medicamento);
            return View(await kardexes.ToListAsync());
        }

        // GET: Kardexes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kardex kardex = await db.Kardexes.FindAsync(id);
            if (kardex == null)
            {
                return HttpNotFound();
            }
            return View(kardex);
        }

        // GET: Kardexes/Create
        public ActionResult Create()
        {
            ViewBag.idMedicamento = new SelectList(db.Medicamentoes, "idMedicamento", "nombreMedicamento");
            return View();
        }

        // POST: Kardexes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idKardex,detalle,saldo,idMedicamento,cantidad")] Kardex kardex)
        {
            if (ModelState.IsValid)
            {
                db.Kardexes.Add(kardex);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idMedicamento = new SelectList(db.Medicamentoes, "idMedicamento", "nombreMedicamento", kardex.idMedicamento);
            return View(kardex);
        }

        // GET: Kardexes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kardex kardex = await db.Kardexes.FindAsync(id);
            if (kardex == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMedicamento = new SelectList(db.Medicamentoes, "idMedicamento", "nombreMedicamento", kardex.idMedicamento);
            return View(kardex);
        }

        // POST: Kardexes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idKardex,detalle,saldo,idMedicamento,cantidad")] Kardex kardex)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kardex).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idMedicamento = new SelectList(db.Medicamentoes, "idMedicamento", "nombreMedicamento", kardex.idMedicamento);
            return View(kardex);
        }

        // GET: Kardexes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kardex kardex = await db.Kardexes.FindAsync(id);
            if (kardex == null)
            {
                return HttpNotFound();
            }
            return View(kardex);
        }

        // POST: Kardexes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Kardex kardex = await db.Kardexes.FindAsync(id);
            db.Kardexes.Remove(kardex);
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
