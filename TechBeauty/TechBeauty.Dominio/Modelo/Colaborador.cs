﻿using System;
using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Modelo.Enumeradores;

namespace TechBeauty.Dominio.Modelo
{
    public class Colaborador : Pessoa
    {
        public List<Servico> Servicos { get; private set; }
        public Endereco Endereco { get; private set; }
        public Genero Genero { get; private set; }
        public string NomeSocial { get; private set; } = String.Empty;
        public ContratoTrabalho Contrato { get; private set; }

        private Colaborador(int id, string cpf, DateTime dataNascimento)
        {
            Id = id;
            CPF = cpf;
            DataNascimento = dataNascimento;
            
        }

        public static Colaborador NovoColaborador(int idColaborador, string nome, string cpf, DateTime dataNascimento, 
            List<Contato> contatos, string carteiraDeTrabalho, List<Servico> servicos, Endereco endereco, 
            Genero genero, ContratoTrabalho contrato, string nomeSocial = null)
        {
            if (!String.IsNullOrWhiteSpace(nome) &&
                !String.IsNullOrWhiteSpace(cpf) &&
                Pessoa.ObterIdade(dataNascimento) >= 18 &&
                Pessoa.ObterIdade(dataNascimento) <= 100 &&
                contatos != null &&
                contatos.Count > 0 &&
                !contatos.Any(x => x == null) &&
                !String.IsNullOrWhiteSpace(carteiraDeTrabalho) &&
                servicos != null &&
                servicos.Count > 0 &&
                !servicos.Any(x => x == null) &&
                endereco != null &&
                genero != null &&
                contrato != null)
            {
                var colaborador = new Colaborador(idColaborador, cpf, dataNascimento);
                colaborador.Nome = nome;
                colaborador.Contatos = contatos;
                colaborador.Servicos = servicos;
                colaborador.Endereco = endereco;
                colaborador.Genero = genero;
                if (String.IsNullOrEmpty(nomeSocial))
                {
                    colaborador.NomeSocial = String.Empty;
                }
                else
                {
                    colaborador.NomeSocial = nomeSocial;
                }
                colaborador.Contrato = contrato;
                return colaborador;
            }
            else
            {
                return null;
            }
        }

        public bool AdicionarServico(Servico servico)
        {
            if (servico != null)
            {
                Servicos.Add(servico);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Servico ObterServicoPorId(int id) => Servicos.FirstOrDefault(x => x.Id == id);

        public bool RemoverServico(int id)
        {
            if (Servicos.Count > 1)
            {
                return Servicos.Remove(ObterServicoPorId(id));
            }
            else
            { 
                return false;
            }
        }

        public bool RemoverServico(Servico servico)
        {
            if (Servicos.Count > 1 &&
                servico != null)
            {
                return Servicos.Remove(servico);
            }
            else
            {
                return false;
            }
        }

        public bool MudarEndereco(string novoLogradouro, string novoNumero, string novoBairro,
            string novaCidade, UnidadeFederativa novaUF, string novoCep, string novoComplemento) =>
            Endereco.MudarDeEndereco(novoLogradouro, novoNumero, novoBairro, novaCidade, novaUF, novoCep, novoComplemento);

        public bool MudarDeCidade(string novoLogradouro, string novoNumero, string novoBairro,
            string novaCidade, string novonovoCep, string novoComplemento) =>
            Endereco.MudarDeCidade(novoLogradouro, novoNumero, novoBairro, novaCidade, novonovoCep, novoComplemento);

        public bool MudarDeLogradouro(string novoLogradouro, string novoNumero, string novoBairro,
            string novoCep, string novoComplemento) => 
            Endereco.MudarDeLogradouro(novoLogradouro, novoNumero, novoBairro, novoCep, novoComplemento);

        public bool MudarNumeroEComplemento(string novoNumero, string novoComplemento) =>
            Endereco.MudarNumeroEComplemento(novoNumero, novoComplemento);

        public bool AlterarGenero(Genero genero)
        {
            if (genero != null)
            {
                Genero = genero;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AlterarNomeSocial(string nomeSocial)
        {
            if (!String.IsNullOrWhiteSpace(nomeSocial))
            {
                NomeSocial = nomeSocial;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AlterarContrato(ContratoTrabalho contrato)
        {
            if (contrato != null)
            {
                Contrato = contrato;
                return true;
            }
            else
            {
                Contrato = contrato;
                return false;
            }
        }
    }
}
