﻿using AutoMapper;
using Case3.BSBestellingenbeheer.V1.Messages;
using Case3.BSBestellingenbeheer.V1.Schema;
using Case3.BSCatalogusBeheer.Schema.ProductNS;
using Case3.PcSBestellen.Agent.Agents;
using Case3.PcSBestellen.Agent.Interfaces;
using Case3.PcSBestellen.Implementation.Managers.Interfaces;
using Case3.PcSBestellen.V1.Messages;
using Case3.PcSBestellen.V1.Schema;
using System.Collections.Generic;
using System.Linq;

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
                    ArtikelenPcS = artikelen
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
    }
}
