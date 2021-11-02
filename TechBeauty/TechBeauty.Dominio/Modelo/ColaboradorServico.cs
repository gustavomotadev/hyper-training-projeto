namespace TechBeauty.Dominio.Modelo
{
    public class ColaboradorServico //ef
    {
        public int Id { get; set; }
        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }

        private ColaboradorServico() { }
    }
}