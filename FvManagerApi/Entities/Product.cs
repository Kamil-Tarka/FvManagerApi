using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FvManagerApi.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal NetPrice { get; set; }
        public int TaxRate { get; set; }

        public virtual List<InvoicePossition> InvoicePossitions { get; set; }

    }
}
