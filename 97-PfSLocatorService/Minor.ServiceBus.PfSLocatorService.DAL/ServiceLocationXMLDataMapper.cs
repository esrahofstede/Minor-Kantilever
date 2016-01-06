using Minor.ServiceBus.PfSLocatorService.DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Web.Hosting;

namespace Minor.ServiceBus.PfSLocatorService.DAL
{
    /// <summary>
    /// This class can search in the locationdata and find a mex address
    /// </summary>
    public class ServiceLocationXMLDataMapper : IServiceLocationDataMapper
    {
        private string _filePath;

        public ServiceLocationXMLDataMapper(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                _filePath = filePath;
            }
            else
            {
                throw new FilePathNotDefinedException("File path is not defined.");
            }
        }

        public ServiceLocationXMLDataMapper()
        {
            _filePath = "locationData.xml";
        }

        /// <summary>
        /// Finds the metadata endpoint address of a service
        /// </summary>
        /// <param name="name">The name of the service</param>
        /// <param name="profile">The profile of the service</param>
        /// <returns>The mex address of the service that was found, as a string</returns>
        public string FindMetadataEndpointAddress(string name, string profile)
        {
            return GetMetaDataEndPointAdress(name, profile);
            //return "http://localhost:30412/BSKlantbeheer/mex";
        }

        /// <summary>
        /// Finds the metadata endpoint address of a service
        /// </summary>
        /// <param name="name">The name of the service</param>
        /// <param name="profile">The profile of the service</param>
        /// <param name="version">The version of the service</param>
        /// <returns>The mex address of the service that was found, as a string</returns>
        public string FindMetadataEndpointAddress(string name, string profile, decimal? version)
        {
            //return "http://localhost:30412/BSKlantbeheer/mex";
            return GetMetaDataEndPointAdress(name, profile, version);
        }

        /// <summary>
        /// Gets the metadata endpoint address of a service from the locationdata
        /// </summary>
        /// <param name="name">The name of the service</param>
        /// <param name="profile">The profile of the service</param>
        /// <param name="version">The version of the service</param>
        /// <returns>The mex address of the service that was found, as a string 
        ///          If nothing was found it returns a NoRecordsFoundException</returns>
        public string GetMetaDataEndPointAdress(string name, string profile, decimal? version = null)
        {
            var data = LoadXMLFile<locationData>();
            foreach (var servicelocation in data.serviceLocation)
            {
                if (version != null)
                {
                    if (servicelocation.name == name
                        && servicelocation.profile == profile
                        && servicelocation.version == version)
                    {
                        return servicelocation.metadataAddress;
                    }
                }
                if (servicelocation.name == name && servicelocation.profile == profile)
                {
                    return servicelocation.metadataAddress;
                }
            }
            throw new NoRecordsFoundException("The given service location doesn't exists inside of the given xml file.");
        }
        /// <summary>
        /// Reads an xml file and returns the data within
        /// </summary>
        /// <typeparam name="T">The element type of the data from the xml file</typeparam>
        /// <returns>The data from the xml file</returns>
        public T LoadXMLFile<T>()
        {
            string test = Directory.GetCurrentDirectory();
            string relativePath = Path.Combine(Directory.GetCurrentDirectory(), _filePath);
            relativePath = MakeAbsolutePath(_filePath);

            XmlSerializer serializer = new XmlSerializer(typeof(locationData));
            using (StreamReader reader = new StreamReader(relativePath))
            {
                var data = serializer.Deserialize(reader);
                return (T)data;
            }
        }

        /// <summary>
        /// Creates an absolute path from a relative path
        /// </summary>
        /// <param name="relativePath">The relative path you use to create the absolute path</param>
        /// <returns>The absolute path as a string</returns>
        public string MakeAbsolutePath(string relativePath)
        {
            string path = null;

            if (HttpContext.Current != null)
            {
                path = HttpContext.Current.Server.MapPath(relativePath);
            }
            else
            {
                path = Path.Combine(Directory.GetCurrentDirectory(), relativePath);
            }

            return path;
        }
    }
}
