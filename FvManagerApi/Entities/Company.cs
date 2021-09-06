using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FvManagerApi.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Nip { get; set; }
        public bool IsPhisicalPerson { get; set; } = false;

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual List<UserCompanies> UserCompanies { get; set; }

    }
}
