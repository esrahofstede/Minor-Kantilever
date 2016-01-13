using Case3.BSBestellingenbeheer.V1.Messages;

namespace Case3.PcSBestellen.Agent.Interfaces
{
    public interface IBsBestellingenbeheerAgent
    {
        FindFirstBestellingResultMessage FindFirstBestelling(FindFirstBestellingRequestMessage requestMessage);
    }
}
