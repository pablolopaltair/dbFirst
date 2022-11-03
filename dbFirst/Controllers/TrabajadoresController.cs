using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dbFirstDAL.Modelo;

namespace dbFirst.Controllers
{
    public class TrabajadoresController : Controller
    {
        private readonly trabajadoresdbFirstContext _context;

        public TrabajadoresController(trabajadoresdbFirstContext context)
        {
            _context = context;
        }

        // GET: Trabajadores
        public async Task<IActionResult> Index()
        {
              return View(await _context.Trabajadores.ToListAsync());
        }

        // GET: Trabajadores/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Trabajadores == null)
            {
                return NotFound();
            }

            var trabajadore = await _context.Trabajadores
                .FirstOrDefaultAsync(m => m.Nombre == id);
            if (trabajadore == null)
            {
                return NotFound();
            }

            return View(trabajadore);
        }

        // GET: Trabajadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trabajadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Apellidos")] Trabajadore trabajadore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabajadore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trabajadore);
        }

        // GET: Trabajadores/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Trabajadores == null)
            {
                return NotFound();
            }

            var trabajadore = await _context.Trabajadores.FindAsync(id);
            if (trabajadore == null)
            {
                return NotFound();
            }
            return View(trabajadore);
        }

        // POST: Trabajadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nombre,Apellidos")] Trabajadore trabajadore)
        {
            if (id != trabajadore.Nombre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabajadore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabajadoreExists(trabajadore.Nombre))
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
            return View(trabajadore);
        }

        // GET: Trabajadores/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Trabajadores == null)
            {
                return NotFound();
            }

            var trabajadore = await _context.Trabajadores
                .FirstOrDefaultAsync(m => m.Nombre == id);
            if (trabajadore == null)
            {
                return NotFound();
            }

            return View(trabajadore);
        }

        // POST: Trabajadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Trabajadores == null)
            {
                return Problem("Entity set 'trabajadoresdbFirstContext.Trabajadores'  is null.");
            }
            var trabajadore = await _context.Trabajadores.FindAsync(id);
            if (trabajadore != null)
            {
                _context.Trabajadores.Remove(trabajadore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrabajadoreExists(string id)
        {
          return _context.Trabajadores.Any(e => e.Nombre == id);
        }
    }
}
