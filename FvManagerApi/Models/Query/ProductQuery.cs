using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FvManagerApi.Models.Query
{
    public class ProductQuery : Query
    {
        public string SearchName { get; set; }
    }
}
