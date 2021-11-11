using System;
using System.Collections.Generic;

namespace TechBeauty.Dados.Interfaces
{
    public interface IRepositorioModelo<T> where T : class
    {
        List<T> SelecionarTodos();
        T SelecionarPorChave(params object[] chave);
        void Incluir(T objeto);
        void Alterar(T objeto);
        void Excluir(T objeto);
        void Excluir(params object[] chave);
        void SalvarAlteracoes();
        public List<T> SelecionarPorCondicao(Func<T, bool> condicao); //receber delegate
        public T SelecionarUmPorCondicao(Func<T, bool> condicao); //receber delegate
    }
}
