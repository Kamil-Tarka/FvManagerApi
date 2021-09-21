using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Entities;

namespace FvManagerApi.Models
{
    public class CreateInvoiceDto
    {
        public string InvoiceNumber { get; set; }
        [Required]
        public DateTime DateOfInvoice { get; set; } = DateTime.Now;
        [Required]
        public DateTime DateOfSale { get; set; } = DateTime.Now;
        [Required]
        public DateTime DateOfPayment { get; set; } = DateTime.Now;
        [Required]
        public int PaymentTypeId { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public int BuyerId { get; set; }
        [Required]
        public List<CreateInvoicePossitionDto> InvoicePossitions { get; set; }
    }
}
