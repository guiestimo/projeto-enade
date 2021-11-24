using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEnade.Utils
{
    public static class Enums
    {
        public enum DificuldadeDaQuestao
        {
            [Description("Fácil")]
            Facil = 1,
            [Description("Médio")]
            Medio = 2,
            [Description("Difícil")]
            Dificil = 3
        }

        public enum RespostaCerta
        {
            [Description("A")]
            A = 1,
            [Description("B")]
            B = 2,
            [Description("C")]
            C = 3,
            [Description("D")]
            D = 4,
            [Description("E")]
            E = 5
        }

        public enum TipoDaProva
        {
            [Description("Dissertativa")]
            Dissertativa = 1,

            [Description("Múltipla Escolha")]
            MultiplaEscolha = 2
        }
    }
}
