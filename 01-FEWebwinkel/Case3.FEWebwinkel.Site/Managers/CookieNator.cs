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

        public List<T> GetCookieValue(string cookieName)
        {
            this.GetCookieString(cookieName);
            return DeserializeCookieValueString();
        }

        private void GetCookieString(string cookieName)
        {
            _cookieValueString = _httpCookieCollection.Get("artikelen").Value;
        }

        private List<T> DeserializeCookieValueString()
        {
            return new JavaScriptSerializer().Deserialize<List<T>>(_cookieValueString);
        }

    }
}