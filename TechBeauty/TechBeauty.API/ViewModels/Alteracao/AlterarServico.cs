using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AlterarServico 
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }  
        public string Descricao { get; set; }
        public int DuracaoEmMin { get; set; }

        public bool ValidarNome()
        {
            return (!String.IsNullOrWhiteSpace(Nome));
        }

        public bool ValidarPreco()
        {
            return (Preco > 0M);
        }

        public bool ValidarDescricao()
        {
            return (!String.IsNullOrWhiteSpace(Descricao));
        }

        public bool ValidarDuracaoEmMin()
        {
            return (DuracaoEmMin > 0);
        }
    }
}
