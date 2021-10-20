using TechBeauty.Dominio.Modelo.Enumeradores;

namespace TechBeauty.Dominio.Modelo
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public decimal PrecoTotal { get; set; }
        public int DuracaoTotal { get; set; }
        public Cliente Cliente { get; set; }
        public StatusOS StatusOS { get; set; }
    }
}
