using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Minor.ServiceBus.Agent.Implementation;

namespace Case3.PcSWinkelen.Agent
{
    public class TestAgent
    {
        private ServiceFactory<IBSVoorraadBeheer> _factory;

        /// <summary>
        /// Standaard constructor die een nieuwe ServiceFactory maakt voor de ISRDWService
        /// </summary>
        public TestAgent()
        {
            _factory = new ServiceFactory<IBSVoorraadBeheer>("BSVoorraadBeheer");
        }

        /// <summary>
        /// Aan deze constructor kan een custom ServiceFactory meegegeven worden
        /// Niet CLS compliant omdat de servicefactory generic is
        /// </summary>
        /// <param name="factory"></param>
        public TestAgent(ServiceFactory<IBSVoorraadBeheer> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Deze methode verstuurt een APK keuringsverzoek naar de IS service
        /// </summary>
        /// <param name="voertuig">Het voertuig waarvoor de apk keuring is gedaan</param>
        /// <param name="garage">De garage die de keuring verstuurt</param>
        /// <param name="keuringsverzoek">Parameters voor het keuringsverzoek</param>
        /// <returns>Het antwoord van de IS</returns>
        public void SenndSomething()
        {
            var proxy = _factory.CreateAgent();

            var test = proxy.TestMethod();

        }

        /// <summary>
        /// to be replaced by a real service
        /// </summary>
        public interface IBSVoorraadBeheer
        {
            string TestMethod();
        }
    }
}
