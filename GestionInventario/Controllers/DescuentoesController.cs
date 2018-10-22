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
    public class DescuentoesController : Controller
    {
        private DB_A41D6A_GestionInventarioEntities db = new DB_A41D6A_GestionInventarioEntities();

        // GET: Descuentoes
        public async Task<ActionResult> Index()
        {
            return View(await db.Descuentoes.ToListAsync());
        }

        // GET: Descuentoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descuento descuento = await db.Descuentoes.FindAsync(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            return View(descuento);
        }

        // GET: Descuentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Descuentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idDescuento,monto,porcentaje")] Descuento descuento)
        {
            if (ModelState.IsValid)
            {
                db.Descuentoes.Add(descuento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(descuento);
        }

        // GET: Descuentoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descuento descuento = await db.Descuentoes.FindAsync(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            return View(descuento);
        }

        // POST: Descuentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idDescuento,monto,porcentaje")] Descuento descuento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descuento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(descuento);
        }

        // GET: Descuentoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Descuento descuento = await db.Descuentoes.FindAsync(id);
            if (descuento == null)
            {
                return HttpNotFound();
            }
            return View(descuento);
        }

        // POST: Descuentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Descuento descuento = await db.Descuentoes.FindAsync(id);
            db.Descuentoes.Remove(descuento);
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
