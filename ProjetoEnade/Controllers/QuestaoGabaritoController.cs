using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoEnade.Models;
using ProjetoEnade.Repository;

namespace ProjetoEnade.Controllers
{
    public class QuestaoGabaritoController : Controller
    {
        private readonly EnadeDbContext _context;

        public QuestaoGabaritoController(EnadeDbContext context)
        {
            _context = context;
        }

        // GET: QuestaoGabarito
        public async Task<IActionResult> Index()
        {
            var enadeDbContext = _context.QuestaoGabarito.Include(q => q.Provas);
            return View(await enadeDbContext.ToListAsync());
        }

        // GET: QuestaoGabarito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questaoGabarito = await _context.QuestaoGabarito
                .Include(q => q.Provas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questaoGabarito == null)
            {
                return NotFound();
            }

            return View(questaoGabarito);
        }

        // GET: QuestaoGabarito/Create
        public IActionResult Create()
        {
            ViewData["AnoProva"] = new SelectList(_context.Provas, "Id", "Ano");
            return View();
        }

        // POST: QuestaoGabarito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProva,Enunciado,RespostaA,RespostaB,RespostaC,RespostaD,RespostaE,RespostaCorreta,Id")] QuestaoGabarito questaoGabarito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questaoGabarito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProva"] = new SelectList(_context.Provas, "Id", "Id", questaoGabarito.IdProva);
            return View(questaoGabarito);
        }

        // GET: QuestaoGabarito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questaoGabarito = await _context.QuestaoGabarito.FindAsync(id);
            if (questaoGabarito == null)
            {
                return NotFound();
            }
            ViewData["IdProva"] = new SelectList(_context.Provas, "Id", "Id", questaoGabarito.IdProva);
            return View(questaoGabarito);
        }

        // POST: QuestaoGabarito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProva,Enunciado,RespostaA,RespostaB,RespostaC,RespostaD,RespostaE,RespostaCorreta,Id")] QuestaoGabarito questaoGabarito)
        {
            if (id != questaoGabarito.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questaoGabarito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestaoGabaritoExists(questaoGabarito.Id))
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
            ViewData["IdProva"] = new SelectList(_context.Provas, "Id", "Id", questaoGabarito.IdProva);
            return View(questaoGabarito);
        }

        // GET: QuestaoGabarito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questaoGabarito = await _context.QuestaoGabarito
                .Include(q => q.Provas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questaoGabarito == null)
            {
                return NotFound();
            }

            return View(questaoGabarito);
        }

        // POST: QuestaoGabarito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questaoGabarito = await _context.QuestaoGabarito.FindAsync(id);
            _context.QuestaoGabarito.Remove(questaoGabarito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestaoGabaritoExists(int id)
        {
            return _context.QuestaoGabarito.Any(e => e.Id == id);
        }
    }
}
