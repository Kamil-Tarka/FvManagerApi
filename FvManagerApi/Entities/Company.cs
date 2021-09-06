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
        public string Nip { get; set; }

        public int AdressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual List<UserCompanies> CompanyUsers { get; set; }

    }
}
