using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AlterarCargo : IValidavel
    {
        public string Nome { get; set; }   
        public string Descricao { get; set; }

        public bool Validar()
        {
            return (!String.IsNullOrWhiteSpace(Nome) && !String.IsNullOrWhiteSpace(Descricao));
        }
    }
}
