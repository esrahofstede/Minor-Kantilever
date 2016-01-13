using Case3.PcSWinkelen.Agent.Managers;
using Case3.PcSWinkelen.Contract;
using Case3.PcSWinkelen.MessagesNS;
using Case3.PcSWinkelen.SchemaNS;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Case3.PcSWinkelen.Agent.Agents;
using Case3.PcSWinkelen.Agent.Interfaces;
using Case3.PcSWinkelen.DAL.Mappers;
using Case3.PcSWinkelen.Implementation.Mappers;
using Case3.PcSWinkelen.Schema.ProductNS;
using log4net;
using System.ServiceModel;
using DTOSchema = Case3.PcSWinkelen.SchemaNS;
using case3common.v1.faults;

namespace Case3.PcSWinkelen.Implementation
{
    public class PcSWinkelenServiceHandler : IPcSWinkelenService
    {
        /// <summary>
        /// Get list of Products with the Voorraad included
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static ILog _logger = LogManager.GetLogger(typeof(PcSWinkelenServiceHandler));

        private IWinkelmandDataMapper _winkelmandDataMapper;
        private IBSCatalogusBeheerAgent _catalogusBeheerAgent;
        private IWinkelmandItemDTOMapper _winkelmandItemDTOMapper;

        public PcSWinkelenServiceHandler(
            IWinkelmandDataMapper dataMapper, 
            IBSCatalogusBeheerAgent catalogusBeheerAgent,
            IWinkelmandItemDTOMapper DTOMapper)
        {
            _winkelmandItemDTOMapper = DTOMapper;
            _winkelmandDataMapper = dataMapper;
            _catalogusBeheerAgent = catalogusBeheerAgent;
        }

        [ExcludeFromCodeCoverage]
        public PcSWinkelenServiceHandler()
        {
            _winkelmandDataMapper = new WinkelmandDataMapper();
            _winkelmandItemDTOMapper = new WinkelmandItemDTOMapper();
            _catalogusBeheerAgent = new BSCatalogusBeheerAgent();
            log4net.Config.XmlConfigurator.Configure();
        }
        
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
                catch (Exception)
                {

                    throw new FaultException("Er is een fout opgetreden in het ophalen van de catalogus");

                    /*throw new FaultException<FunctionalErrorList>(new FunctionalErrorList()
                    {
                        new FunctionalErrorDetail()
                        {
                            Message = "Er is een fout opgetreden in het ophalen van de catalogus",
                            ErrorCode = 1001,
                        }
                    }, "Error");*/
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
        /// <param name="request"></param>
        /// <returns></returns>
        public AddItemToWinkelmandResponseMessage AddProductToWinkelmand(AddItemToWinkelmandRequestMessage request)
        {
            Product product = _catalogusBeheerAgent.GetProductById(request.WinkelmandItemRef.ProductId);

            var winkelmandItem = new DTOSchema.WinkelmandItem
            {
                Product = product,
                Aantal = request.WinkelmandItemRef.Aantal,
                SessieId = request.WinkelmandItemRef.SessieId
            };

            var itemToInsert = _winkelmandItemDTOMapper.MapDTOToEntity(winkelmandItem);

            _winkelmandDataMapper.Insert(itemToInsert);

            return new AddItemToWinkelmandResponseMessage {Succeeded = true};
        }

        public GetWinkelmandResponseMessage GetWinkelmand(GetWinkelmandRequestMessage request)
        {
            var response = new GetWinkelmandResponseMessage();
            response.WinkelmandCollection = new WinkelMandCollection();
            response.SessieId = request.SessieId;

            var winkelmandItems = _winkelmandDataMapper.FindAllBy(w => w.SessieID == request.SessieId).ToList();
            foreach (var winkelmandItem in winkelmandItems)
            {
                response.WinkelmandCollection.Add(_winkelmandItemDTOMapper.MapEntityToDTO(winkelmandItem));
            }


            return response;
        }

    }
}
