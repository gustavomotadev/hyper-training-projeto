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
    }
}
