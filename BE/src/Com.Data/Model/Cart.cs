using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Data
{
    [Table("Carts")]

    public class Cart : BaseEntity
    {

        [MaxLength(240)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public Guid UserId { get; set; }

        [Required]
        [ForeignKey("EntryId")]
        public Guid EntryId { get; set; }

        public Guid AdId { get; set; }

        [Range(1, 100)]
        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        [Range(0.0, double.MaxValue)]
        public double Total { get; set; }

        [Required]
        [MaxLength(2)]
        public int LineNumber { get; set; }
    }
}
