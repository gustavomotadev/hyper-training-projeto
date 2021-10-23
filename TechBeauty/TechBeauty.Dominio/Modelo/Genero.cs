namespace TechBeauty.Dominio.Modelo
{
    public class Genero
    {
        public int Id { get; init; }
        public string Valor { get; init; }

        private Genero(int id, string valor)
        {
            Id = id;
            Valor = valor;
        }

        public static Genero AdicionarGenero(int idGenero, string valorGenero) =>
            new Genero(idGenero, valorGenero);
        
    }
}
