using CampaniaAplicacion.Data;
using CampaniaAplicacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaniaAplicacion.Controllers
{
    public class CampaniaController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CampaniaController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Campania.ToListAsync());
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Campania campania)
        {
            if (ModelState.IsValid)
            {
                await _db.Campania.AddAsync(campania);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Crear));
            }
            return View(campania);
        }
        [HttpGet]
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campania = await _db.Campania
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campania == null)
            {
                return NotFound();
            }

            return View(campania);
        }


        public async Task<IActionResult> Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campania = await _db.Campania
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campania == null)
            {
                return NotFound();
            }

            return View(campania);
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarBorrar(int id)
        {
            var campania = await _db.Campania.FindAsync(id);
            _db.Campania.Remove(campania);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampaniaExists(int id)
        {
            return _db.Campania.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campania = await _db.Campania.FindAsync(id);
            if (campania == null)
            {
                return NotFound();
            }
            return View(campania);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Nombre,Fecha_inicio,Fecha_finalizacion,Descripcion")] Campania campania)
        {
            if (id != campania.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(campania);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampaniaExists(campania.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(campania);
        }
    }
}
