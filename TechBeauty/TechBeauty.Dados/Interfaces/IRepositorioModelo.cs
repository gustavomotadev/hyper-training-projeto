using System;
using System.Collections.Generic;

namespace TechBeauty.Dados.Interfaces
{
    public interface IRepositorioModelo<T> where T : class
    {
        public List<T> SelecionarTodos();
        public T SelecionarPorChave(params object[] chave);
        public void Incluir(T objeto);
        public void Alterar(T objeto);
        public void Excluir(T objeto);
        public void ExcluirPorChave(params object[] chave);
        public void SalvarAlteracoes();
        public List<T> SelecionarPorCondicao(Func<T, bool> condicao); //receber delegate
        public T SelecionarUmPorCondicao(Func<T, bool> condicao); //receber delegate
        public T SelecionarCompletoPorChave(params object[] chave);
        public void ExcluirVariosPorCondicao(Func<T, bool> condicao); //receber delegate
    }
}
