using Case3.BTWConfigurationReader;
using Case3.PcSWinkelen.Agent.Agents;
using Case3.PcSWinkelen.Schema.Messages;
using Case3.PcSWinkelen.Schema.Product;
using Case3.PcSWinkelen.Schema.Voorraad;
using Minor.ServiceBus.Agent.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case3.PcSWinkelen.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {

            MsgFindVoorraadRequest request = new MsgFindVoorraadRequest() { Product = new ProductRef() { } };


            /*BTWCalculator reader = new BTWCalculator();
           
                Console.WriteLine(reader.BTWPercentage);
            Console.WriteLine(reader.CalculatePriceInclusiveBTW(100M));*/

           /* ServiceFactory<IVoorraadBeheer> _factory = new ServiceFactory<IVoorraadBeheer>("BSVoorraadBeheer");
            IVoorraadBeheer _agent = _factory.CreateAgent();


            MsgFindVoorraadResult result =  _agent.FindVoorraad(request);

          

            BSCatalogusBeheerAgent agent = new BSCatalogusBeheerAgent();
            List<Product> products = agent.GetProducts().ToList();
            
            foreach(Product product in products)
            {
                Console.WriteLine(product.AfbeeldingURL + " " + product.Prijs + " " + product.LeverancierNaam + " " + product.Beschrijving);
            }*/

            Console.Read();
        }
    }
}
