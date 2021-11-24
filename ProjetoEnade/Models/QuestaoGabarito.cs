using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEnade.Models
{
    public class QuestaoGabarito : Base
    {
        public int IdProva { get; set; }

        [Display(Name = "Prova")]
        [NotMapped]
        public string DescricaoProva { get; set; }
        public Provas Provas { get; set; }
        public string Enunciado { get; set; }

        [Display(Name = "Tipo da Prova")]
        public int TipoProva { get; set; }

        [NotMapped]
        public string DescricaoTipoProva { get; set; }

        [Display(Name = "Dificuldade da Questão")]
        public int DificuldadeQuestao { get; set; }

        [NotMapped]
        public string DescricaoDificuldadeQuestao { get; set; }

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
        public int RespostaCorreta { get; set; }

        [NotMapped]
        public string DescricaoRespostaCorreta { get; set; }
    }
}
