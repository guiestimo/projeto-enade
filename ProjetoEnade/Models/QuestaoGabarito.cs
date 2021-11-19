using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEnade.Models
{
    public class QuestaoGabarito : Base
    {
        [Display(Name = "Ano da Prova")]
        public int IdProva { get; set; }
        public Provas Provas { get; set; }
        public string Enunciado { get; set; }

        [Display(Name = "Resposta A")]
        public string RespostaA { get; set; }

        [Display(Name = "Resposta B")]
        public string RespostaB { get; set; }

        [Display(Name = "Resposta C")]
        public string RespostaC { get; set; }

        [Display(Name = "Resposta D")]
        public string RespostaD { get; set; }

        [Display(Name = "Resposta E")]
        public string RespostaE { get; set; }

        [Display(Name = "Resposta Correta")]
        public string RespostaCorreta { get; set; }
    }
}
