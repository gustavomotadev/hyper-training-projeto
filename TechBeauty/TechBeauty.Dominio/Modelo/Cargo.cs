namespace TechBeauty.Dominio.Modelo
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public static Cargo Criar(int id, string nome, string descricao)
        {
            var cargo = new Cargo();
            cargo.Id = id;
            cargo.Nome = nome;
            cargo.Descricao = descricao;
            return cargo;
        }
    }
}
