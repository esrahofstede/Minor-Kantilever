using Case3.BSBestellingenbeheer.Contract;
using Case3.BSBestellingenbeheer.DAL.Context;
using Case3.BSBestellingenbeheer.DAL.DataMappers;
using Case3.BSBestellingenbeheer.DAL.Exceptions;
using Case3.BSBestellingenbeheer.Implementation.Interfaces;
using Case3.BSBestellingenbeheer.Implementation.Managers;
using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.BSCatalogusBeheer.Schema.ProductNS;
using Case3.Common.Faults;
using System;
using System.Data.Entity;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Case3.BSBestellingenbeheer.Implementation
{
    /// <summary>
    /// Handler class for the BSBestellingenService
    /// </summary>
    public class BSBestellingenServiceHandler : IBSBestellingenbeheerService
    {
        private BestellingDataMapper _mapper;
        private BestellingManager _bestellingManager;

        [DataMember]
        private ErrorLijst _list = new ErrorLijst();

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
            _mapper = new BestellingDataMapper();
        }

        /// <summary>
        /// Creates instance of class but with mock possible
        /// </summary>
        /// <param name="bestellingManager"></param>
        public BSBestellingenServiceHandler(BestellingDataMapper mapper, BestellingManager bestellingManager)
        {
            _mapper = mapper;
            _bestellingManager = bestellingManager;
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
                BestellingOpdracht = _bestellingManager.ConvertBestellingEntityToDTO(firstBestelling),
            };
        }

        /// <summary>
        /// Method to insert a bestelling to the database. Could throw a FaultException with ErrorLijst list.
        /// </summary>
        /// <param name="bestelling">The request message containing the Bestelling to insert</param>
        /// <returns>Returns an InsertBestellingResultMessage if succesful. Else null.</returns>
        public InsertBestellingResultMessage InsertBestelling(InsertBestellingRequestMessage request)
        {
            if (request.Bestelling != null)
            {
                try
                {
                    _bestellingManager.InsertBestelling(request.Bestelling);
                    return new InsertBestellingResultMessage();
                }
                catch(Exception ex)
                {
                    _list.Add(new ErrorDetail()
                    {
                        ErrorCode = 2,
                        Message = ex.Message,
                    });
                }
                if (_list.Count > 0)
                {
                    throw new FaultException<ErrorLijst>(_list, "Er is iets fout gegaan tijdens het toevoegen van een bestelling. Zie de innerdetails voor meer informatie.");
                }
            }
            return null;
        }

        public UpdateBestellingStatusResultMessage UpdateBestellingStatus(UpdateBestellingStatusRequestMessage bestelling)
        {
            if (bestelling != null)
            {
                BestellingDataMapper mapper = new BestellingDataMapper();
                mapper.UpdateBestellingStatusToPacked(bestelling.BestellingID);
                return new UpdateBestellingStatusResultMessage();
            }
            else
            {
                throw new ArgumentNullException("Er is geen bestelling opgegeven."); //FAULTEXCEPTION!!
            }
        }
    }
}
