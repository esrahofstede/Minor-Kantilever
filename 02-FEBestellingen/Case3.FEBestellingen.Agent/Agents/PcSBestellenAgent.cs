using System;
using Case3.FEBestellingen.Agent.Interfaces;
using Case3.PcSBestellen.V1.Messages;
using Minor.ServiceBus.Agent.Implementation;
using case3pcsbestellen.v1.schema;

namespace Case3.FEBestellingen.Agent.Agents
{
    /// <summary>
    /// Responsible for connecting to the PcSBestellen
    /// </summary>
    public class PcSBestellenAgent : IPcSBestellenAgent
    {
        private ServiceFactory<IPcSBestellenService> _factory;
        private IPcSBestellenService _agent;

        /// <summary>
        /// This is the default constructor
        /// </summary>
        public PcSBestellenAgent()
        {
            _factory = new ServiceFactory<IPcSBestellenService>("PcSBestellen");
            _agent = _factory.CreateAgent();
        }

        /// <summary>
        /// This is the controller for testing purposes
        /// </summary>
        /// <param name="agent">This should be a mock of IPcSBestellenService</param>
        public PcSBestellenAgent(IPcSBestellenService agent)
        {
            _agent = agent;
        }
        /// <summary>
        /// This function Calls the PcsBestellen for the next Bestelling
        /// </summary>
        /// <param name="requestMessage">The requestmessage containing the parameters for the request</param>
        /// <returns>Returns A BestellingPcS Containing all the needed information</returns>
        public BestellingPcS FindNextBestelling(FindNextBestellingRequestMessage requestMessage)
        {
            //FindNextBestellingResultMessage result = _agent.FindNextBestelling(requestMessage);
            //return result.BestellingOpdracht;
            return new BestellingPcS
            {
                BestellingID = 1,
                FactuurID = 10001,
                Status = 1,
                Klantgegevens = new KlantgegevensPcS
                {
                    Naam = "Rogier Welten",
                    Adresregel1 = "Haagstraat 5",
                    Adresregel2 = "t.a.v. Dhr. Welten",
                    Postcode = "4921XA",
                    Telefoonnummer = "0627232007",
                    Woonplaats = "Made",
                },
                ArtikelenPcS = new ArtikelenPcS
                {
                    new BestelItemPcS
                    {
                        Aantal = 1,
                        Product = new Product
                        {
                            Id = 1,
                            Naam = "Fietsbel",
                            LeverancierNaam = "Gazelle",
                            LeveranciersProductId = "GA123456FB",
                            Prijs = 4.95M,
                        }
                    },
                    new BestelItemPcS
                    {
                        Aantal = 2,
                        Product = new Product
                        {
                            Id = 2,
                            Naam = "Zadelpen",
                            LeverancierNaam = "Giant",
                            LeveranciersProductId = "GI123456ZP",
                            Prijs = 4.95M,
                        }
                    },
                },
            };
        }

        /// <summary>
        /// This function updates the status of a Bestelling
        /// </summary>
        /// <param name="bestellingID">The ID of the Bestelling which has to be changed</param>
        public void ChangeStatusOfBestelling(long bestellingID)
        {
            var requestMessage = new UpdateBestellingStatusRequestMessage
            {
                BestellingID = bestellingID,
            };

            _agent.UpdateBestelling(requestMessage);
        }
    }
}
