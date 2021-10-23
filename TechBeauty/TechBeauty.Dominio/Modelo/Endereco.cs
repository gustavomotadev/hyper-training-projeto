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
        public string Complemento { get; private set; }
        public string CEP { get; set; }

        private Endereco(int id)
        {
            Id = id;
        }

        public static Endereco NovoEndereco(int idEndereco, string logradouro, string bairro,
            string cidade, string uf, string cep, string numero = "s/n", string complemento = null)
        {
            var endereco = new Endereco(idEndereco);
            endereco.Logradouro = logradouro;
            if (string.IsNullOrEmpty(numero))
            {
                endereco.Numero = "s/n";
            }
            else
            {
                endereco.Numero = numero;
            }
            endereco.Bairro = bairro;
            endereco.Cidade = cidade;
            endereco.UF = uf;
            endereco.CEP = cep;
            if (string.IsNullOrEmpty(complemento))
            {
                endereco.Complemento = string.Empty;
            }
            else 
            {
                endereco.Complemento = complemento;
            }
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
