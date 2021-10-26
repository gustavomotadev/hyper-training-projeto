using System;

namespace TechBeauty.Dominio.Modelo
{
    public class RegimeContratual
    {
        public int Id { get; init; }
        public string NomeRegimeContratual { get; init; }

        private RegimeContratual(int id, string nomeRegimeContratual)
        {
            Id = id;
            NomeRegimeContratual = nomeRegimeContratual;
        }

        public static RegimeContratual NovoRegimeContratual(int idRegimeContratual, string nomeRegimeContratual)
        {
            if (!String.IsNullOrWhiteSpace(nomeRegimeContratual))
            {
                return new RegimeContratual(idRegimeContratual, nomeRegimeContratual);
            }
            else
            {
                return null;
            }
        }
    }
}
