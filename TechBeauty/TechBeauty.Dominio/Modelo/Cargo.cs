namespace TechBeauty.Dominio.Modelo
{
    public class Cargo
    {
        public int Id { get; init; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public Cargo(int id)
        {
            Id = id;
        }

        public static Cargo Criar(int idCargo, string nome, string descricao)
        {
            var cargo = new Cargo(idCargo);
            cargo.Nome = nome;
            cargo.Descricao = descricao;
            return cargo;
        }

        public void Alterar(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}
