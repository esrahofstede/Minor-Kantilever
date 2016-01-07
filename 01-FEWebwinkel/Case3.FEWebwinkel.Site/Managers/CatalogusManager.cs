﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Case3.FEWebwinkel.Agent.Interfaces;
using Case3.FEWebwinkel.Site.ViewModels;
using Case3.PcSWinkelen.Messages;
using Case3.PcSWinkelen.Schema;
using Case3.FEWebwinkel.Agent;
using Case3.BTWConfigurationReader;

namespace Case3.FEWebwinkel.Site.Managers
{
    /// <summary>
    /// Responsible for connecting to the PcSWinkelen with the Agent and Converting it's values
    /// </summary>
    public class CatalogusManager : ICatalogusManager
    {
        private IPcSWinkelenAgent _pcsWinkelenAgent;
        private BTWCalculator _btwCalculator;
        /// <summary>
        /// This constructor is the default constructor
        /// </summary>
        public CatalogusManager()
        {
            _pcsWinkelenAgent = new PcSWinkelenAgent();
        }
        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="agent">This should be a mock of IPcSWinkelenAgent</param>
        public CatalogusManager(IPcSWinkelenAgent agent)
        {
            _pcsWinkelenAgent = agent;
        }
        /// <summary>
        /// This function Convert a List with CatalogusViewModels based on the given CatalogusCollection
        /// </summary>
        /// <param name="catalogusCollection">The collection which has to be converted</param>
        /// <returns>Returns a list with CatalogusViewModels<returns>
        public List<CatalogusViewModel> ConvertFindCatalogusResponseMessageToCatalogusViewModelList(CatalogusCollection catalogusCollection)
        {
            var CatalogusViewModels = catalogusCollection.Select(cat => new CatalogusViewModel
            {
                ID = cat.Product.Id,
                Afbeeldingslocatie = "../Content/Product_img/" + cat.Product.AfbeeldingURL,
                Leverancier = cat.Product.LeverancierNaam,
                Naam = cat.Product.Naam,
                Prijs = _btwCalculator.CalculatePriceInclusiveBTW(cat.Product.Prijs),
                Voorraad = cat.Voorraad,
            });

            return CatalogusViewModels.ToList();
        }

        /// <summary>
        /// This function returns a List with CatalogusViewModels
        /// </summary>
        /// <param name="page">Current pagenumber</param>
        /// <param name="pageSize">Size of the page</param>
        /// <returns>Returns a list with CatalogusViewModels</returns>
        public List<CatalogusViewModel> GetProducts(int page, int pageSize)
        {
            var products = _pcsWinkelenAgent.GetProducts(page, pageSize);

            var viewmodels = ConvertFindCatalogusResponseMessageToCatalogusViewModelList(products);

            return viewmodels;
        }
    }
}