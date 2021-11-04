﻿using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class Genero
    {
        public int Id { get; init; }
        public string Valor { get; init; }
        public List<Colaborador> Colaboradores { get; set; } //ef

        private Genero() { }

        private Genero(string valor)
        {
            
            Valor = valor;
        }

        public static Genero AdicionarGenero(string valorGenero)
        {
            if (!String.IsNullOrWhiteSpace(valorGenero))
            {
                return new Genero(valorGenero);
            }
            else
            {
                return null;
            }
        }
    }
}
