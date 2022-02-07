using System;
using System.Collections.Generic;

#nullable disable

namespace InternalWebApi.Models
{
    public partial class Account
    {
        public int RoleId { get; set; }
        public int AccountId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual Role Role { get; set; }
    }
}
