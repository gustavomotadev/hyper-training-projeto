﻿namespace TechBeauty.Dominio.Modelo
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public int DuracaoEmMin { get; set; }

        public static Servico Criar(int id, string nome, decimal preco, string descricao, int duracaoEmMin)
        {
            var servico = new Servico();
            servico.Id = id;
            servico.Nome = nome;
            servico.Preco = preco;
            servico.Descricao = descricao;
            servico.DuracaoEmMin = duracaoEmMin;
            return servico;
        }
    }
}
