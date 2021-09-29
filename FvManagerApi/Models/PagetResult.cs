using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FvManagerApi.Models
{
    public class PagetResult<T>
    {
        public List<T> Data { get; set; }
        public int TotalPages { get; set; }
        public int ItemsFrom { get; set; }
        public int ItemsTo { get; set; }
        public int TotalItemsCount { get; set; }

        public PagetResult(List<T> data, int totalItemsCount, int pageSize, int pageNumber)
        {
            Data = data;
            TotalItemsCount = totalItemsCount;
            ItemsFrom = pageSize * (pageNumber - 1) + 1;
            ItemsTo = ItemsFrom + pageSize - 1;
            TotalPages = (int)Math.Ceiling(totalItemsCount / (double)pageSize);
        }
    }
}
