using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Entities;

namespace FvManagerApi.Models
{
    public class UpdateInvoicePossitionDto
    {

       // public int InvoiceId { get; set; }

        public int ProductId { get; set; }
        public decimal NetPrice { get; set; }
        public int TaxRate { get; set; }
        public int Amount { get; set; }
    }
}
