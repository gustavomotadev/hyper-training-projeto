namespace TechBeauty.Dominio.Modelo
{
    public class Servico
    {
        public int Id { get; init; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public string Descricao { get; private set; }
        public int DuracaoEmMin { get; private set; }

        public Servico(int id)
        {
            Id = id;
        }
        public static Servico Criar(int idServico, string nome, decimal preco, string descricao, int duracaoEmMin)
        {
            var servico = new Servico(idServico);
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

        public void AlterarNomePreco(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
        }

        public void AlterarPreco(decimal preco)
        {
            Preco = preco;
        }

        public void AlterarDescreicao(string descricao)
        {
            Descricao = descricao;
        }

        public void AlterarDuracao(int duracaoEmMin)
        {
            DuracaoEmMin = duracaoEmMin;
        }
    }
}
