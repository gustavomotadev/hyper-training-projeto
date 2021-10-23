namespace TechBeauty.Dominio.Modelo
{
    public class TipoContato
    {
        public int Id { get; init; }
        public string Valor { get; init; }

        public TipoContato(int id, string valor)
        {
            Id = id;
            Valor = valor;
        }

        public static TipoContato AdicionarTipoContato(int idTipoContato, string valor)
        {
            var tipoContato = new TipoContato(idTipoContato, valor);
            
            return tipoContato;
        }
        
    }
}
