using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FvManagerApi.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime DateOfInvoice { get; set; } = DateTime.Now;
        public DateTime DateOfSale { get; set; } = DateTime.Now;
        public DateTime DateOfPayment { get; set; } = DateTime.Now;

        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        public int SellerId { get; set; }
        public virtual Company Seller { get; set; }

        public int BuyerId { get; set; }
        public virtual Company Buyer { get; set; }

        public virtual List<InvoicePossition> InvoicePossitions { get; set; }
    }
}
