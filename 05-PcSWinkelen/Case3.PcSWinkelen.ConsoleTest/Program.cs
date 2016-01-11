
using System;
using System.Collections.Generic;
using System.Linq;

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
            BSVoorraadBeheerAgent agent2 = new BSVoorraadBeheerAgent();
            List<Product> products = agent.GetProducts().ToList();
            
            foreach(Product product in products)
            {
                Console.WriteLine(product.AfbeeldingURL + " " + product.Prijs + " " + product.LeverancierNaam + " " + product.Beschrijving);
                int voorraad = agent2.GetProductVoorraad(product.Id, product.LeveranciersProductId);
                Console.WriteLine($"Voorraad: {voorraad}");
            }
            Console.Read();
        }
    }
}
