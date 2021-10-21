namespace TechBeauty.Dominio.Modelo
{
    public class TipoContato
    {
        public int Id { get; private set; }
        public string Valor { get; private set; }

        public static TipoContato Criar(int id, string valor)
        {
            var tipoContato = new TipoContato();
            tipoContato.Id = id;
            tipoContato.Valor = valor;
            return tipoContato;
        }
        public void Alterar(int id, string valor)
        {
            Valor = valor;
        }
    }
}
