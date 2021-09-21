using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FvManagerApi.Models
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal NetPrice { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int TaxRate { get; set; }
    }
}
