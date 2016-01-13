using Case3.BSBestellingenbeheer.V1.SchemaNSPcS;
using Case3.PcSBestellen.V1.Messages;

namespace Case3.FEBestellingen.Agent.Interfaces
{
    public interface IPcSBestellenAgent
    {
        Bestelling FindNextBestelling(FindNextBestellingRequestMessage requestMessage);
    }
}
