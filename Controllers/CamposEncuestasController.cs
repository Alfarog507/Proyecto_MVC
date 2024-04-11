using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCRUD2.Models;

namespace MVCCRUD2.Controllers
{
    public class CamposEncuestasController : Controller
    {
        private readonly MvccrudContext _context;

        public CamposEncuestasController(MvccrudContext context)
        {
            _context = context;
        }

        // GET: CamposEncuestas
        public async Task<IActionResult> Index()
        {
            var mvccrudContext = _context.CamposEncuestas.Include(c => c.Encuesta);
            return View(await mvccrudContext.ToListAsync());
        }

        // GET: CamposEncuestas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camposEncuesta = await _context.CamposEncuestas
                .Include(c => c.Encuesta)
                .FirstOrDefaultAsync(m => m.CampoId == id);
            if (camposEncuesta == null)
            {
                return NotFound();
            }

            return View(camposEncuesta);
        }

        // GET: CamposEncuestas/Create
        public IActionResult Create()
        {
            ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "EncuestaId");
            return View();
        }

        // POST: CamposEncuestas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CampoId,EncuestaId,NombreCampo,EsRequerido,TipoCampo")] CamposEncuesta camposEncuesta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(camposEncuesta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "EncuestaId", camposEncuesta.EncuestaId);
            return View(camposEncuesta);
        }

        // GET: CamposEncuestas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camposEncuesta = await _context.CamposEncuestas.FindAsync(id);
            if (camposEncuesta == null)
            {
                return NotFound();
            }
            ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "EncuestaId", camposEncuesta.EncuestaId);
            return View(camposEncuesta);
        }

        // POST: CamposEncuestas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CampoId,EncuestaId,NombreCampo,EsRequerido,TipoCampo")] CamposEncuesta camposEncuesta)
        {
            if (id != camposEncuesta.CampoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camposEncuesta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CamposEncuestaExists(camposEncuesta.CampoId))
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
            ViewData["EncuestaId"] = new SelectList(_context.Encuestas, "EncuestaId", "EncuestaId", camposEncuesta.EncuestaId);
            return View(camposEncuesta);
        }

        // GET: CamposEncuestas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camposEncuesta = await _context.CamposEncuestas
                .Include(c => c.Encuesta)
                .FirstOrDefaultAsync(m => m.CampoId == id);
            if (camposEncuesta == null)
            {
                return NotFound();
            }

            return View(camposEncuesta);
        }

        // POST: CamposEncuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camposEncuesta = await _context.CamposEncuestas.FindAsync(id);
            if (camposEncuesta != null)
            {
                _context.CamposEncuestas.Remove(camposEncuesta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CamposEncuestaExists(int id)
        {
            return _context.CamposEncuestas.Any(e => e.CampoId == id);
        }
    }
}
