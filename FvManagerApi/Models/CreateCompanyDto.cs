using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FvManagerApi.Models
{
    public class CreateCompanyDto
    {
        [Required]
        public string Name { get; set; }
        public string? Nip { get; set; }
        [Required]
        public bool IsPhisicalPerson { get; set; } = false;
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
    }
}
