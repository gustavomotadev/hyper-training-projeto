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
        [Required]
        public List<int> Pagamentos { get; set; }
        [Required]
        public List<int> Remuneracoes { get; set; }
        
        public static decimal CustoFixoPadrao { get; set; }


    }
}
