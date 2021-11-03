﻿using System;
using System.ComponentModel.DataAnnotations;

namespace TechBeauty.API.ViewModels
{
    public class CriarAgendamento
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
    }
}