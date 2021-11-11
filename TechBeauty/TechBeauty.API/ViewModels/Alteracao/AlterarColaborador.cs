using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AlterarColaborador
    {
        public string Nome { get; set; }

        public string NomeSocial { get; set; }

        public bool ValidarNome()
        {
            return (!String.IsNullOrWhiteSpace(Nome));
        }

        public bool ValidarNomeSocial()
        {
            return (!String.IsNullOrWhiteSpace(NomeSocial));
        }
    }
}
