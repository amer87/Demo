using Com.Common;
using System;

namespace Com.Api
{
    public class UserApi
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserTypes Type { get; set; }

        public DateTime AddedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
