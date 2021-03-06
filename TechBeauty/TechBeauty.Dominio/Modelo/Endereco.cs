using System;
using TechBeauty.Dominio.Modelo.Enumeracoes;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class Endereco
    {
        public int Id { get; init; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public UnidadeFederativa UF { get; private set; }
        public string Numero { get; private set; } = "s/n";
        public string Complemento { get; private set; }
        public string CEP { get; private set; }
        public List<Colaborador> Colaboradores { get; private set; } = new List<Colaborador>(); //ef

        private Endereco() { }

        public static Endereco NovoEndereco(string logradouro, string bairro,
            string cidade, UnidadeFederativa uf, string cep, string numero = "s/n", string complemento = null)
        {

            var endereco = new Endereco();
            endereco.Logradouro = logradouro;
            if (String.IsNullOrWhiteSpace(numero))
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
            if (String.IsNullOrWhiteSpace(complemento))
            {
                endereco.Complemento = string.Empty;
            }
            else
            {
                endereco.Complemento = complemento;
            }
            return endereco;
        }

        public bool MudarDeEndereco(string novoLogradouro, string novoNumero, string novoBairro,
            string novaCidade, UnidadeFederativa uf, string novoCep, string novoComplemento)
        {
            if (novoLogradouro != null &&
                !String.IsNullOrWhiteSpace(novoLogradouro) &&
                novoNumero != null &&
                !String.IsNullOrWhiteSpace(novoNumero) &&
                novoBairro != null &&
                !String.IsNullOrWhiteSpace(novoBairro) &&
                novaCidade != null &&
                !String.IsNullOrWhiteSpace(novaCidade) &&
                novoCep != null &&
                !String.IsNullOrWhiteSpace(novoCep))
            {
                Logradouro = novoLogradouro;
                Numero = novoNumero;
                Bairro = novoBairro;
                Cidade = novaCidade;
                UF = uf;
                CEP = novoCep;
                if (String.IsNullOrWhiteSpace(novoComplemento))
                {
                    Complemento = string.Empty;
                }
                else
                {
                    Complemento = novoComplemento;
                }
                return true;
            }

            return false;
            
        }

        public bool MudarDeCidade(string novoLogradouro, string novoNumero, string novoBairro,
            string novaCidade, string novoCep, string novoComplemento)
        {

            if (novoLogradouro != null &&
                !String.IsNullOrWhiteSpace(novoLogradouro) &&
                novoNumero != null &&
                !String.IsNullOrWhiteSpace(novoNumero) &&
                novoBairro != null &&
                !String.IsNullOrWhiteSpace(novoBairro) &&
                novaCidade != null &&
                !String.IsNullOrWhiteSpace(novaCidade) &&
                novoCep != null &&
                !String.IsNullOrWhiteSpace(novoCep))
            {
                Logradouro = novoLogradouro;
                Numero = novoNumero;
                Bairro = novoBairro;
                Cidade = novaCidade;
                CEP = novoCep;
                if (String.IsNullOrWhiteSpace(novoComplemento))
                {
                    Complemento = string.Empty;
                }
                else
                {
                    Complemento = novoComplemento;
                }
                return true;
            }

            return false;
        }

        public bool MudarDeLogradouro(string novoLogradouro, string novoNumero, string novoBairro,
            string novoCep, string novoComplemento)
        {
            if (novoLogradouro != null &&
                !String.IsNullOrWhiteSpace(novoLogradouro) &&
                novoNumero != null &&
                !String.IsNullOrWhiteSpace(novoNumero) &&
                novoBairro != null &&
                !String.IsNullOrWhiteSpace(novoBairro) &&
                novoCep != null &&
                !String.IsNullOrWhiteSpace(novoCep))
            {
                Logradouro = novoLogradouro;
                Numero = novoNumero;
                Bairro = novoBairro;
                CEP = novoCep;
                if (String.IsNullOrWhiteSpace(novoComplemento))
                {
                    Complemento = string.Empty;
                }
                else
                {
                    Complemento = novoComplemento;
                }
                return true;
            }

            return false;
        }

        public bool MudarNumeroEComplemento(string novoNumero, string novoComplemento)
        {

            if (novoNumero != null &&
                !String.IsNullOrWhiteSpace(novoNumero))
            {
                Numero = novoNumero;
                if (String.IsNullOrWhiteSpace(novoComplemento))
                {
                    Complemento = string.Empty;
                }
                else
                {
                    Complemento = novoComplemento;
                }
                return true;
            }

            return false;
        }
    }
}
