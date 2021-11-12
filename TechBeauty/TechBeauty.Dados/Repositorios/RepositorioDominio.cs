using TechBeauty.Dominio.Financeiro; 
using TechBeauty.Dominio.Modelo;

namespace TechBeauty.Dados.Repositorios
{
    public static class RepositorioDominio
    {
        public static RepositorioBase<Agendamento> Agendamento { get; } = new RepositorioBase<Agendamento>();
        public static RepositorioBase<CaixaDiario> CaixaDiario { get; } = new RepositorioBase<CaixaDiario>();
        public static RepositorioBase<Cargo> Cargo { get; } = new RepositorioBase<Cargo>();
        public static RepositorioBase<Cliente> Cliente { get; } = new RepositorioBase<Cliente>();
        public static RepositorioBase<Colaborador> Colaborador { get; } = new RepositorioBase<Colaborador>();
        public static RepositorioBase<Contato> Contato { get; } = new RepositorioBase<Contato>();
        public static RepositorioBase<ContratoTrabalho> ContratoTrabalho { get; } = new RepositorioBase<ContratoTrabalho>();
        public static RepositorioBase<Endereco> Endereco { get; } = new RepositorioBase<Endereco>();
        //public static RepositorioBase<Expediente> Expediente { get; } = new RepositorioBase<Expediente>();
        public static RepositorioExpediente Expediente { get; } = new RepositorioExpediente();
        public static RepositorioBase<FormaPagamento> FormaPagamento { get; } = new RepositorioBase<FormaPagamento>();
        public static RepositorioBase<Genero> Genero { get; } = new RepositorioBase<Genero>();
        public static RepositorioBase<OrdemServico> OrdemServico { get; } = new RepositorioBase<OrdemServico>();
        public static RepositorioBase<PadraoRemuneracao> PadraoRemuneracao { get; } = new RepositorioBase<PadraoRemuneracao>();
        public static RepositorioBase<Pagamento> Pagamento { get; } = new RepositorioBase<Pagamento>();
        public static RepositorioBase<Pessoa> Pessoa { get; } = new RepositorioBase<Pessoa>();
        public static RepositorioBase<RegimeContratual> RegimeContratual { get; } = new RepositorioBase<RegimeContratual>();
        public static RepositorioBase<RemuneracaoDiaria> RemuneracaoDiaria { get; } = new RepositorioBase<RemuneracaoDiaria>();
        public static RepositorioBase<Servico> Servico { get; } = new RepositorioBase<Servico>();
        public static RepositorioBase<TipoContato> TipoContato { get; } = new RepositorioBase<TipoContato>();
        public static RepositorioBase<Turno> Turno { get; } = new RepositorioBase<Turno>();
    }
}
