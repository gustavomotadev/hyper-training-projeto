using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AdicionarServico(Servico servico) => Servicos.Add(servico);

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
            if (Servicos.Count > 1)
            {
                return Servicos.Remove(servico);
            }
            else
            {
                return false;
            }
        }

        public void MudarEndereco(string logradouro, string numero, string bairro,
            string cidade, string uf, string cep, string complemento) =>
            Endereco.MudarEndereco(logradouro, numero, bairro, cidade, uf, cep, complemento);

        public void MudarDeCidade(string logradouro, string numero, string bairro,
            string cidade, string complemento) =>
            Endereco.MudarDeCidade(logradouro, numero, bairro, cidade, complemento);

        public void MudarDeLogradouro(string logradouro, string numero, string bairro,
            string complemento) => 
            Endereco.MudarDeLogradouro(logradouro, numero, bairro, complemento);

        public void MudarNumeroEComplemento(string numero, string complemento) =>
            Endereco.MudarNumeroEComplemento(numero, complemento);

        public void AlterarGenero(Genero genero) => Genero = genero;

        public void AlterarNomeSocial(string nomeSocial) => NomeSocial = nomeSocial;

        public void AlterarContrato(ContratoTrabalho contrato) => Contrato = contrato;
    }
}
