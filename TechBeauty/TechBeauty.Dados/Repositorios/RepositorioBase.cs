using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dados.Interfaces;

namespace TechBeauty.Dados.Repositorios
{
    public class RepositorioBase<T> : IRepositorioModelo<T>, IDisposable where T : class
    {
        protected readonly Contexto _contexto; //coloquei readonly depois
        public bool _salvarAlteracoes = true;

        public RepositorioBase(bool salvarAlteracoes = true)
        {
            _salvarAlteracoes = salvarAlteracoes;
            _contexto = new Contexto();
        }

        public void Alterar(T objeto)
        {
            _contexto.Entry(objeto).State = EntityState.Modified;

            if (_salvarAlteracoes)
            {
                _contexto.SaveChanges();
            }
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public void Excluir(T objeto)
        {
            _contexto.Set<T>().Remove(objeto);

            if (_salvarAlteracoes)
            {
                _contexto.SaveChanges();
            }
        }

        public void ExcluirPorChave(params object[] chave)
        {
            var objeto = SelecionarPorChave(chave);
            Excluir(objeto);
        }

        public void Incluir(T objeto)
        {
            _contexto.Set<T>().Add(objeto);

            if (_salvarAlteracoes)
            {
                _contexto.SaveChanges();
            }
        }

        public void SalvarAlteracoes()
        {
            _contexto.SaveChanges();
        }

        public T SelecionarPorChave(params object[] chave)
        {
            return _contexto.Set<T>().Find(chave);
        }

        public List<T> SelecionarTodos()
        {
            return _contexto.Set<T>().ToList();
        }

        //essa funcao consulta o banco toda vez, nao tem cache
        public List<T> SelecionarPorCondicao(Func<T, bool> condicao) //receber delegate
        {
            return _contexto.Set<T>().Where(condicao).ToList();
        }

        //essa funcao consulta o banco toda vez, nao tem cache
        public T SelecionarUmPorCondicao(Func<T, bool> condicao) //receber delegate
        {
            return _contexto.Set<T>().Where(condicao).FirstOrDefault();
        }

        public virtual T SelecionarCompletoPorChave(params object[] chave)
        {
            return _contexto.Set<T>().Find(chave);
        }
    }
}
