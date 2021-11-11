using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels
{
    public class CriarCaixaDiario : IValidavel
    {
        [Required]
        public DateTime Data { get; set; }
               
        public decimal? CustoFixo { get; set; }

        public bool Validar()
        {
            return (CustoFixo == null ||
                CustoFixo >= 0);
        }
    }
}
