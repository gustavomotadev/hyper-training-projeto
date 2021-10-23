namespace TechBeauty.Dominio.Modelo
{
    public class RegimeContratual
    {
        public int Id { get; init; }
        public string TipoRegimeContratual { get; init; }

        private RegimeContratual(int id, string tipoRegimeContratual)
        {
            Id = id;
            TipoRegimeContratual = tipoRegimeContratual;
        }

        public static RegimeContratual AdicionarRegimeContratual(int idRegimeContratual, string tipoRegimeContratual) => 
            new RegimeContratual(idRegimeContratual, tipoRegimeContratual);

    }
}
