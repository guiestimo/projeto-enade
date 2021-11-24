using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoEnade.Models;
using ProjetoEnade.Repository;
using ProjetoEnade.Utils;

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
        public IActionResult Index()
        {
            var enadeDbContext = from questoes in _context.QuestaoGabarito.ToList()
                                 join provas in _context.Provas.ToList() on questoes.IdProva equals provas.Id
                                 join curso in _context.Cursos.ToList() on provas.IdCurso equals curso.Id
                                 select new QuestaoGabarito
                                 {
                                     Id = questoes.Id,
                                     Enunciado = questoes.Enunciado,
                                     DescricaoTipoProva = Helpers.GetEnumDescription((Enums.TipoDaProva)questoes.TipoProva),
                                     DescricaoDificuldadeQuestao = Helpers.GetEnumDescription((Enums.DificuldadeDaQuestao)questoes.DificuldadeQuestao),
                                     DescricaoRespostaCorreta = Helpers.GetEnumDescription((Enums.RespostaCerta)questoes.RespostaCorreta),
                                     DescricaoProva = $"Ano: {provas.Ano} - Curso: {curso.Nome} - Edição: {provas.Edicao}"
                                 };

            return View(enadeDbContext.ToList());
        }

        // GET: QuestaoGabarito/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questaoGabarito = (from questoes in _context.QuestaoGabarito.ToList()
                                   join provas in _context.Provas.ToList() on questoes.IdProva equals provas.Id
                                   join curso in _context.Cursos.ToList() on provas.IdCurso equals curso.Id
                                   where questoes.Id == id
                                   select new QuestaoGabarito
                                   {
                                       Id = questoes.Id,
                                       Enunciado = questoes.Enunciado,
                                       DescricaoTipoProva = Helpers.GetEnumDescription((Enums.TipoDaProva)questoes.TipoProva),
                                       DescricaoDificuldadeQuestao = Helpers.GetEnumDescription((Enums.DificuldadeDaQuestao)questoes.DificuldadeQuestao),
                                       DescricaoRespostaCorreta = Helpers.GetEnumDescription((Enums.RespostaCerta)questoes.RespostaCorreta),
                                       DescricaoProva = $"Ano: {provas.Ano} - Curso: {curso.Nome} - Edição: {provas.Edicao}",
                                       RespostaA = questoes.RespostaA,
                                       RespostaB = questoes.RespostaB,
                                       RespostaC = questoes.RespostaC,
                                       RespostaD = questoes.RespostaD,
                                       RespostaE = questoes.RespostaE,
                                   }).FirstOrDefault();


            if (questaoGabarito == null)
            {
                return NotFound();
            }

            return View(questaoGabarito);
        }

        // GET: QuestaoGabarito/Create
        public IActionResult Create()
        {
            var provas = from prova in _context.Provas.ToList()
                         join curso in _context.Cursos.ToList() on prova.IdCurso equals curso.Id
                         select new
                         {
                             Id = prova.Id,
                             DescricaoCompleta = $"Ano: {prova.Ano} - Curso: {curso.Nome} - Edição: {prova.Edicao}"
                         };

            ViewData["DetalhesProva"] = new SelectList(provas, "Id", "DescricaoCompleta", null);
            return View();
        }

        // POST: QuestaoGabarito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuestaoGabarito questaoGabarito)
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
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questaoGabarito = (from questoes in _context.QuestaoGabarito.ToList()
                                   join provas in _context.Provas.ToList() on questoes.IdProva equals provas.Id
                                   join curso in _context.Cursos.ToList() on provas.IdCurso equals curso.Id
                                   where questoes.Id == id
                                   select new QuestaoGabarito
                                   {
                                       Id = questoes.Id,
                                       Enunciado = questoes.Enunciado,
                                       TipoProva = questoes.TipoProva,
                                       DescricaoTipoProva = Helpers.GetEnumDescription((Enums.TipoDaProva)questoes.TipoProva),
                                       DificuldadeQuestao = questoes.DificuldadeQuestao,
                                       DescricaoDificuldadeQuestao = Helpers.GetEnumDescription((Enums.DificuldadeDaQuestao)questoes.DificuldadeQuestao),
                                       RespostaCorreta = questoes.RespostaCorreta,
                                       DescricaoRespostaCorreta = Helpers.GetEnumDescription((Enums.RespostaCerta)questoes.RespostaCorreta),
                                       DescricaoProva = $"Ano: {provas.Ano} - Curso: {curso.Nome} - Edição: {provas.Edicao}",
                                       RespostaA = questoes.RespostaA,
                                       RespostaB = questoes.RespostaB,
                                       RespostaC = questoes.RespostaC,
                                       RespostaD = questoes.RespostaD,
                                       RespostaE = questoes.RespostaE,
                                   }).FirstOrDefault();

            var provasCursos = from prova in _context.Provas.ToList()
                               join curso in _context.Cursos.ToList() on prova.IdCurso equals curso.Id
                               select new
                               {
                                   Id = prova.Id,
                                   DescricaoCompleta = $"Ano: {prova.Ano} - Curso: {curso.Nome} - Edição: {prova.Edicao}"
                               };

            if (questaoGabarito == null)
            {
                return NotFound();
            }
            ViewData["DetalhesProva"] = new SelectList(provasCursos, "Id", "DescricaoCompleta", null);
            return View(questaoGabarito);
        }

        // POST: QuestaoGabarito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, QuestaoGabarito questaoGabarito)
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
            var provas = from prova in _context.Provas.ToList()
                         join curso in _context.Cursos.ToList() on prova.IdCurso equals curso.Id
                         select new
                         {
                             Id = prova.Id,
                             DescricaoCompleta = $"Ano: {prova.Ano} - Curso: {curso.Nome} - Edição: {prova.Edicao}"
                         };

            ViewData["DetalhesProva"] = new SelectList(provas, "Id", "DescricaoCompleta", null);
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
