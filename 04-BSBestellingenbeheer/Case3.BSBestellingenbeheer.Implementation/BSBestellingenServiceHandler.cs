using Case3.BSBestellingenbeheer.Contract;
using Case3.BSBestellingenbeheer.DAL.Context;
using Case3.BSBestellingenbeheer.Implementation.Interfaces;
using Case3.BSBestellingenbeheer.Implementation.Managers;
using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.BSCatalogusBeheer.Schema.ProductNS;
using System;
using System.Data.Entity;

namespace Case3.BSBestellingenbeheer.Implementation
{
    public class BSBestellingenServiceHandler : IBSBestellingenbeheerService
    {
        private IBestellingManager _bestellingManager;

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

            _bestellingManager = new BestellingManager();
        }

        /// <summary>
        /// Creates instance of class but with mock possible
        /// </summary>
        /// <param name="bestellingManager"></param>
        public BSBestellingenServiceHandler(IBestellingManager bestellingManager)
        {
            _bestellingManager = bestellingManager;
        }


        /// <summary>
        /// Get firstbestelling from bestellingmanager
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public FindFirstBestellingResultMessage FindFirstBestelling(FindFirstBestellingRequestMessage requestMessage)
        {
            return new FindFirstBestellingResultMessage()
            {
                BestellingOpdracht = _bestellingManager.FindFirstBestelling()
            };
        }
    }
}
