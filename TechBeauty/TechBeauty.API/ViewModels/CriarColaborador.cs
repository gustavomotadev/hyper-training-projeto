using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechBeauty.API.ViewModels
{
    public class CriarColaborador
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

        public bool validarEndereco()
        {
            if (EnderecoId is null)
            {
                if (Logradouro is null ||
                    Bairro is null ||
                    Cidade is null ||
                    UF is null ||
                    CEP is null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
