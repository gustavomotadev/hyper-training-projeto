namespace TechBeauty.Dominio.Modelo
{
    public class Endereco
    {
        public int Id { get; init; }
        public string Logradouro { get; private set; }
        public string Bairro { get; set; }
        public string Cidade { get; private set; }
        public string UF { get; private set; }
        public string Numero { get; private set; } = "s/n";
        public string Complemento { get; private set; } = string.Empty;
        public string CEP { get; set; }

        private Endereco(int id)
        {
            Id = id;
        }

        public static Endereco NovoEndereco(int idEndereco, string logradouro, string numero, string bairro,
            string cidade, string uf, string cep, string complemento)
        {
            var endereco = new Endereco(idEndereco);
            endereco.Logradouro = logradouro;
            endereco.Numero = numero;
            endereco.Bairro = bairro;
            endereco.Cidade = cidade;
            endereco.UF = uf;
            endereco.CEP = cep;
            endereco.Complemento = complemento;
            return endereco;
        }

        public void MudarEndereco(string logradouro, string numero, string bairro,
            string cidade, string uf, string cep, string complemento)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
            CEP = cep;
            Complemento = complemento;
        }

        public void MudarDeCidade(string logradouro, string numero, string bairro,
            string cidade, string complemento)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Complemento = complemento;
        }

        public void MudarDeLogradouro(string logradouro, string numero, string bairro,
            string complemento)
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Complemento = complemento;
        }

        public void MudarNumeroEComplemento(string numero, string complemento)
        {
            Numero = numero;
            Complemento = complemento;
        }
    }
}
