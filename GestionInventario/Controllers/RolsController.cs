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
    public class RolsController : Controller
    {
        private DB_A41D6A_GestionInventarioEntities db = new DB_A41D6A_GestionInventarioEntities();

        // GET: Rols
        public async Task<ActionResult> Index()
        {
            var rols = db.Rols.Include(r => r.Inventario);
            return View(await rols.ToListAsync());
        }

        // GET: Rols/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol rol = await db.Rols.FindAsync(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        // GET: Rols/Create
        public ActionResult Create()
        {
            ViewBag.idInventario = new SelectList(db.Inventarios, "idInventario", "idInventario");
            return View();
        }

        // POST: Rols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idRol,idInventario,nombre,cargo")] Rol rol)
        {
            if (ModelState.IsValid)
            {
                db.Rols.Add(rol);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idInventario = new SelectList(db.Inventarios, "idInventario", "idInventario", rol.idInventario);
            return View(rol);
        }

        // GET: Rols/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol rol = await db.Rols.FindAsync(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            ViewBag.idInventario = new SelectList(db.Inventarios, "idInventario", "idInventario", rol.idInventario);
            return View(rol);
        }

        // POST: Rols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idRol,idInventario,nombre,cargo")] Rol rol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idInventario = new SelectList(db.Inventarios, "idInventario", "idInventario", rol.idInventario);
            return View(rol);
        }

        // GET: Rols/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rol rol = await db.Rols.FindAsync(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        // POST: Rols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Rol rol = await db.Rols.FindAsync(id);
            db.Rols.Remove(rol);
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
