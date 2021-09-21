using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Entities;

namespace FvManagerApi.Models
{
    public class CreateInvoicePossitionDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal NetPrice { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int TaxRate { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }
    }
}
