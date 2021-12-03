using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEnade.Models
{
    public class RelatorioModel
    {
        [Display(Name = "Data Início da Prova")]
        public DateTime DataProvaInicio { get; set; }

        [Display(Name = "Data Fim da Prova")]
        public DateTime DataProvaFim { get; set; }

        [Display(Name = "Tipo da Questão")]
        public int TipoProva { get; set; }
        public string DescricaoTipoProva { get; set; }

        [Display(Name = "Dificuldade da Questão")]
        public int DificuldadeQuestao { get; set; }
        public string DescricaoDificuldadeQuestao { get; set; }

        [Display(Name = "Prova")]
        public int IdProva { get; set; }

        [Display(Name = "Resposta Correta")]
        public int RespostaCorreta { get; set; }
    }
}
