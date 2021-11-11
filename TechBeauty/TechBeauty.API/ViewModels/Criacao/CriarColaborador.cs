using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using TechBeauty.API.Interfaces;
using TechBeauty.Dominio.Financeiro;
using TechBeauty.Dominio.Modelo;
using TechBeauty.Dominio.Modelo.Enumeracoes;

namespace TechBeauty.API.ViewModels
{
    public class CriarColaborador : IValidavel
    {
        //Dados de Pessoa
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }

        //Contato obrigatório
        [Required]
        public int TipoContato1Id { get; set; }
        [Required]
        public string Contato1 { get; set; }

        //Contatos opcionais
        public int? TipoContato2Id { get; set; }
        public string Contato2 { get; set; }
        public int? TipoContato3Id { get; set; }
        public string Contato3 { get; set; }

        //Dados de Colaborador
        public string NomeSocial { get; set; } = String.Empty;
        [Required]
        public List<int> IdServicos { get; set; }
        [Required]
        public int GeneroId { get; set; }

            //Dados do Padrão Remuneração
        [Required]
        public TimeSpan JornadaEsperada { get;  set; }
        [Required]
        public decimal SalarioHora { get;  set; }
        [Required]
        public decimal PercentualComissao { get;  set; }
        [Required]
        public decimal AdicionalHoraExtra { get;  set; }

            //Dados do Contrato
        [Required]
        public int RegimeContratualId { get; set; }
        [Required]
        public DateTime DataEntrada { get; set; }
        public DateTime? DataDesligamento { get;  set; }
        [Required]
        public List<int> IdCargos { get; set; } 
        [Required]
        public string CNPJ_CTPS { get; set; }

            //Dados do Endereço
        public int? EnderecoId { get; set; }
        
        public string Logradouro { get;  set; }
        public string Bairro { get; set; }
        public string Cidade { get;  set; }
        public int? UF { get;  set; }
        public string Numero { get;  set; } = "s/n";
        public string Complemento { get; set; } = "";
        public string CEP { get; set; }

        //TODO VALIDAR CPF
        public bool Validar()
        {
            return (!String.IsNullOrWhiteSpace(Nome) &&
                !String.IsNullOrWhiteSpace(CPF) &&
                Pessoa.ObterIdade(DataNascimento) >= 18 &&
                Pessoa.ObterIdade(DataNascimento) <= 100 &&
                ValidarContatos() &&
                ValidarEndereco() &&
                ValidarPadraoRemuneracao() &&
                ValidarContrato());
        }

        public bool ValidarContatos()
        {
            return (!String.IsNullOrWhiteSpace(Contato1) &&
                ((TipoContato2Id is null && Contato2 is null) || (TipoContato2Id is not null && !String.IsNullOrWhiteSpace(Contato2))) &&
                ((TipoContato3Id is null && Contato3 is null) || (TipoContato3Id is not null && !String.IsNullOrWhiteSpace(Contato3))));
        }

        public bool ValidarEndereco()
        {
            if (EnderecoId is null)
            {
                if (!String.IsNullOrWhiteSpace(Logradouro) &&
                    !String.IsNullOrWhiteSpace(Bairro) &&
                    !String.IsNullOrWhiteSpace(Cidade) &&
                    !String.IsNullOrWhiteSpace(CEP) &&
                    ValidarCEP() &&
                    UF is not null &&
                    Enum.IsDefined(typeof(UnidadeFederativa), UF))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public bool ValidarCEP()
        {
            return Regex.IsMatch(CEP, @"^\d{8}$");
        }

        public bool ValidarPadraoRemuneracao()
        {
            return (JornadaEsperada <= PadraoRemuneracao.JornadaMaxima &&
                SalarioHora > 0 &&
                PercentualComissao < 1 &&
                PercentualComissao >= 0 &&
                AdicionalHoraExtra < 1 &&
                AdicionalHoraExtra >= PadraoRemuneracao.AdicionalHoraExtraMinimo);
        }
        
        //TODO VALIDAR CNPJCTPS
        public bool ValidarContrato()
        {
            return (!String.IsNullOrWhiteSpace(CNPJ_CTPS) &&
                ((DataDesligamento != null && DataDesligamento > DataEntrada) || DataDesligamento == null));
        }
    }
}
