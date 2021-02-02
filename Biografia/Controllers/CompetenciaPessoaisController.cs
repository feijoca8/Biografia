using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biografia.Data;
using Biografia.Models;
using Microsoft.AspNetCore.Authorization;

namespace Biografia.Controllers
{
    [Authorize]
    public class CompetenciaPessoaisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompetenciaPessoaisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompetenciaPessoais
        public async Task<IActionResult> Index()
        {
            return View(await _context.Competencias.ToListAsync());
        }

        // GET: CompetenciaPessoais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencias = await _context.Competencias
                .FirstOrDefaultAsync(m => m.CompetenciasId == id);
            if (competencias == null)
            {
                return NotFound();
            }

            return View(competencias);
        }

        // GET: CompetenciaPessoais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompetenciaPessoais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompetenciasId,LinguaMaterna,LinguaExtrangeira,Comunicacao")] Competencias competencias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(competencias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(competencias);
        }

        // GET: CompetenciaPessoais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencias = await _context.Competencias.FindAsync(id);
            if (competencias == null)
            {
                return NotFound();
            }
            return View(competencias);
        }

        // POST: CompetenciaPessoais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompetenciasId,LinguaMaterna,LinguaExtrangeira,Comunicacao")] Competencias competencias)
        {
            if (id != competencias.CompetenciasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(competencias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompetenciasExists(competencias.CompetenciasId))
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
            return View(competencias);
        }

        // GET: CompetenciaPessoais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competencias = await _context.Competencias
                .FirstOrDefaultAsync(m => m.CompetenciasId == id);
            if (competencias == null)
            {
                return NotFound();
            }

            return View(competencias);
        }

        // POST: CompetenciaPessoais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var competencias = await _context.Competencias.FindAsync(id);
            _context.Competencias.Remove(competencias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompetenciasExists(int id)
        {
            return _context.Competencias.Any(e => e.CompetenciasId == id);
        }
    }
}
