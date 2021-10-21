using TechBeauty.Dominio.Modelo.Enumeradores;

namespace TechBeauty.Dominio.Modelo
{
    public class OrdemServico
    {
        public int Id { get; private set; }
        public decimal PrecoTotal { get; private set; }
        public int DuracaoTotal { get; private set; }
        public Cliente Cliente { get; private set; }
        
        //Não sei se cabe o private já que o enum é fixo.
        public StatusOS StatusOS { get; private set; }

        public static OrdemServico Criar(int id, decimal precoTotal, 
            int duracaoTotal, Cliente cliente, StatusOS statusOs)
        {
            var os = new OrdemServico();
            os.Id = id;
            os.PrecoTotal = precoTotal;
            os.DuracaoTotal = duracaoTotal;
            os.Cliente = cliente;
            os.StatusOS = statusOs;
            return os;
        }

        public void Alterar(decimal precoTotal,
            int duracaoTotal, Cliente cliente, StatusOS statusOs)
        {
            PrecoTotal = precoTotal;
            DuracaoTotal = duracaoTotal;
            Cliente = cliente;
            StatusOS = statusOs;
        }
    }
}
