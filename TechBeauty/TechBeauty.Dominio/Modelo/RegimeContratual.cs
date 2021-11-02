using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class RegimeContratual
    {
        public int Id { get; init; }
        public string Valor { get; init; }
        public List<ContratoTrabalho> ContratosDeTrabalho { get; set; } //ef

        private RegimeContratual(int id, string valor)
        {
            Id = id;
            Valor = valor.ToLower();
        }

        public static RegimeContratual NovoRegimeContratual(int idRegimeContratual, string valor)
        {
            if (!String.IsNullOrWhiteSpace(valor))
            {
                return new RegimeContratual(idRegimeContratual, valor);
            }
            else
            {
                return null;
            }
        }
    }
}
