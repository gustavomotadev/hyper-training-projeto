using System.ComponentModel.DataAnnotations;

namespace TechBeauty.API.ViewModels
{
    public class CriarTimeSpan
    {
        [Required]
        public int horas { get; }
        [Required]
        public int minutos { get; }
    }
}
