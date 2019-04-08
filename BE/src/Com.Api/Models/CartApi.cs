using System;

namespace Com.Api
{
    public class CartApi
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid UserId { get; set; }

        public Guid EntryId { get; set; }

        public Guid AdId { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public double Total { get; set; }

        public int LineNumber { get; set; }

        public DateTime AddDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
