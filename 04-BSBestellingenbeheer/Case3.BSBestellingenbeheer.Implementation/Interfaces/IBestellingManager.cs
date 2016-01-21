using Case3.BSBestellingenbeheer.V1.Schema;

namespace Case3.BSBestellingenbeheer.Implementation.Interfaces
{
    /// <summary>
    /// This interface is used to manage bestellingen
    /// </summary>
    public interface IBestellingManager
    {
        /// <summary>
        /// Converts a BEstelling to DTO
        /// </summary>
        /// <returns>BestellingDTO</returns>
        Bestelling ConvertBestellingEntityToDTO(Entities.Bestelling bestellingEntity);

        /// <summary>
        /// Inserts a new bestelling
        /// </summary>
        /// <param name="bestelling">The bestelling which should be inserted</param>
        void InsertBestelling(Bestelling bestelling);
    }
}
