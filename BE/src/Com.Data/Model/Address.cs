using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Data
{
    [Table("Addresses")]
    public class Address : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public String AddressLine1 { get; set; }

        [Required]
        [MaxLength(50)]
        public String AddressLine2 { get; set; }

        [Required]
        [MaxLength(50)]
        public String Country { get; set; }

        [Required]
        [MaxLength(50)]
        public String State { get; set; }

        [Required]
        [MaxLength(50)]
        public String City { get; set; }

        [Required]
        public Guid BelongsTo { get; set; }

        public Common.AddressTypes Type { get; set; } = Common.AddressTypes.Conference;

    }
}
