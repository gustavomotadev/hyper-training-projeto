using System;
using System.Collections.Generic;
using System.Linq;
using TechBeauty.Dados.Repositorios;
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Csl
{
    class Program
    {

        static void Main(string[] args)
        {
            var repoRegimeContratual = new RepositorioBase<RegimeContratual>();

            var regime1 = RegimeContratual.NovoRegimeContratual("clt");
            var regime2 = RegimeContratual.NovoRegimeContratual("pj");

            repoRegimeContratual.Incluir(regime1);
            repoRegimeContratual.Incluir(regime2);
        }
    }
}
