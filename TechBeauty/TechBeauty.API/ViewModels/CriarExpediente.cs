using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechBeauty.API.ViewModels
{
    public class CriarExpediente
    {
        [Required]
        public DateTime DataHoraAbertura { get; set; }
        [Required]
        public DateTime DataHoraFechamento { get; set; 
        
    }
}
