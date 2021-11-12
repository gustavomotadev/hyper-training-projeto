using System;
using System.ComponentModel.DataAnnotations;
using TechBeauty.API.Interfaces;

namespace TechBeauty.API.ViewModels.Criacao
{
    public class CriarAgendamento : IValidavel
    {
        [Required]
        public int ServicoId { get; set; }
        [Required]
        public int ColaboradorId { get; set; }
        [Required]
        public int OrdemServicoId { get; set; }
        [Required]
        public int ExpedienteId { get; set; }
        [Required]
        public string PessoaAtendida { get; set; }
        [Required]
        public DateTime DataHoraExecucao { get; set; }

        public bool Validar()
        {
            return (!String.IsNullOrWhiteSpace(PessoaAtendida));
        }
    }
}
