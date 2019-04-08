using Demoacc.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Com.Api.Controllers
{
    [BasicAuthorize]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        public ModelsFactory _factory;

        public BaseApiController()
        {
            _factory = new ModelsFactory();
        }
    }
}