using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.BSVoorraadBeheer.Schema.Messages;
using Case3.BSVoorraadBeheer.Schema.Prod;
using Case3.BSVoorraadBeheer.Schema.VoorBeh;

namespace Case3.PcSWinkelen.Agent.Tests.Mocks
{
    public class VoorraadBeheerMock : IVoorraadBeheer
    {
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
