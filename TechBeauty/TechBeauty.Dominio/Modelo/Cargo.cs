﻿using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class Cargo 
    {
        public int Id { get; init; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public List<ContratoTrabalho> ContratosTrabalhos { get; set; } //ef

        private Cargo() { }

        public static Cargo NovoCargo(string nome, string descricao)
        {
            if (!String.IsNullOrWhiteSpace(nome) &&
                !String.IsNullOrWhiteSpace(descricao))
            {
                var cargo = new Cargo();
                cargo.Nome = nome;
                cargo.Descricao = descricao;
                return cargo;
            }
            else
            {
                return null;
            }
        }

        public bool AlterarNome(string nome)
        {
            if (!String.IsNullOrWhiteSpace(nome))
            {
                Nome = nome;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AlterarDescricao(string descricao)
        {
            if (!String.IsNullOrWhiteSpace(descricao))
            {
                Descricao = descricao;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
