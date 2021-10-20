using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class Colaborador
    {
        public string CarteiraTrabalho { get; set; }
        public List<Servico> Servicos { get; set; }
        public Endereco Endereco { get; set; }
        public Genero Genero { get; set; }
        public string NomeSocial { get; set; }
        public ContratoTrabalho Contrato { get; set; }
    }
}
