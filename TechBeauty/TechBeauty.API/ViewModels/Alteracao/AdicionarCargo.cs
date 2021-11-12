using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechBeauty.API.ViewModels.Alteracao
{
    public class AdicionarCargo
    {
        [Required]
        public int CargoId { get; set; }
    }
}
