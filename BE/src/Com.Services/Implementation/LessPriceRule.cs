using Com.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Services
{
    internal class LessPriceRule : IDiscountRule
    {
        private List<Cart> _cartLines;
        private readonly Guid _itemToApplyDiscount;
        private readonly double _newPrice;
        private readonly int _minimumQuantity;

        public LessPriceRule(List<Cart> cartLines, Guid itemToApplyDiscount, double newPrice)
            :this(cartLines, itemToApplyDiscount, newPrice, 1)
        {
        }

        public LessPriceRule(List<Cart> cartLines, Guid itemToApplyDiscount, double newPrice, int minimumQuantity)
        {
            _cartLines = cartLines;
            _itemToApplyDiscount = itemToApplyDiscount;
            _newPrice = newPrice;
            _minimumQuantity = minimumQuantity;
        }

        public void ApplyDiscount()
        {
            _cartLines.Where(i => i.AdId == _itemToApplyDiscount).ToList().ForEach(i=>i.UnitPrice = _newPrice);
        }

        public bool IsMatched()
        {
            return _cartLines.Exists(i=>i.AdId == _itemToApplyDiscount && i.Quantity >= _minimumQuantity);
        }
    }
}
