using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FvManagerApi.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string PasswordHash { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public List<UserCompanies> UserCompanies { get; set; }

    }
}
