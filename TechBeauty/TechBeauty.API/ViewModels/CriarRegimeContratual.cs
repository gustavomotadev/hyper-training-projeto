using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechBeauty.API.ViewModels
{
    public class CriarRegimeContratual
    {
        [Required]
        public string Valor { get; set; }
    }
}
