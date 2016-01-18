using Case3.BTWConfigurationReader;
using Case3.FEWebwinkel.Agent;
using Case3.FEWebwinkel.Agent.Interfaces;
using Case3.FEWebwinkel.Site.Managers.Interfaces;
using Case3.FEWebwinkel.Site.ViewModels;
using Case3.PcSWinkelen.Schema;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// This function gets a filled WinkelmandViewModel
        /// </summary>
        /// <param name="SessieId">The Id to find the correct Winkelmand</param>
        /// <returns>Returns a WinkelmandViewModel</returns>
        public WinkelmandViewModel GetWinkelmand(string sessionId)
        {
            var winkelmand = _pcsWinkelenAgent.GetWinkelmand(sessionId);

            var artikelLijst = ConvertWinkelmandCollectionToArtikelViewModelList(winkelmand);

            var winkelmandViewModel = CreateWinkelmandViewModel(sessionId, artikelLijst);
            return winkelmandViewModel;
        }

        /// <summary>
        /// This function creates a WinkelmandViewModel based on the sessionId an artikelLijst
        /// </summary>
        /// <param name="sessionId">The ID of the session</param>
        /// <param name="artikelLijst">The list with artikelen that has to be added to the WinkelmandViewModel</param>
        /// <returns></returns>
        private WinkelmandViewModel CreateWinkelmandViewModel(string sessionId, List<ArtikelViewModel> artikelLijst)
        {
            decimal totaalInclBTW = 0M;
            decimal totaalExclBTW = 0M;

            if (sessionId.Length > 0) //SessionId has been set if > 0, so the totals can be calculated
            {
                totaalInclBTW = artikelLijst.Select(artikel => (artikel.Prijs * artikel.Aantal)).Sum();
                totaalExclBTW = _btwCalculator.CalculatePriceExclBTW(totaalInclBTW);
            }

            var winkelmandViewModel = new WinkelmandViewModel
            {
                Artikelen = artikelLijst,
                BTWPercentage = _btwCalculator.BTWPercentage,
                TotaalInclBTW = totaalInclBTW,
                TotaalExclBTW = totaalExclBTW,
                TotaalBTW = _btwCalculator.CalculateBTWOfPrice(totaalExclBTW),
            };
            return winkelmandViewModel;
        }

        /// <summary>
        /// This function Converts a List with ArtikelViewModels based on the given WinkelMandCollection
        /// </summary>
        /// <param name="winkelmandCollection">The collection which has to be converted</param>
        /// <returns>Returns a list with ArtikelViewModels</returns>
        public List<ArtikelViewModel> ConvertWinkelmandCollectionToArtikelViewModelList(WinkelMandCollection winkelmandCollection)
        {
            var ArtikelViewModels = winkelmandCollection.Select(wm => new ArtikelViewModel
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