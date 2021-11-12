using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AlterarCargo
    {
        public string Nome { get; set; }   
        public string Descricao { get; set; }

        public bool ValidarNome()
        {
            return (!String.IsNullOrWhiteSpace(Nome));
        }

        public bool ValidarDescricao()
        {
            return (!String.IsNullOrWhiteSpace(Descricao));
        }
    }
}
