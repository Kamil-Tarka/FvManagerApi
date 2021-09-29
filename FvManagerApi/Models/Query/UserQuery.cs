using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FvManagerApi.Models.Query
{
    public class UserQuery : Query
    {
        public string SearchName { get; set; }
        public string SearchEmail { get; set; }
        public string SearchRole { get; set; }
        public string SearchIsActive { get; set; }
    }
}
