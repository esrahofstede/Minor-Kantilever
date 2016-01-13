using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSWinkelen.Schema.Messages;
using Case3.PcSWinkelen.Schema.Product;
using Case3.PcSWinkelen.Schema.Voorraad;

namespace Case3.PcSWinkelen.Agent.Tests.Mocks
{
    public class VoorraadBeheerMock : IVoorraadBeheer
    {
        /// <summary>
        /// Mock which returns a result with a fake product
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public MsgFindVoorraadResult FindVoorraad(MsgFindVoorraadRequest message)
        {
            ProductRef product = new ProductRef()
            {
                Id = 48,
                LeveranciersProductId = "GA1",
            };
            MsgFindVoorraadResult result = new MsgFindVoorraadResult()
            {
                ProductVoorraad = new ProductVoorraad()
                {
                    Product = product,
                    Voorraad = 28,
                },
                Succes = true,
            };
            return result;
        }

        public Task<MsgFindVoorraadResult> FindVoorraadAsync(MsgFindVoorraadRequest message)
        {
            throw new NotImplementedException();
        }

        public MsgUpdateVoorraadResult UpdateVoorraad(MsgUpdateVoorraadRequest message)
        {
            throw new NotImplementedException();
        }

        public Task<MsgUpdateVoorraadResult> UpdateVoorraadAsync(MsgUpdateVoorraadRequest message)
        {
            throw new NotImplementedException();
        }
    }
}
