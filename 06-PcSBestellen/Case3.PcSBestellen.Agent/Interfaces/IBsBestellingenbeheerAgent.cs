﻿using Case3.BSBestellingenbeheer.V1.Messages;

namespace Case3.PcSBestellen.Agent.Interfaces
{
    /// <summary>
    /// The BsBestellingenbeheerAgent Interface 
    /// </summary>
    public interface IBsBestellingenbeheerAgent
    {
        /// <summary>
        /// This function returns a FindFirstBestellingResultMessage
        /// </summary>
        /// <param name="requestMessage">The Request Message</param>
        /// <returns>Returns a FindFirstBestellingResultMessage</returns>
        FindFirstBestellingResultMessage FindFirstBestelling(FindFirstBestellingRequestMessage requestMessage);

        /// <summary>
        /// This function returns a UpdateBestellingStatusResultMessage
        /// </summary>
        /// <param name="requestMessage">The Request Message</param>
        /// <returns>Returns a UpdateBestellingStatusResultMessage</returns>
        UpdateBestellingStatusResultMessage UpdateBestellingStatus(UpdateBestellingStatusRequestMessage requestMessage);
    }
}
