using Case3.BSBestellingenbeheer.Contract;
using Case3.BSBestellingenbeheer.DAL.DataMappers;
using Case3.BSBestellingenbeheer.DAL.Exceptions;
using Case3.BSBestellingenbeheer.Implementation.Interfaces;
using Case3.BSBestellingenbeheer.Implementation.Managers;
using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.Common.Faults;
using log4net;
using System;
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
        private IBestellingManager _bestellingManager;
        private static ILog _logger = LogManager.GetLogger(typeof(BSBestellingenServiceHandler));

        [DataMember]
        private ErrorLijst _list = new ErrorLijst();

        /// <summary>
        /// Creates instance and fills database for the first time
        /// </summary>
        public BSBestellingenServiceHandler()
        {
            _bestellingManager = new BestellingManager();
            _mapper = new BestellingDataMapper();
        }

        /// <summary>
        /// Creates instance of class but with mock possible
        /// </summary>
        /// <param name="mapper">BestellingDataMapper mock</param>
        /// <param name="bestellingManager">BestellingManager mock</param>
        public BSBestellingenServiceHandler(BestellingDataMapper mapper, IBestellingManager bestellingManager)
        {
            _mapper = mapper;
            _bestellingManager = bestellingManager;
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// Constructor with only a BestellingDataMapper as a mock
        /// </summary>
        /// <param name="mapper">A custom BestellingDataMapper</param>
        public BSBestellingenServiceHandler(BestellingDataMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Get firstbestelling from bestellingmanager
        /// </summary>
        /// <param name="requestMessage">RequestMessage to find the next bestelling</param>
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Case3.Common.Faults.ErrorDetail.set_Message(System.String)")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public InsertBestellingResultMessage InsertBestelling(InsertBestellingRequestMessage bestelling)
        {

            if (bestelling != null && bestelling.Bestelling != null)
            {
                try
                {
                        _bestellingManager.InsertBestelling(bestelling.Bestelling);
                }
                    catch (TechnicalException ex)
                    {
                        _list.Add(new ErrorDetail()
                        {
                            ErrorCode = 2,
                            Message = ex.Message,
                        });
                        _logger.Fatal(ex.Message, ex);
                    }
                    catch (FunctionalException ex)
                    {
                        _list.Add(new ErrorDetail()
                        {
                            ErrorCode = 2,
                            Message = ex.Message,
                        });
                    }
                    catch (Exception ex)
                    {
                        _list.Add(new ErrorDetail()
                        {
                            ErrorCode = 2,
                            Message = ex.Message,
                        });
                    }
                    if (_list.Count > 0)
                {
                    throw new FaultException<ErrorLijst > (_list, "Er is iets fout gegaan tijdens het toevoegen van een bestelling. Zie de innerdetails voor meer informatie.");
                }
            }
            else
            {
                _list.Add(new ErrorDetail()
                {
                    ErrorCode = 2,
                    Message = "Bad request",
                });

                throw new FaultException<ErrorLijst>(_list, "Er is iets fout gegaan tijdens het toevoegen van een bestelling. Zie de innerdetails voor meer informatie.");
            }
            return new InsertBestellingResultMessage();
        }

        /// <summary>
        /// Updates the bestellings
        /// </summary>
        /// <param name="bestelling">The bestelling to update</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Case3.Common.Faults.ErrorDetail.set_Message(System.String)")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        public UpdateBestellingStatusResultMessage UpdateBestellingStatus(UpdateBestellingStatusRequestMessage bestelling)
        {
            if (bestelling != null)
            {
                try
                {
                    _mapper.UpdateBestellingStatusToPacked(bestelling.BestellingID);
            }
                catch (TechnicalException ex)
                {
                    _list.Add(new ErrorDetail()
                    {
                        ErrorCode = 2,
                        Message = ex.Message,
                    });
                    _logger.Fatal(ex.Message, ex);
                }
                catch (FunctionalException ex)
                {
                    _list.Add(new ErrorDetail()
                    {
                        ErrorCode = 2,
                        Message = ex.Message,
                    });
                }
                catch (Exception ex)
                {
                    _list.Add(new ErrorDetail()
                    {
                        ErrorCode = 2,
                        Message = ex.Message,
                    });
                }
                if (_list.Count > 0)
                {
                    throw new FaultException<ErrorLijst>(_list, "Er is iets fout gegaan tijdens het aanpassen van de status van een bestelling. Zie de innerdetails voor meer informatie.");
                }
            }
            else
            {
                _list.Add(new ErrorDetail()
                {
                    ErrorCode = 2,
                    Message = "Bad request",
                });

                throw new FaultException<ErrorLijst>(_list, "Er is iets fout gegaan tijdens het aanpassen van de status van een bestelling. Zie de innerdetails voor meer informatie.");

            }
            return new UpdateBestellingStatusResultMessage();
        }
    }
}
