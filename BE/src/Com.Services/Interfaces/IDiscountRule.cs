using Com.Data;
using System.Collections.Generic;

namespace Com.Services
{
    internal interface IDiscountRule
    {
        bool IsMatched();
        void ApplyDiscount();
    }
}
