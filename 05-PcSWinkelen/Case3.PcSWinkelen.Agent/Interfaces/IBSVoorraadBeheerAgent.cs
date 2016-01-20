namespace Case3.PcSWinkelen.Agent.Interfaces
{
    /// <summary>
    /// Interface for the BSVoorraadBeheerAgent 
    /// </summary>
    public interface IBSVoorraadBeheerAgent
    {
        /// <summary>
        /// This method retrieves the actual voorraad for the input product.
        /// </summary>
        /// <param name="productId">Optional productId from a product, which identifies the product.</param>
        /// <param name="leveranciersProductId">The ProductId, specific for the leverancier from the product.</param>
        /// <returns></returns>
        int GetProductVoorraad(int? productId, string leveranciersProductId);
    }
}
