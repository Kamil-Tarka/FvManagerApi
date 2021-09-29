using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FvManagerApi.Models.Query
{
    public class InvoiceQuery : Query
    {
        public string SearchNumber { get; set; }
        public string SearchDateFrom { get; set; }
        public string SearchDateTo { get; set; }
    }
}
