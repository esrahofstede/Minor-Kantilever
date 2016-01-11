using System;
using System.Collections.Generic;

namespace Case3.FEWebwinkel.Site.Managers.Interfaces
{
    public interface ICookieNator<T>
    {

        List<T> GetCookieValue(string cookieName);

    }
}
