using Case3.PcSWinkelen.Schema;

namespace Case3.FEWebwinkel.Agent.Interfaces
{
    public interface IPcSWinkelenAgent
    {
        CatalogusCollection GetProducts();
        CatalogusCollection GetProducts(int page, int pageSize);
        WinkelMandCollection GetWinkelmand(string sessionId);

        bool AddProductToWinkelmand(int productId, string sessionId);

        void SendBestelling(string sessionId, KlantRegistreerViewModel klant);
    }
}
