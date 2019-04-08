using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Com.Data
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    
        [Required]
        public Guid Creator { get; set; }

        [DefaultValue(typeof(DateTime))]
        public DateTime AddedDate { get; set; }

        [Required]
        public Guid Modifier { get; set; }

        [DefaultValue(typeof(DateTime))]
        public DateTime ModifiedDate { get; set; }
    }
}
