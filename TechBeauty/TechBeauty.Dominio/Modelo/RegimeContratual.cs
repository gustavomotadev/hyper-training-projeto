namespace TechBeauty.Dominio.Modelo
{
    public class RegimeContratual
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public static RegimeContratual Criar(int id, string nome)
        {
            var regimeContratual = new RegimeContratual();
            regimeContratual.Id = id;
            regimeContratual.Nome = nome;
            return regimeContratual;
        }

        public void Alterar(int id, string nome)
        {
            Nome = nome;
        }
    }
}
