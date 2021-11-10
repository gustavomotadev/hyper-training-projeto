﻿using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class RegimeContratual
    {
        public int Id { get; init; }
        public string Valor { get; init; }
        public List<ContratoTrabalho> ContratosDeTrabalho { get; set; } = new List<ContratoTrabalho>(); //ef

        private RegimeContratual() { }

        private RegimeContratual(string valor)
        {
            Valor = valor.ToLower();
        }

        public static RegimeContratual NovoRegimeContratual(string valor)
        {
            if (!String.IsNullOrWhiteSpace(valor))
            {
                return new RegimeContratual(valor);
            }
            else
            {
                return null;
            }
        }
    }
}
