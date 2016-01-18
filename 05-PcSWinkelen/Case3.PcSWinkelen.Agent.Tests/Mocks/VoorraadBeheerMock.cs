using Case3.PcSWinkelen.Schema.ProductNS;
using Case3.PcSWinkelen.Schema.VoorraadMessages;
using Case3.PcSWinkelen.Schema.VoorraadNS;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [ExcludeFromCodeCoverage]
        public Task<MsgFindVoorraadResult> FindVoorraadAsync(MsgFindVoorraadRequest message)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage]
        public MsgUpdateVoorraadResult UpdateVoorraad(MsgUpdateVoorraadRequest message)
        {
            throw new NotImplementedException();
        }

        [ExcludeFromCodeCoverage]
        public Task<MsgUpdateVoorraadResult> UpdateVoorraadAsync(MsgUpdateVoorraadRequest message)
        {
            throw new NotImplementedException();
        }
    }
}
