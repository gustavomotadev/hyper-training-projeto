using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Criacao
{
    public class AdicionarContrato : IValidavel
    {
        [Required]
        public int RegimeContratualId { get; set; }
        [Required]
        public DateTime DataEntrada { get; set; }
        public DateTime? DataDesligamento { get; set; }
        [Required]
        public List<int> IdCargos { get; set; }
        [Required]
        public string CNPJ_CTPS { get; set; }

        //TODO VALIDAR CNPJCTPS
        public bool Validar()
        {
            return (!String.IsNullOrWhiteSpace(CNPJ_CTPS) &&
                ((DataDesligamento != null && DataDesligamento > DataEntrada) || DataDesligamento == null));
        }
    }
}
