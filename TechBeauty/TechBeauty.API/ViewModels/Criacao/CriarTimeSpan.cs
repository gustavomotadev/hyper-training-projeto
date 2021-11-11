using System.ComponentModel.DataAnnotations;

namespace TechBeauty.API.ViewModels.Criacao
{
    public class CriarTimeSpan
    {
        [Required]
        public int Horas { get; }
        [Required]
        public int Minutos { get; }
    }
}
