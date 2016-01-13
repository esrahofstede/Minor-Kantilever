using Case3.BTWConfigurationReader;
using Case3.FEWebwinkel.Agent;
using Case3.FEWebwinkel.Agent.Interfaces;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using Case3.FEWebwinkel.Site.ViewModels;
using Case3.PcSWinkelen.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Case3.FEWebwinkel.Site.Managers
{
    public class WinkelmandManager : IWinkelmandManager
    {

        private IPcSWinkelenAgent _pcsWinkelenAgent;
        private BTWCalculator _btwCalculator = new BTWCalculator();

        /// <summary>
        /// This constructor is the default constructor
        /// </summary>
        public WinkelmandManager()
        {
            _pcsWinkelenAgent = new PcSWinkelenAgent();
        }
        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="agent">This should be a mock of IPcSWinkelenAgent</param>
        public WinkelmandManager(IPcSWinkelenAgent agent)
        {
            _pcsWinkelenAgent = agent;
        }
        public List<ArtikelViewModel> GetWinkelmand(string SessieId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WinkelmandCollection"></param>
        /// <returns></returns>
        public List<ArtikelViewModel> ConvertWinkelmandCollectionToArtikelViewModelList(WinkelMandCollection WinkelmandCollection)
        {
            var ArtikelViewModels = WinkelmandCollection.Select(wm => new ArtikelViewModel
            {
                ID = wm.Product.Id,
                ArtikelNaam = wm.Product.Naam,
                Prijs = _btwCalculator.CalculatePriceInclusiveBTW(wm.Product.Prijs),
                Aantal = wm.Aantal,
            });

            return ArtikelViewModels.ToList();
        }

        
    }
}