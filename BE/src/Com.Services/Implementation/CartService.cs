using System;
using System.Collections.Generic;
using System.Linq;
using Com.Common;
using Com.Data;
using Com.Repo;

namespace Com.Services
{
    public class CartService : BaseService<Cart>, ICartService
    {
        private List<Ad> _ads;
        private List<Cart> _cartLines = new List<Cart>();
        private Guid _userId;
        private List<IDiscountRule> _discountRules;
        private int _headerLineNumber = (int)CartLines.HeaderLine;

        public CartService(IRepository repo, List<Ad> ads) : base(repo)
        {
            SetAds(ads);
            _discountRules = new List<IDiscountRule>();
        }

        public CartService(IRepository repo) : base(repo)
        {
            _discountRules = new List<IDiscountRule>();
        }

        public void SetAds(List<Ad> ads)
        {
            Guards.IsNotNull(ads, "Ads");
            Guards.IsNotZero(ads.Count, "Ads");
            _ads = ads;
        }

        public Cart AddCart(Dictionary<string, int> order, Guid userId)
        {
            return AddCart(order, userId, Guid.NewGuid());
        }

        public Cart AddCart(Dictionary<string, int> order, Guid userId, Guid EntryId)
        {
            Guards.IsNotNull(order, "Order");
            Guards.IsNotEmptyGuid(userId, "UserId");
            
            _userId = userId;
            SetCartLines(order, EntryId);

            if (_cartLines.Count == 0) return null;

            SetCartHeaderLine(EntryId);
            SetDiscountRules();
            ApplyDiscount();
            SetCalculateTotals();

            return _cartLines.FirstOrDefault(c => c.LineNumber == _headerLineNumber);
        }

        private void ApplyDiscount()
        {
            if (_discountRules.Count == 0) return;

            foreach (IDiscountRule dr in _discountRules)
                 dr.ApplyDiscount();
        }

        private void SetCartLines(Dictionary<string, int> order, Guid entryId)
        {
            int lineNumber = 1;

            foreach (KeyValuePair<string, int> orderLine in order)
            {
                if (orderLine.Value <= 0) continue;

                var ad = _ads.FirstOrDefault(a => a.Code == orderLine.Key);
                Guards.IsNotNull(ad, "Ad");
                Cart line = new Cart();
                line.Description = $"{ad.Code} - {ad.Description}";
                line.Quantity = orderLine.Value;
                line.LineNumber = lineNumber;
                line.UnitPrice = ad.Price;
                line.AdId = ad.Id;
                line.Creator = _userId;
                line.Modifier = _userId;
                line.AddedDate = DateTime.Now;
                line.EntryId = entryId;
                line.UserId = _userId;
                _cartLines.Add(line);
                lineNumber++;
            }
        }

        private void SetCartHeaderLine(Guid entryId)
        {
            Cart header = new Cart();
            header.Description = $"Order {DateTime.Now.ToShortDateString()}";
            header.Quantity = 1;
            header.LineNumber = _headerLineNumber;
            header.Creator = _userId;
            header.Modifier = _userId;
            header.AddedDate = DateTime.Now;
            header.EntryId = entryId;
            header.UserId = _userId;
            _cartLines.Insert(_headerLineNumber, header);
        }
        
        private void SetCalculateTotals()
        {
            double headerTotal = 0.0;

            for (int i=1; i<_cartLines.Count; i++)
            {
                _cartLines[i].Total = _cartLines[i].UnitPrice * _cartLines[i].Quantity;
                headerTotal += _cartLines[i].Total;
            }

            _cartLines[_headerLineNumber].Total = headerTotal;
        }

        private void SetDiscountRules()
        {
            switch (_userId){
                case var g when(g == Constants.UserId):
                    _discountRules.Add(
                        new FreeItemsRule(_cartLines, Constants.AdClassic, 2, _ads.FirstOrDefault(ad => ad.Code == "classic"), 1)
                    );
                    break;
                case var g when(g == Constants.UserApple):
                    _discountRules.Add(new LessPriceRule(_cartLines, Constants.AdStandout, 299.99));
                    break;
                case var g when(g == Constants.UserFord):
                    _discountRules.Add(
                        new FreeItemsRule(_cartLines, Constants.AdClassic, 4, _ads.FirstOrDefault(ad => ad.Code == "classic"), 1)
                    );
                    _discountRules.Add(
                        new LessPriceRule(_cartLines, Constants.AdPremium, 389.99, 3)
                    );
                    break;
                default:
                    break;
            }
        }

        //TODO : This two methods to get the data from the database
        public List<Cart> GetCartLines(Guid entryId)
        {
            return _cartLines.Where(c=>c.EntryId == entryId).ToList();
        }

        public List<Cart> GetCartLines(Guid entryId, bool includeHeader)
        {
            if (includeHeader) return GetCartLines(entryId);

            return _cartLines.Where(c=>c.EntryId == entryId && c.LineNumber != _headerLineNumber).ToList();
        }

        public List<Cart> GetUserCarts(Guid userId)
        {
            return _cartLines.Where(c => c.UserId == userId).ToList();
        }
    }
}
