using System;
using System.Collections.Generic;
using System.Linq;
using Com.Data;

namespace Com.Services
{
    internal class FreeItemsRule : IDiscountRule
    {
        private List<Cart> _cartLines;
        private readonly Guid _itemToApplyDiscount;
        private readonly int _quantityRequiredToGetTheDiscount;
        private readonly Ad _itemToGive;
        private readonly int _quantityToGive;

        public FreeItemsRule(List<Cart> cartLines, Guid itemToApplyDiscount, int quantityRequiredToGetTheDiscount, Ad itemToGive, int quantityToGive)
        {
            _cartLines = cartLines;
            _itemToApplyDiscount = itemToApplyDiscount;
            _quantityRequiredToGetTheDiscount = quantityRequiredToGetTheDiscount;
            _itemToGive = itemToGive;
            _quantityToGive = quantityToGive;
        }

        public bool IsMatched()
        {
            Cart line = _cartLines.FirstOrDefault(i => i.AdId == _itemToApplyDiscount);

            if (line == null) return false;

            return (line.Quantity % _quantityRequiredToGetTheDiscount ) == 0;
        }

        public void ApplyDiscount()
        {
            int freeItemsQty = GetNumberOfFreeItems();

            if (freeItemsQty == 0) return;

            Cart lineDiscount = new Cart();
            int qtyDiscount = GetNumberOfFreeItems();
            lineDiscount.Description = $"Free {qtyDiscount} {_itemToGive.Code}";
            lineDiscount.AdId = _itemToGive.Id;
            lineDiscount.Quantity = qtyDiscount;
            lineDiscount.EntryId = _cartLines[0].EntryId;
            lineDiscount.Total = 0;
            lineDiscount.LineNumber = _cartLines.Max( l=> l.LineNumber) + 1;
            _cartLines.Add(lineDiscount);
        }

        private int GetNumberOfFreeItems()
        {
            var item = _cartLines.FirstOrDefault(i => i.AdId == _itemToApplyDiscount);
            return item == null ? 0 : item.Quantity / _quantityRequiredToGetTheDiscount;
        }
    }
}
