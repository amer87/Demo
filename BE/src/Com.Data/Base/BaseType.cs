using System.ComponentModel.DataAnnotations;

namespace Com.Data
{
    public class BaseType
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }
}
