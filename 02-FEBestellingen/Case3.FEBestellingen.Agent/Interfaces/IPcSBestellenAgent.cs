using Case3.PcSBestellen.V1.Messages;
using case3pcsbestellen.v1.schema;

namespace Case3.FEBestellingen.Agent.Interfaces
{
    public interface IPcSBestellenAgent
    {
        BestellingPcS FindNextBestelling(FindNextBestellingRequestMessage requestMessage);
    }
}
