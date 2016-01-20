using Case3.BSBestellingenbeheer.Contract;
using Case3.BSBestellingenbeheer.DAL.Context;
using Case3.BSBestellingenbeheer.DAL.DataMappers;
using Case3.BSBestellingenbeheer.Implementation.Interfaces;
using Case3.BSBestellingenbeheer.Implementation.Managers;
using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.BSCatalogusBeheer.Schema.ProductNS;
using System;
using System.Data.Entity;

namespace Case3.BSBestellingenbeheer.Implementation
{
    /// <summary>
    /// Handler class for the BSBestellingenService
    /// </summary>
    public class BSBestellingenServiceHandler : IBSBestellingenbeheerService
    {
        private BestellingDataMapper _mapper;
        private BestellingManager _manager;

        /// <summary>
        /// Creates instance and fills database for the first time
        /// </summary>
        public BSBestellingenServiceHandler()
        {
            Database.SetInitializer(new BestellingDbInitializerTemporary());
            using (var context = new BestellingContext())
            {
                context.Database.Initialize(false);
            }

            _mapper = new BestellingDataMapper();
        }

        /// <summary>
        /// Creates instance of class but with mock possible
        /// </summary>
        /// <param name="bestellingManager"></param>
        public BSBestellingenServiceHandler(BestellingDataMapper mapper)
        {
            _mapper = mapper;
        }


        /// <summary>
        /// Get firstbestelling from bestellingmanager
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public FindFirstBestellingResultMessage FindFirstBestelling(FindFirstBestellingRequestMessage requestMessage)
        {

            Entities.Bestelling firstBestelling = _mapper.GetBestellingToPack();

            return new FindFirstBestellingResultMessage()
            {
                BestellingOpdracht = _manager.ConvertBestellingEntityToDTO(firstBestelling),
            };
        }

        /// <summary>
        /// Inserts a bestelling to the database
        /// </summary>
        /// <param name="bestelling"></param>
        /// <returns></returns>
        public InsertBestellingResultMessage InsertBestelling(InsertBestellingRequestMessage request)
        {
            _bestellingManager.InsertBestelling(request.Bestelling);
            return new InsertBestellingResultMessage();  
        }

        public UpdateBestellingStatusResultMessage UpdateBestellingStatus(UpdateBestellingStatusRequestMessage bestelling)
        {
            BestellingDataMapper mapper = new BestellingDataMapper();
            mapper.UpdateBestellingStatusToPacked(bestelling.BestellingID);

            return new UpdateBestellingStatusResultMessage();
        }
    }
}
