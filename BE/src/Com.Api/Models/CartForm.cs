using System;

namespace Com.Api
{
    public class CartForm
    {
        public int ClassicQuantity { get; set; }
        public int StandoutQuantity { get; set; }
        public int PremiumQuantity { get; set; }
        public Guid UserId { get; set; }
    }
}
