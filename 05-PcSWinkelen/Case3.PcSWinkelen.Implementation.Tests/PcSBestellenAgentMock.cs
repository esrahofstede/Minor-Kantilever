﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Case3.PcSBestellen.SchemaNS;
using Case3.PcSWinkelen.Agent.Interfaces;

namespace Case3.PcSWinkelen.Implementation.Tests
{
    /// <summary>
    /// Mock class for the PcSBestellenAgent, for testing purposes
    /// </summary>
    internal class PcSBestellenAgentMock : IPcSBestellenAgent
    {
        public BestellingPcS Bestelling { get; set; }

        public bool BestellingPlaatsen(BestellingPcS bestelling)
        {
            Bestelling = bestelling;
            return true;
        }

        public Task<bool> BestellingPlaatsenAsync(BestellingPcS bestelling)
        {
            Bestelling = bestelling;
            return Task.FromResult(true);
        }
    }
}
