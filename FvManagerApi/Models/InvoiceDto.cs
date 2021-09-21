using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Entities;

namespace FvManagerApi.Models
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime DateOfInvoice { get; set; } = DateTime.Now;
        public DateTime DateOfSale { get; set; } = DateTime.Now;
        public DateTime DateOfPayment { get; set; } = DateTime.Now;

        public PaymentType PaymentType { get; set; }

        public Company Seller { get; set; }

        public Company Buyer { get; set; }

        public List<InvoicePossitionDto> InvoicePossitions { get; set; }
    }
}
