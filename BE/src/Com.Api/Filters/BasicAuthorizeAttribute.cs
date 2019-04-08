using Microsoft.AspNetCore.Mvc;

namespace Demoacc.Api.Filters
{
    public class BasicAuthorizeAttribute : TypeFilterAttribute
    {
        public BasicAuthorizeAttribute(string realm = null)
            : base(typeof(BasicAuthorizeFilter))
        {
           
        }
    }
}
