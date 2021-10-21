namespace TechBeauty.Dominio.Modelo
{
    public class Servico
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public string Descricao { get; private set; }
        public int DuracaoEmMin { get; private set; }

        public static Servico Criar(int id, string nome, decimal preco, string descricao, int duracaoEmMin)
        {
            var servico = new Servico();
            servico.Id = id;
            servico.Nome = nome;
            servico.Preco = preco;
            servico.Descricao = descricao;
            servico.DuracaoEmMin = duracaoEmMin;
            return servico;
        }

        public void Alterar(string nome, decimal preco, string descricao, int duracaoEmMin)
        {
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            DuracaoEmMin = duracaoEmMin;
        }
    }
}
