using System;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class Colaborador : Pessoa
    {
        public string CarteiraTrabalho { get; private set; }
        public List<Servico> Servicos { get; private set; }
        public Endereco Endereco { get; private set; }
        public Genero Genero { get; private set; }
        public string NomeSocial { get; private set; }
        public ContratoTrabalho Contrato { get; private set; }

        public Colaborador(int id, string cpf, DateTime dataNascimento)
        {
            Id = id;
            CPF = cpf;
            DataNascimento = dataNascimento;
            
        }
        public static Colaborador NovoColaborador(int idColaborador, string nome, string cpf, DateTime dataNascimento, 
            List<Contato> contatos, string carteiraDeTrabalho, List<Servico> servicos, Endereco endereco, 
            Genero genero, string nomeSocial, ContratoTrabalho contrato)
        {
            var colaborador = new Colaborador(idColaborador, cpf, dataNascimento);
            colaborador.Nome = nome;
            colaborador.Contatos = contatos;
            colaborador.CarteiraTrabalho = carteiraDeTrabalho;
            colaborador.Servicos = servicos;
            colaborador.Endereco = endereco;
            colaborador.Genero = genero;
            colaborador.NomeSocial = nomeSocial;
            colaborador.Contrato = contrato;
            return colaborador;
        }

        public void Alterar(string nome, string cpf, DateTime dataNascimento, List<Contato> contatos, 
            string carteiraDeTrabalho, List<Servico> servicos, Endereco endereco, Genero genero, 
            string nomeSocial, ContratoTrabalho contrato)
        {
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Contatos = contatos;
            CarteiraTrabalho = carteiraDeTrabalho;
            Servicos = servicos;
            Endereco = endereco;
            Genero = genero;
            NomeSocial = nomeSocial;
            Contrato = contrato;
        }
    }
}
