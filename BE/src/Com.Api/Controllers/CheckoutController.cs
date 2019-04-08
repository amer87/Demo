using Com.Api.Models;
using Com.Data;
using Com.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Api.Controllers
{
    [Route("api/[controller]")]
    public class CheckoutController : BaseApiController
    {
        private ICartService _cartService;

        public CheckoutController(ICartService cartService, IAdsService adsService)
        {
            _cartService = cartService;
            _cartService.SetAds(adsService.GetAds().ToList());
        }

        [HttpPost]
        public ActionResult<double> Post([FromBody] CartForm cart)
        {
            var cartHeader = _cartService.AddCart(GetOrderDictionary(cart), cart.UserId);
            var cartLines = _cartService.GetCartLines(cartHeader.EntryId, true);
            var errors = _cartService.GetErrors();

            if (errors.Count == 0)
                return Ok(cartLines);

            return BadRequest(new ApiError($"Cart could not be created : {errors.FirstOrDefault()}"));
        }

        [HttpGet("{entryId}")]
        public ActionResult<List<CartApi>> Get(Guid entryId) =>
            _cartService.GetCartLines(entryId, true).Select(c =>_factory.Create<Cart, CartApi>(c)).ToList();

        private Dictionary<string, int> GetOrderDictionary(CartForm cart)
        {
            return new Dictionary<string, int>()
            {
                {"classic", cart.ClassicQuantity },
                {"standout", cart.StandoutQuantity },
                {"premium", cart.PremiumQuantity }
            };
        }
    }
}