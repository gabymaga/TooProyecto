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
    public class InventariosController : Controller
    {
        private DB_A41D6A_GestionInventarioEntities db = new DB_A41D6A_GestionInventarioEntities();

        // GET: Inventarios
        public async Task<ActionResult> Index()
        {
            var inventarios = db.Inventarios.Include(i => i.Kardex);
            return View(await inventarios.ToListAsync());
        }

        // GET: Inventarios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = await db.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
        }

        // GET: Inventarios/Create
        public ActionResult Create()
        {
            ViewBag.idKardex = new SelectList(db.Kardexes, "idKardex", "detalle");
            return View();
        }

        // POST: Inventarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idInventario,fecha,idKardex,existencia,cantidad")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                db.Inventarios.Add(inventario);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idKardex = new SelectList(db.Kardexes, "idKardex", "detalle", inventario.idKardex);
            return View(inventario);
        }

        // GET: Inventarios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = await db.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idKardex = new SelectList(db.Kardexes, "idKardex", "detalle", inventario.idKardex);
            return View(inventario);
        }

        // POST: Inventarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idInventario,fecha,idKardex,existencia,cantidad")] Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventario).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idKardex = new SelectList(db.Kardexes, "idKardex", "detalle", inventario.idKardex);
            return View(inventario);
        }

        // GET: Inventarios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventario inventario = await db.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return HttpNotFound();
            }
            return View(inventario);
        }

        // POST: Inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Inventario inventario = await db.Inventarios.FindAsync(id);
            db.Inventarios.Remove(inventario);
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
