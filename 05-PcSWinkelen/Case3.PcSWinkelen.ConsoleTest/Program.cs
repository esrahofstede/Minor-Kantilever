using Case3.PcSWinkelen.Agent.Agents;
using Case3.PcSWinkelen.Schema.Product;
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

            BSCatalogusBeheerAgent agent = new BSCatalogusBeheerAgent();
            List<Product> products = agent.GetProducts().ToList();
            
            foreach(Product product in products)
            {
                Console.WriteLine(product.AfbeeldingURL + " " + product.Prijs + " " + product.LeverancierNaam + " " + product.Beschrijving);
            }

            Console.Read();
        }
    }
}
