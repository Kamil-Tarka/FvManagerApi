using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FvManagerApi.Models
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Nip { get; set; }
        public bool IsPhisicalPerson { get; set; } = false;
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

    }
}
