using System;
using System.Collections.Generic;
using Com.Data;
using Com.Repo;

namespace Com.Services
{
    public class AdsService : BaseService<Ad>, IAdsService
    {
        public AdsService(IRepository repo) : base(repo) { }

        public Ad GetAd(Guid id) => base.GetById(id);

        public IEnumerable<Ad> GetAds() => base.GetAll();
    }
}
