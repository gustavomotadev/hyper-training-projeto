using System.ComponentModel.DataAnnotations;

namespace TechBeauty.API.ViewModels
{
    public class CriarCargo
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
