namespace TechBeauty.Dominio.Modelo
{
    public class RegimeContratual
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public static RegimeContratual Criar(int id, string nome)
        {
            var regimeContratual = new RegimeContratual();
            regimeContratual.Id = id;
            regimeContratual.Nome = nome;
            return regimeContratual;
        }

        public void Alterar(string nome)
        {
            Nome = nome;
        }
    }
}
