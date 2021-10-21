namespace TechBeauty.Dominio.Modelo
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        public static Endereco Criar(int id, string logradouro, string cidade, string uf, string numero, string complemento)
        {
            var endereco = new Endereco();
            endereco.Id = id;
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
