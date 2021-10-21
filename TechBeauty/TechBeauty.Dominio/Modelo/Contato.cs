namespace TechBeauty.Dominio.Modelo
{
    public class Contato
    {
        public int Id { get; private set; }
        public TipoContato Tipo { get; private set; }
        public string Valor { get; private set; }

        public static Contato Criar(int id, TipoContato tipo, string valor)
        {
            var contato = new Contato();
            contato.Id = id;
            contato.Tipo = tipo;
            contato.Valor = valor;
            return contato;
        }
        public void Alterar(int id, TipoContato tipo, string valor)
        {

            Tipo = tipo;
            Valor = valor;
        }

    }
}
