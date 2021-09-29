using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FvManagerApi.Models.Query
{
    public class CompanyQuery : Query
    {
        public string SearchName { get; set; }
        public string SearchNip { get; set; }
    }
}
