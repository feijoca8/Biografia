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
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Biografia.Controllers
{
    [Authorize]
    public class EducacaoFormacaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EducacaoFormacaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EducacaoFormacao
        public async Task<IActionResult> Index()
        {
            return View(await _context.Educacao.ToListAsync());
        }

        // GET: EducacaoFormacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educacao = await _context.Educacao
                .FirstOrDefaultAsync(m => m.EducacaoId == id);
            if (educacao == null)
            {
                return NotFound();
            }

            return View(educacao);
        }

        // GET: EducacaoFormacao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EducacaoFormacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EducacaoId,Escolas,Tempo")] Educacao educacao, IFormFile ficheiroFoto)
        {
            if (ModelState.IsValid)
            {
                if (ficheiroFoto != null && ficheiroFoto.Length > 0)
                {
                    using (var ficheiroMemoria = new MemoryStream())
                    {
                        ficheiroFoto.CopyTo(ficheiroMemoria);
                        educacao.Foto = ficheiroMemoria.ToArray();
                    }
                }
                _context.Add(educacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educacao);
        }

        // GET: EducacaoFormacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educacao = await _context.Educacao.FindAsync(id);
            if (educacao == null)
            {
                return NotFound();
            }
            return View(educacao);
        }

        // POST: EducacaoFormacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EducacaoId,Escolas,Tempo")] Educacao educacao)
        {
            if (id != educacao.EducacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducacaoExists(educacao.EducacaoId))
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
            return View(educacao);
        }

        // GET: EducacaoFormacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educacao = await _context.Educacao
                .FirstOrDefaultAsync(m => m.EducacaoId == id);
            if (educacao == null)
            {
                return NotFound();
            }

            return View(educacao);
        }

        // POST: EducacaoFormacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educacao = await _context.Educacao.FindAsync(id);
            _context.Educacao.Remove(educacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducacaoExists(int id)
        {
            return _context.Educacao.Any(e => e.EducacaoId == id);
        }
    }
}
