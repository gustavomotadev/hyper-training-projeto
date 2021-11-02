using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class Genero
    {
        public int Id { get; init; }
        public string Valor { get; init; }
        public List<Colaborador> Colaboradores { get; set; } //ef

        private Genero(int id, string valor)
        {
            Id = id;
            Valor = valor;
        }

        public static Genero AdicionarGenero(int idGenero, string valorGenero)
        {
            if (!String.IsNullOrWhiteSpace(valorGenero))
            {
                return new Genero(idGenero, valorGenero);
            }
            else
            {
                return null;
            }
        }
    }
}
