using System.Collections.Generic;

namespace TechBeauty.Dominio.Modelo
{
    public class Colaborador
    {
        public string CarteiraTrabalho { get; private set; }
        public List<Servico> Servicos { get; private set; }
        public Endereco Endereco { get; private set; }
        public Genero Genero { get; private set; }
        public string NomeSocial { get; private set; }
        public ContratoTrabalho Contrato { get; private set; }
    }
}
