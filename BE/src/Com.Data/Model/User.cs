using Com.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.Data
{

    [Table("Users")]

    public class User : BaseEntity
    {

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        [MaxLength(25)]
        public string Email { get; set; }

        [Required]
        [MaxLength(240)]
        public string Password { get; set; }

        [Required]
        //[MaxLength(1)]
        public UserTypes Type { get; set; } = UserTypes.User;
    }
}
