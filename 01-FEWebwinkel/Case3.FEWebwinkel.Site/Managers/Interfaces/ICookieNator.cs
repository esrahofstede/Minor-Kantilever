using System;
using System.Collections.Generic;
using System.Web;

namespace Case3.FEWebwinkel.Site.Managers.Interfaces
{
    public interface ICookieNator<T>
    {
        string GetCookieValue(string cookieName);
    }
}
