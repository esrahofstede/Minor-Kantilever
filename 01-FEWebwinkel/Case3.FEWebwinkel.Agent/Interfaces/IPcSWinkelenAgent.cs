using Case3.PcSWinkelen.Schema;
using case3bsbestellingenbeheer.v1.schema;

namespace Case3.FEWebwinkel.Agent.Interfaces
{
    /// <summary>
    /// The interface for the PcSWinkelenAgent
    /// </summary>
    public interface IPcSWinkelenAgent
    {
        /// <summary>
        /// This function returns the complete CatalogusCollection
        /// </summary>
        /// <returns>The Complete CatalogusCollection</returns>
        CatalogusCollection GetProducts();
        /// <summary>
        /// This function calls the PcSWinkelen to get the products based on the page and pagesize
        /// </summary>
        /// <param name="page">this is the pagenumber</param>
        /// <param name="pageSize">this is the pagesize</param>
        /// <returns></returns>
        CatalogusCollection GetProducts(int page, int pageSize);
        /// <summary>
        /// Gets the current Winkelmand
        /// </summary>
        /// <param name="sessionId">The session ID to find the correct Winkelmand</param>
        /// <returns>A WinkelmandCollection containing all items in the Winkelmand</returns>
        WinkelMandCollection GetWinkelmand(string sessionId);
        /// <summary>
        /// Adds a Product to the Winkelmand
        /// </summary>
        /// <param name="productId">The product to add to the Winkelmand</param>
        /// <param name="sessionId">The session ID of the current user</param>
        /// <returns>A boolean that shows if the product was successfully added</returns>
        bool AddProductToWinkelmand(int productId, string sessionId);
        /// <summary>
        /// Sends a Bestelling
        /// </summary>
        /// <param name="sessionId">The session ID to get the Winkelmand data</param>
        /// <param name="klant">The Klant data</param>
        /// <param name="btwPercentage">The current Btw-percentage</param>
        void SendBestelling(string sessionId, Klantgegevens klant, int btwPercentage);
    }
}
