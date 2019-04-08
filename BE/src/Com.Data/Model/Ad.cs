using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Data
{
    [Table("Ads")]

    public class Ad : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(240)]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
