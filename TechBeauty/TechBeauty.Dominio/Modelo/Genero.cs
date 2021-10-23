namespace TechBeauty.Dominio.Modelo
{
    public class Genero
    {
        public int Id { get; init; }
        public string Valor { get; init; }

        public Genero(int id, string valor)
        {
            Id = id;
            Valor = valor;
        }

        public static Genero Criar(int idGenero, string valorGenero)
        {
            var genero = new Genero(idGenero, valorGenero);
            
            return genero;
        }

        
    }
}
