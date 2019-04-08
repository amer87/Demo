using System;
using System.Collections.Generic;
using System.Linq;
using Com.Data;
using Com.Services;
using Microsoft.AspNetCore.Mvc;

namespace Com.Api.Controllers
{
    [Route("api/[controller]")]
    public class AdsController : BaseApiController
    {
        private readonly IAdsService _adsService;

        public AdsController(IAdsService adsService)
        {
            _adsService = adsService;
        }

        // GET: api/Ad
        [HttpGet]
        public ActionResult<IEnumerable<AdApi>> Get()
        {
            return Ok(_adsService.GetAds().Select(x => _factory.Create<Ad, AdApi>(x)).ToList());
        }

        // GET: api/Ad/{id}
        [HttpGet("{id}")]
        public ActionResult<AdApi> Get(Guid id)
        {
            return Ok(_factory.Create<Ad, AdApi>(_adsService.GetAd(id)));
        }
    }
}