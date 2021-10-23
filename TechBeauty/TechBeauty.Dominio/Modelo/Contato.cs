namespace TechBeauty.Dominio.Modelo
{
    public class Contato
    {
        public int Id { get; init; }
        public TipoContato Tipo { get; private set; }
        public string Valor { get; private set; }

        public Contato(int id)
        {
            Id = id;
        }
        public static Contato NovoContato(int idContato, TipoContato tipo, string valor)
        {
            var contato = new Contato(idContato);
            contato.Tipo = tipo;
            contato.Valor = valor;
            return contato;
        }
        public void Alterar(TipoContato tipo, string valor)
        {

            Tipo = tipo;
            Valor = valor;
        }

    }
}
