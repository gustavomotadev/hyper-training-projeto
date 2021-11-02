using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dominio.Financeiro
{
    public class RemuneracaoDiariaServico //ef
    {
        public int Id { get; set; }
        public int RemuneracaoDiariaId { get; set; }
        public RemuneracaoDiaria RemuneracaoDiaria { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}
