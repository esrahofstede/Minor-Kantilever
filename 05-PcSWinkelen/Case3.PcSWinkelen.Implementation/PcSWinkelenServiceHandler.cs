using Case3.PcSWinkelen.Agent.Managers;
using Case3.PcSWinkelen.Contract;
using Case3.PcSWinkelen.MessagesNS;
using Case3.PcSWinkelen.SchemaNS;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Case3.PcSWinkelen.Agent.Agents;
using Case3.PcSWinkelen.Agent.Interfaces;
using Case3.PcSWinkelen.DAL.Mappers;
using Case3.PcSWinkelen.Implementation.Mappers;
using Case3.PcSWinkelen.Schema.ProductNS;
using log4net;
using System.ServiceModel;
using System.Web.Hosting;
using DTOSchema = Case3.PcSWinkelen.SchemaNS;
using case3common.v1.faults;
using System.Runtime.Serialization;
using System.Linq.Expressions;
using Case3.PcSBestellen.SchemaNS;

namespace Case3.PcSWinkelen.Implementation
{
    public class PcSWinkelenServiceHandler : IPcSWinkelenService
    {
        /// <summary>
        /// The logger for logging exceptions
        /// </summary>
        private static ILog _logger = LogManager.GetLogger(typeof(PcSWinkelenServiceHandler));

        [DataMember]
        private ErrorLijst _list = new ErrorLijst();

        private IWinkelmandDataMapper _winkelmandDataMapper;
        private IWinkelmandItemDTOMapper _winkelmandItemDTOMapper;
        private IBSCatalogusBeheerAgent _catalogusBeheerAgent;
        private IPcSBestellenAgent _bestellenAgent;

        /// <summary>
        /// Custom constructor for testing purposes
        /// </summary>
        /// <param name="dataMapper">The winkelmand datamapper which is to be used. Must implement IWinkelmandDataMapper</param>
        /// <param name="catalogusBeheerAgent">The winkelmand agent which is to be used. Must implement IBSCatalogusBeheerAgent</param>
        /// <param name="dtoMapper">The DTO mapper which is to be used. Must implement IWinkelmandItemDTOMapper</param>
        /// <param name="bestellenAgent"></param>
        public PcSWinkelenServiceHandler(
            IWinkelmandDataMapper dataMapper, 
            IBSCatalogusBeheerAgent catalogusBeheerAgent,
            IWinkelmandItemDTOMapper dtoMapper,
            IPcSBestellenAgent bestellenAgent)
        {
            _winkelmandItemDTOMapper = dtoMapper;
            _winkelmandDataMapper = dataMapper;
            _catalogusBeheerAgent = catalogusBeheerAgent;
            _bestellenAgent = bestellenAgent;
            log4net.Config.XmlConfigurator.Configure();
        }

        //[ExcludeFromCodeCoverage]
        /// <summary>
        /// Default constructor which implements default mappers and agents.
        /// </summary>
        public PcSWinkelenServiceHandler()
        {
            log4net.Config.XmlConfigurator.Configure();
            _winkelmandDataMapper = new WinkelmandDataMapper();
            _winkelmandItemDTOMapper = new WinkelmandItemDTOMapper();
            try
            {
            _catalogusBeheerAgent = new BSCatalogusBeheerAgent();
            }
            catch (TechnicalException ex)
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
                throw new FaultException<ErrorLijst>(_list, "Er heeft een fout plaatsgevonden in PcSWinkelen. Zie de innerdetails voor meer informatie.");
            }
            
        }

        /// <summary>
        /// Get list of Products with the Voorraad included
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public FindCatalogusResponseMessage GetCatalogusItems(FindCatalogusRequestMessage request)
        {
            CatalogusCollection catalogusCollection = new CatalogusCollection();
            if (request != null)
            {
                try
                {
                    CatalogusManager catalogusManager = new CatalogusManager();
                    IEnumerable<CatalogusProductItem> productVoorraadList = catalogusManager.GetVoorraadWithProductsList(request.Page, request.PageSize);
                    foreach (CatalogusProductItem productVoorraad in productVoorraadList)
            {
                catalogusCollection.Add(new CatalogusProductItem()
                {
                    Product = productVoorraad.Product,
                    Voorraad = productVoorraad.Voorraad
                });
            }
                }
                catch (TechnicalException ex)
                {
                    _list.Add(new ErrorDetail()
                {
                        ErrorCode = 2,
                        Message = ex.Message,
                        Data = ex.Data
                    });
                }
                catch (Exception ex)
                    {
                    _list.Add(new ErrorDetail()
                        {
                        ErrorCode = 2,
                        Message = ex.Message,
                        Data = ex.Data
                    });
                        }
                if (_list.Count > 0)
                {
                    throw new FaultException<ErrorLijst>(_list, "Er heeft een fout plaatsgevonden in PcSWinkelen. Zie de innerdetails voor meer informatie.");
                }
            }

            FindCatalogusResponseMessage findCatalogusResponseMessage = new FindCatalogusResponseMessage()
            {
                Products = catalogusCollection
            };
            return findCatalogusResponseMessage;
        }

        /// <summary>
        /// Voegt een winkelmand item toe aan de database.
        /// Haal het volledige product op uit de catalogus
        /// Als het item al bestaat wordt niet het aantal opgehoogd, maar een nieuwe toegevoegd.
        /// </summary>
        /// <param name="request">The request message with references to the user and the Product</param>
        /// <returns>Returns an AddItemToWinkelmandResponseMessage</returns>
        public AddItemToWinkelmandResponseMessage AddProductToWinkelmand(AddItemToWinkelmandRequestMessage request)
        {
            Product product;
            try
            {
                product = _catalogusBeheerAgent.GetProductById(request.WinkelmandItemRef.ProductId);
            }
            catch (CommunicationException ex)
            {
                _logger.Fatal("somthing went wrong", ex);
                throw new FaultException("Ophalen product ging niet");
            }


            var winkelmandItem = new DTOSchema.WinkelmandItem
            {
                Product = product,
                Aantal = request.WinkelmandItemRef.Aantal,
                SessieId = request.WinkelmandItemRef.SessieId
            };

            var itemToInsert = _winkelmandItemDTOMapper.MapDTOToEntity(winkelmandItem);
            //var duplicates = _winkelmandDataMapper.FindAllBy(i => i.ID == itemToInsert.ID 
            //                                                && i.SessieID == itemToInsert.SessieID)
            //                                                .ToList();
            //if (duplicates.Count > 0) //item is already in Winkelmand
            //{
            //    //update
            //    itemToInsert.Aantal++;
            //    _winkelmandDataMapper.Update(itemToInsert);

            //}
            //else
            //{
            try
            {
            _winkelmandDataMapper.Insert(itemToInsert);
            }
            catch (Exception ex)
            {
                _logger.Fatal("Database fout", ex);
                throw new FaultException(ex.InnerException.Message);
            }

            return new AddItemToWinkelmandResponseMessage { Succeeded = true };
        }

        /// <summary>
        /// Gets all items from the winkelmand in the database
        /// </summary>
        /// <param name="request">The request containing the session id</param>
        /// <returns>The response message with all Winkelmand Items</returns>
        public GetWinkelmandResponseMessage GetWinkelmand(GetWinkelmandRequestMessage request)
        {
            var response = new GetWinkelmandResponseMessage();
            response.WinkelmandCollection = new WinkelMandCollection();
            response.SessieId = request.SessieId;
            try
            {
            var winkelmandItems = _winkelmandDataMapper.FindAllBy(w => w.SessieID == request.SessieId).ToList();

            foreach (var winkelmandItem in winkelmandItems)
            {
                try
                {
                    response.WinkelmandCollection.Add(_winkelmandItemDTOMapper.MapEntityToDTO(winkelmandItem));
                }
                catch (NullReferenceException)
                {
                    throw new FaultException("DTOMapping couldn't be completed for item: " + winkelmandItem.Naam + " with id: " + winkelmandItem.ProductID);
                }
                
            }

            }
            catch (Exception ex)
            {
                _logger.Fatal("Something went wrong", ex);
                throw new FaultException("Product items couldn't be retrieved");
            }

            return response;
        }

        /// <summary>
        /// Cals the agent PcSBestellen
        /// Retrieves the winkelmanditems from the database
        /// Sends all the items to the PcSBestellen
        /// </summary>
        /// <param name="bestelling">The session id of the client</param>
        /// <returns></returns>
        public WinkelmandBestellenResponseMessage WinkelmandBestellen(WinkelmandBestellenRequestMessage bestelling)
        {
            var response = new WinkelmandBestellenResponseMessage();
            var bestelItem = _winkelmandDataMapper.FindAllBy(wi => wi.SessieID == bestelling.SessieId);
            _bestellenAgent.BestellingPlaatsen(new BestellingPcS());
            return response;
        }
    }
}
