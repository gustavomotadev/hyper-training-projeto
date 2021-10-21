﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Repositorio
{
    public class ClienteRepositorio
    {
        public List<Cliente> TabelaCliente { get; private set; } = new List<Cliente>();

        public ClienteRepositorio(ContatoRepositorio repoContato)
        {
            Preencher(repoContato);
        }

        public void Incluir(Cliente cliente) => TabelaCliente.Add(cliente);

        public Cliente SelecionarPorId(int id) => TabelaCliente.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, string nome, string cpf, DateTime dataNascimento, 
            List<Contato> contatos)
        {
            SelecionarPorId(id).Alterar(nome, cpf, dataNascimento, contatos);
        }

        public void Exlucir(int id) => TabelaCliente.Remove(SelecionarPorId(id));

        public void Preencher(ContatoRepositorio repoContato)
        {
            (string nome, string cpf, DateTime dataNascimento, int[] idContatos)[]
                valoresCliente =
                {
                    ("Robervaldo Ferreira", "45887936514", new DateTime(1981,11,01), new int[]{1} )
                };

            for (int i = 0; i < valoresCliente.Length; i++)
            {
                var contatos = new List<Contato>();
                foreach (var idContato in valoresCliente[i].idContatos)
                {
                    contatos.Add(repoContato.SelecionarPorId(idContato));
                }
                Incluir(Cliente.Criar(i + 1, valoresCliente[i].nome, valoresCliente[i].cpf, 
                    valoresCliente[i].dataNascimento, contatos ));
            }
        }
    }
}