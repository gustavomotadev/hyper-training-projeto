using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class RegimeContratual
    {
        public int Id { get; init; }
        public string Valor { get; init; }
        public List<ContratoTrabalho> ContratosDeTrabalho { get; private set; } = new List<ContratoTrabalho>(); //ef

        private RegimeContratual() { }

        private RegimeContratual(string valor)
        {
            Valor = valor.ToLower();
        }

        public static RegimeContratual NovoRegimeContratual(string valor)
        {
            return new RegimeContratual(valor);
        }
    }
}
