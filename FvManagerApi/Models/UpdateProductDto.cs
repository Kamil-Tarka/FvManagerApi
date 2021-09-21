using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FvManagerApi.Models
{
    public class UpdateProductDto
    {
        public string Name { get; set; }
        public decimal NetPrice { get; set; }
        public int TaxRate { get; set; }
    }
}
