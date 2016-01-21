using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.PcSBestellen.Agent.Agents;
using Case3.PcSBestellen.Agent.Interfaces;
using Case3.PcSBestellen.Implementation.Managers.Interfaces;
using Case3.PcSBestellen.V1.Messages;
using Case3.PcSBestellen.V1.Schema;
using System;
using UpdateBestellingStatusResultMessage = Case3.BSBestellingenbeheer.V1.Messages.UpdateBestellingStatusResultMessage;

namespace Case3.PcSBestellen.Implementation.Managers
{
    /// <summary>
    /// Responsible for connecting to the BSBestellingen using the Agent and Converting it's values
    /// </summary>
    public class BSBestellingenManager : IBSBestellingenManager
    {
        private IBSBestellingenbeheerAgent _bsBestellingenAgent;

        /// <summary>
        /// This is the default constructor
        /// </summary>
        public BSBestellingenManager()
        {
            _bsBestellingenAgent = new BSBestellingenbeheerAgent();
        }

        /// <summary>
        /// This constructor is for testing purposes
        /// </summary>
        /// <param name="agent">This should be a mock of IBsBestellingenbeheerAgent</param>
        public BSBestellingenManager(IBSBestellingenbeheerAgent agent)
        {
            _bsBestellingenAgent = agent;
        }


        /// <summary>
        /// This function converts a FindNextBestellingRequestMessage to a FindFirstBestellingRequestMessage
        /// </summary>
        /// <param name="findNextRequestMessage">The requestmessage which has to be converted</param>
        /// <returns>Returns a FindFirstBestellingRequestMessage<returns>
        public FindNextBestellingResultMessage ConvertFindFirstResultMessageToFindNextResultMessage(FindFirstBestellingResultMessage findFirstResultMessage)
        {
            var artikelen = new ArtikelenPcS();

            foreach (var item in findFirstResultMessage.BestellingOpdracht.Artikelen)
            {
                artikelen.Add(new BestelItemPcS
                    {
                        Aantal = item.Aantal,
                        ExtensionData = item.ExtensionData,
                        Product = item.Product
                    });
            }
            
            return new FindNextBestellingResultMessage
            {
                BestellingOpdracht = new BestellingPcS
                {
                    BestellingID = findFirstResultMessage.BestellingOpdracht.BestellingID,
                    BTWPercentage = findFirstResultMessage.BestellingOpdracht.BTWPercentage,
                    ArtikelenPcS = artikelen,
                    Klantgegevens = new KlantgegevensPcS
                    {
                        Naam = findFirstResultMessage.BestellingOpdracht.Klantgegevens.Naam,
                        Adresregel1 = findFirstResultMessage.BestellingOpdracht.Klantgegevens.Adresregel1,
                        Adresregel2 = findFirstResultMessage.BestellingOpdracht.Klantgegevens.Adresregel2,
                        Postcode = findFirstResultMessage.BestellingOpdracht.Klantgegevens.Postcode,
                        Telefoonnummer = findFirstResultMessage.BestellingOpdracht.Klantgegevens.Telefoonnummer,
                        Woonplaats = findFirstResultMessage.BestellingOpdracht.Klantgegevens.Woonplaats
                    }
                },
            };
        }

        /// <summary>
        /// This function converts a FindFirstBestellingResultMessage to a FindNextBestellingResultMessage
        /// </summary>
        /// <param name="findFirstResultMessage">The resultmessage which has to be converted</param>
        /// <returns>Returns a FindNextBestellingResultMessage<returns>
        public FindFirstBestellingRequestMessage ConvertFindNextRequestMessageToFindFirstRequestMessage(FindNextBestellingRequestMessage findNextRequestMessage)
        {
            return new FindFirstBestellingRequestMessage()
            {
                //There is nothing to convert at this time, but this method has already been made for possible additions
            };
        }

        /// <summary>
        /// This function returns a FindNextBestellingResultMessage
        /// </summary>
        /// <param name="requestMessage">The Request Message</param>
        /// <returns>Returns a FindNextBestellingResultMessage</returns>
        public FindNextBestellingResultMessage FindNextBestelling(FindNextBestellingRequestMessage requestMessage)
        {
            //Convert the incoming requestMessage to the required requestMessage for the BsBestellingenbeheer
            var findFirstRequestMessage = ConvertFindNextRequestMessageToFindFirstRequestMessage(requestMessage);
            //Get the first bestelling from the BsBestellingenbeheer using the agent
            var findFirstResultMessage = _bsBestellingenAgent.FindFirstBestelling(findFirstRequestMessage);
            //Convert the incoming resultMessage to the correct outgoing resultMessage for FEBestellen
            var findNextResultMessage = ConvertFindFirstResultMessageToFindNextResultMessage(findFirstResultMessage);

            return findNextResultMessage;
        }

        /// <summary>
        /// This function updates the Bestelling and returns a UpdateBestellingStatusResultMessage
        /// </summary>
        /// <param name="request">The Request Message</param>
        /// <returns>Returns a UpdateBestellingStatusResultMessage</returns>
        public V1.Messages.UpdateBestellingStatusResultMessage UpdateBestelling(V1.Messages.UpdateBestellingStatusRequestMessage request)
        {
            //Convert the incoming requestMessage to the required requestMessage for the BsBestellingenbeheer
            var bsRequestMessage = ConvertPcSUpdateRequestMessageToBSUpdateRequestMessage(request);
            //Update the bestelling from the BsBestellingenbeheer using the agent
            _bsBestellingenAgent.UpdateBestellingStatus(bsRequestMessage);
            //Convert the incoming resultMessage to the correct outgoing resultMessage for FEBestellen
            //var findNextResultMessage = ConvertBsUpdateResultMessageToPcSUpdateResultMessage(bsResultMessage);

            return new V1.Messages.UpdateBestellingStatusResultMessage();
        }

        /// <summary>
        /// This function converts a (BSBestellen)UpdateBestellingStatusResultMessage to a (PcSBestellen)UpdateBestellingStatusResultMessage
        /// </summary>
        /// <param name="bsResultMessage">The resultmessage which has to be converted</param>
        /// <returns>Returns a UpdateBestellingStatusResultMessage<returns>
        public V1.Messages.UpdateBestellingStatusResultMessage ConvertBsUpdateResultMessageToPcSUpdateResultMessage(BSBestellingenbeheer.V1.Messages.UpdateBestellingStatusResultMessage bsResultMessage)
        {
            return new V1.Messages.UpdateBestellingStatusResultMessage
            {
                //There is nothing to convert at this time, but this method has already been made for possible additions
            };
        }

        /// <summary>
        /// This function converts a (PcSBestellen)UpdateBestellingStatusRequestMessage to a (BSBestellen)UpdateBestellingStatusRequestMessage
        /// </summary>
        /// <param name="request">The request message which has to be converted</param>
        /// <returns>Returns a UpdateBestellingStatusRequestMessage<returns>
        public BSBestellingenbeheer.V1.Messages.UpdateBestellingStatusRequestMessage ConvertPcSUpdateRequestMessageToBSUpdateRequestMessage(V1.Messages.UpdateBestellingStatusRequestMessage request)
        {
            return new BSBestellingenbeheer.V1.Messages.UpdateBestellingStatusRequestMessage
            {
                BestellingID = request.BestellingID,
            };
        }
    }
}
