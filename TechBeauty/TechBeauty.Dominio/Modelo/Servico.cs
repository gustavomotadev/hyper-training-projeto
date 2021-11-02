using System;
using System.Collections.Generic;
using TechBeauty.Dominio.Financeiro;

namespace TechBeauty.Dominio.Modelo
{
    public class Servico
    {
        public int Id { get; init; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public string Descricao { get; private set; }
        public int DuracaoEmMin { get; private set; }
        public List<Agendamento> Agendamentos { get; set; } //ef
        public List<ColaboradorServico> ColaboradoresServicos { get; set; } //ef
        public List<RemuneracaoDiariaServico> RemuneracoesServicos { get; set; } //ef

        private Servico(int id) => Id = id;

        public static Servico NovoServico(int idServico, string nome, decimal preco, string descricao, int duracaoEmMin)
        {
            if (!String.IsNullOrWhiteSpace(nome) &&
                preco > 0M &&
                !String.IsNullOrWhiteSpace(descricao) &&
                duracaoEmMin > 0)
            {
                var servico = new Servico(idServico);
                servico.Nome = nome;
                servico.Preco = preco;
                servico.Descricao = descricao;
                servico.DuracaoEmMin = duracaoEmMin;
                return servico;
            }
            else
            {
                return null;
            }
        }

        public bool AlterarNome(string novoNome)
        {
            if (!String.IsNullOrWhiteSpace(novoNome))
            {
                Nome = novoNome;
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool AlterarPreco(decimal novoPreco)
        {
            if (novoPreco > 0M)
            {
                Preco = novoPreco;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AlterarDescricao(string novaDescricao)
        {
            if (!String.IsNullOrWhiteSpace(novaDescricao))
            {
                Descricao = novaDescricao;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AlterarDuracao(int novaDuracaoEmMin)
        {
            if (novaDuracaoEmMin > 0)
            {
                DuracaoEmMin = novaDuracaoEmMin;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
