namespace TechBeauty.Dominio.Modelo
{
    public class Cargo
    {
        public int Id { get; init; }
        public string NomeCargo { get; private set; }
        public string Descricao { get; private set; }

        public Cargo(int id)
        {
            Id = id;
        }

        public static Cargo NovoCargo(int idCargo, string nome, string descricao)
        {
            var cargo = new Cargo(idCargo);
            cargo.NomeCargo = nome;
            cargo.Descricao = descricao;
            return cargo;
        }

        public void AlterarNome(string nome)
        {
            NomeCargo = nome;
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }
    }
}
