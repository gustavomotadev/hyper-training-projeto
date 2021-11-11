using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public List<Agendamento> Agendamentos { get; private set; } = new List<Agendamento>(); //ef
        [JsonIgnore]
        public List<Colaborador> Colaboradores { get; private set; } = new List<Colaborador>(); //ef
        [JsonIgnore]
        public List<RemuneracaoDiaria> Remuneracoes { get; private set; } = new List<RemuneracaoDiaria>(); //ef

        private Servico() { }
        public static Servico NovoServico(string nome, decimal preco, string descricao, int duracaoEmMin)
        {
                var servico = new Servico();
                servico.Nome = nome;
                servico.Preco = preco;
                servico.Descricao = descricao;
                servico.DuracaoEmMin = duracaoEmMin;
                return servico;
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
