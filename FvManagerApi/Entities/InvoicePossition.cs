using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FvManagerApi.Entities
{
    public class InvoicePossition
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; }

        public int ProductId { get; set; }
        public virtual Product Porduct { get; }

        public decimal NetPrice { get; set; }
        public int TaxRate { get; set; }
        public int Amount { get; set; }

    }
}
