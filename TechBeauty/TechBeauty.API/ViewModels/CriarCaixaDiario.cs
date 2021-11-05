using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechBeauty.API.ViewModels
{
    public class CriarCaixaDiario
    {
        [Required]
        public DateTime Data { get; set; }
               
        public decimal? CustoFixo { get; set; }
    }
}
