using System;
using System.Collections.Generic;
using Com.Data;

namespace Com.Services
{
    public interface IAdsService
    {
        List<string> GetErrors();
        IEnumerable<Ad> GetAds();
        Ad GetAd(Guid id);
    }
}
