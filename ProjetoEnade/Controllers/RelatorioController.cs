using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoEnade.Models;
using ProjetoEnade.Repository;
using ProjetoEnade.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEnade.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly EnadeDbContext _context;

        public RelatorioController(EnadeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excel(RelatorioModel relatorioModel)
        {
            var dadosRelatorio = (from questoes in _context.QuestaoGabarito.ToList()
                        where
                        questoes.TipoProva == relatorioModel.TipoProva &&
                        questoes.DificuldadeQuestao == relatorioModel.DificuldadeQuestao
                        select new RelatorioModel
                        {
                            DescricaoTipoProva = Helpers.GetEnumDescription((Enums.TipoDaProva)questoes.TipoProva),
                            DescricaoDificuldadeQuestao = Helpers.GetEnumDescription((Enums.DificuldadeDaQuestao)questoes.DificuldadeQuestao),
                        }).ToList();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Dados");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Tipo da Questão";
                worksheet.Cell(currentRow, 2).Value = "Dificuldade da Questão";
                foreach (var item in dadosRelatorio)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = item.DescricaoTipoProva;
                    worksheet.Cell(currentRow, 2).Value = item.DescricaoDificuldadeQuestao;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "users.xlsx");
                }
            }
        }
    }
}
