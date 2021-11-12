using System;
using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Financeiro;
using TechBeauty.Dominio.Modelo.Enumeracoes;

namespace TechBeauty.Dominio.Modelo
{
    public class Colaborador : Pessoa
    {
        public List<Servico> Servicos { get; private set; } = new List<Servico>(); //ef
        public int EnderecoId { get; private set; } //ef
        public Endereco Endereco { get; private set; }
        public int GeneroId { get; private set; } //ef
        public Genero Genero { get; private set; }
        public string NomeSocial { get; private set; } = String.Empty;
        public List<ContratoTrabalho> Contratos { get; private set; } = new List<ContratoTrabalho>(); //ef
        public List<Turno> Turnos { get; private set; } = new List<Turno>();  //ef
        public List<Agendamento> Agendamentos { get; private set; } = new List<Agendamento>(); //ef
        public PadraoRemuneracao PadraoRemuneracao { get; private set; } //ef
        public List<RemuneracaoDiaria> Remuneracoes { get; private set; } = new List<RemuneracaoDiaria>(); //ef

        private Colaborador() { }

        private Colaborador(string cpf, DateTime dataNascimento)
        {
            CPF = cpf;
            DataNascimento = dataNascimento;
        }

        public static Colaborador NovoColaborador(string nome, string cpf, DateTime dataNascimento, 
            int enderecoId, int generoId, string nomeSocial = null)
        {
            var colaborador = new Colaborador(cpf, dataNascimento);
            colaborador.Nome = nome;
            colaborador.EnderecoId = enderecoId;
            colaborador.GeneroId = generoId;
            if (String.IsNullOrEmpty(nomeSocial))
            {
                colaborador.NomeSocial = String.Empty;
            }
            else
            {
                colaborador.NomeSocial = nomeSocial;
            }
            //colaborador.Contratos.Add(contrato);
            return colaborador;
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

        /*
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
        */

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

        public bool AlterarContrato(ContratoTrabalho novoContrato)
        {
            if (novoContrato != null &&
                novoContrato.Vigente)
            {
                foreach (var contrato in Contratos)
                {
                    contrato.alterarVigencia(false);
                }
                Contratos.Add(novoContrato);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
