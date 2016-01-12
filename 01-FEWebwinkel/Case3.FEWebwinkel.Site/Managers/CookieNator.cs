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
        private string _cookieValueString;
        private HttpCookieCollection _httpCookieCollection;

        public CookieNator(HttpCookieCollection httpCookieCollection)
        {
            _httpCookieCollection = httpCookieCollection;
        }

        public string GetCookieValue(string cookieName)
        {
            return _httpCookieCollection.Get(cookieName).Value;
        }

        /// <summary>
        /// Creates a cookie the UserGuid with the Guid that is passed to this method
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