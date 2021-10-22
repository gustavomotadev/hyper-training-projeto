using System;
using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Repositorio
{
    public class ColaboradorRepositorio
    {
        public List<Colaborador> TabelaColaborador { get; private set; } = new List<Colaborador>();

        public ColaboradorRepositorio(ContatoRepositorio repoContato, ServicoRepositorio repoServico, 
            EnderecoRepositorio repoEndereco, GeneroRepositorio repoGenero, 
            ContratoTrabalhoRepositorio repoContratoTrabalho) => 
            Preencher(repoContato, repoServico, repoEndereco, repoGenero, repoContratoTrabalho);

        public void Incluir(Colaborador colaborador) => TabelaColaborador.Add(colaborador);

        public Colaborador SelecionarPorId(int id) => TabelaColaborador.FirstOrDefault(x => x.Id == id);

        public void Alterar(int id, string nome, string cpf, DateTime dataNascimento,
            List<Contato> contatos, string carteiraDeTrabalho, List<Servico> servicos, Endereco endereco,
            Genero genero, string nomeSocial, ContratoTrabalho contrato) =>
            SelecionarPorId(id).Alterar(nome, cpf, dataNascimento, contatos, carteiraDeTrabalho, servicos, 
                endereco, genero, nomeSocial, contrato);

        public void Excluir(int id) => TabelaColaborador.Remove(SelecionarPorId(id));

        public void Preencher(ContatoRepositorio repoContato, ServicoRepositorio repoServico,
            EnderecoRepositorio repoEndereco, GeneroRepositorio repoGenero,
            ContratoTrabalhoRepositorio repoContratoTrabalho)
        {
            (int id, string nome, string cpf, DateTime dataNascimento, int[] idContatos, 
                string carteiraDeTrabalho, int[] idServicos, int idEndereco, int idGenero, 
                string nomeSocial, int idContrato)[] valoresColaborador =
                {
                    (1, "Manuela Silva", "657890123", new DateTime(1992, 7, 24), new int[]{1}, 
                    "87654321", new int[] { 1, 2 }, 1, 2, "Manuela Silva", 1)
                };

            foreach (var colaborador in valoresColaborador)
            {
                var endereco = repoEndereco.SelecionarPorId(colaborador.idEndereco);
                var genero = repoGenero.SelecionarPorId(colaborador.idGenero);
                var contrato = repoContratoTrabalho.SelecionarPorId(colaborador.idContrato);
                var contatos = new List<Contato>();
                var servicos = new List<Servico>();
                foreach (var idContato in colaborador.idContatos)
                {
                    contatos.Add(repoContato.SelecionarPorId(idContato));
                }
                foreach (var idServico in colaborador.idServicos)
                {
                    servicos.Add(repoServico.SelecionarPorId(idServico));
                }
                Incluir(Colaborador.Criar(colaborador.id, colaborador.nome, colaborador.cpf, 
                    colaborador.dataNascimento, contatos, colaborador.carteiraDeTrabalho, servicos, 
                    endereco, genero, colaborador.nomeSocial, contrato));
            }
        }
    }
}
