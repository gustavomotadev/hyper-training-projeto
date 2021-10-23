namespace TechBeauty.Dominio.Modelo
{
    public class Endereco
    {
        public int Id { get; init; }
        public string Logradouro { get; private set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }

        public Endereco(int id )
        {
            Id = id;
        }
        public static Endereco Criar(int idEndereco, string logradouro, string cidade, string uf, string numero, string complemento)
        {
            var endereco = new Endereco(idEndereco);
            endereco.Logradouro = logradouro;
            endereco.Cidade = cidade;
            endereco.UF = uf;
            endereco.Numero = numero;
            endereco.Complemento = complemento;
            return endereco;
        }

        public void Alterar(string logradouro, string cidade, string uf, string numero, string complemento)
        {
            Logradouro = logradouro;
            Cidade = cidade;
            UF = uf;
            Numero = numero;
            Complemento = complemento;
        }
    }
}
