namespace TechBeauty.Dominio.Modelo
{
    public class Contato
    {
        public int Id { get; set; }
        public TipoContato Tipo { get; set; }
        public string Valor { get; set; }

        public static Contato Criar(int id, TipoContato tipo, string valor)
        {
            var contato = new Contato();
            contato.Id = id;
            contato.Tipo = tipo;
            contato.Valor = valor;
            return contato;
        }
    }
}
