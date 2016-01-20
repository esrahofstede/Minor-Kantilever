using System;
using Case3.FEBestellingen.Agent.Interfaces;
using Case3.PcSBestellen.V1.Messages;
using Minor.ServiceBus.Agent.Implementation;
using case3pcsbestellen.v1.schema;
using Case3.BSCatalogusBeheer.Schema.ProductNSPcS;

namespace Case3.FEBestellingen.Agent.Agents
{
    public class PcSBestellenAgent : IPcSBestellenAgent
    {
        private ServiceFactory<IPcSBestellenService> _factory;
        private IPcSBestellenService _agent;

        public PcSBestellenAgent()
        {
            _factory = new ServiceFactory<IPcSBestellenService>("PcSBestellen");
            _agent = _factory.CreateAgent();
        }

        public PcSBestellenAgent(IPcSBestellenService agent)
        {
            _agent = agent;
        }
        public BestellingPcS FindNextBestelling(FindNextBestellingRequestMessage requestMessage)
        {
            //FindNextBestellingResultMessage result = _agent.FindNextBestelling(requestMessage);
            //return result.BestellingOpdracht;
            return new BestellingPcS
            {
                BestellingID = 1,
                FactuurID = 10001,
                Status = "1",
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
    }
}
