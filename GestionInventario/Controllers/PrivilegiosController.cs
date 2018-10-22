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
    public class PrivilegiosController : Controller
    {
        private DB_A41D6A_GestionInventarioEntities db = new DB_A41D6A_GestionInventarioEntities();

        // GET: Privilegios
        public async Task<ActionResult> Index()
        {
            return View(await db.Privilegios.ToListAsync());
        }

        // GET: Privilegios/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Privilegio privilegio = await db.Privilegios.FindAsync(id);
            if (privilegio == null)
            {
                return HttpNotFound();
            }
            return View(privilegio);
        }

        // GET: Privilegios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Privilegios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idPrivilegio,privilegio1")] Privilegio privilegio)
        {
            if (ModelState.IsValid)
            {
                db.Privilegios.Add(privilegio);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(privilegio);
        }

        // GET: Privilegios/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Privilegio privilegio = await db.Privilegios.FindAsync(id);
            if (privilegio == null)
            {
                return HttpNotFound();
            }
            return View(privilegio);
        }

        // POST: Privilegios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idPrivilegio,privilegio1")] Privilegio privilegio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(privilegio).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(privilegio);
        }

        // GET: Privilegios/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Privilegio privilegio = await db.Privilegios.FindAsync(id);
            if (privilegio == null)
            {
                return HttpNotFound();
            }
            return View(privilegio);
        }

        // POST: Privilegios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Privilegio privilegio = await db.Privilegios.FindAsync(id);
            db.Privilegios.Remove(privilegio);
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
