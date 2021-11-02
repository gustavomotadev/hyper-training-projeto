using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechBeauty.Dominio.Modelo
{
    public class CargoContratoTrabalho //entity framework
    {
        public int Id { get; set; }
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }
        public int ContratoTrabalhoId { get; set; }
        public ContratoTrabalho ContratoTrabalho { get; set; }
    }
}
