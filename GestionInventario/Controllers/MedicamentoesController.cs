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
    public class MedicamentoesController : Controller
    {
        private DB_A41D6A_GestionInventarioEntities db = new DB_A41D6A_GestionInventarioEntities();

        // GET: Medicamentoes
        public async Task<ActionResult> Index()
        {
            var medicamentoes = db.Medicamentoes.Include(m => m.Categoria);
            return View(await medicamentoes.ToListAsync());
        }

        // GET: Medicamentoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamento medicamento = await db.Medicamentoes.FindAsync(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // GET: Medicamentoes/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categorias, "idCategoria", "nombre_cat");
            return View();
        }

        // POST: Medicamentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idMedicamento,idCategoria,nombreMedicamento,descripcion,fechaVencimiento,precioCompra,precioVenta,numLote")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Medicamentoes.Add(medicamento);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.Categorias, "idCategoria", "nombre_cat", medicamento.idCategoria);
            return View(medicamento);
        }

        // GET: Medicamentoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamento medicamento = await db.Medicamentoes.FindAsync(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.Categorias, "idCategoria", "nombre_cat", medicamento.idCategoria);
            return View(medicamento);
        }

        // POST: Medicamentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idMedicamento,idCategoria,nombreMedicamento,descripcion,fechaVencimiento,precioCompra,precioVenta,numLote")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicamento).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.Categorias, "idCategoria", "nombre_cat", medicamento.idCategoria);
            return View(medicamento);
        }

        // GET: Medicamentoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicamento medicamento = await db.Medicamentoes.FindAsync(id);
            if (medicamento == null)
            {
                return HttpNotFound();
            }
            return View(medicamento);
        }

        // POST: Medicamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Medicamento medicamento = await db.Medicamentoes.FindAsync(id);
            db.Medicamentoes.Remove(medicamento);
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
