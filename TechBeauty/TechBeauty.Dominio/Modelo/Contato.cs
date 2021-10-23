namespace TechBeauty.Dominio.Modelo
{
    public class Contato
    {
        public int Id { get; init; }
        public TipoContato Tipo { get; init; }
        public string Valor { get; private set; }

        private Contato(int id, TipoContato tipo)
        {
            Id = id;
            Tipo = tipo;
        }
        public static Contato NovoContato(int idContato, TipoContato tipo, string valor)
        {
            var contato = new Contato(idContato, tipo);
            contato.Valor = valor;
            return contato;
        }
        public void AlterarContato(string novoValor)
        {
            Valor = novoValor;
        }

    }
}
