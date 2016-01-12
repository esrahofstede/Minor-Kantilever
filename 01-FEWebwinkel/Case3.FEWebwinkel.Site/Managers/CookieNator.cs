using Case3.FEWebwinkel.Site.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Case3.FEWebwinkel.Site.Managers
{
    public class CookieNator<T> : ICookieNator<T>
    {
        private HttpCookieCollection _httpCookieCollection;

        /// <summary>
        /// This is the default constructor
        /// </summary>
        /// <param name="httpCookieCollection"></param>
        public CookieNator(HttpCookieCollection httpCookieCollection)
        {
            _httpCookieCollection = httpCookieCollection;
        }

        /// <summary>
        /// Get the value of a cookie
        /// </summary>
        /// <param name="cookieName">Name of the cookie you want the value of</param>
        /// <returns>(string) cookie value</returns>
        public string GetCookieValue(string cookieName)
        {
            return _httpCookieCollection.Get(cookieName).Value;
        }

        /// <summary>
        /// Creates the cookie "UserGuid" with the Guid that is passed to this method
        /// </summary>
        /// <param name="userGuid">An user Guid</param>
        public void CreateCookieWithUserGuid(string userGuid)
        {

            var cookie = new HttpCookie("UserGuid", userGuid)
            {
                Expires = DateTime.Now.AddMonths(1),
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

    }
}