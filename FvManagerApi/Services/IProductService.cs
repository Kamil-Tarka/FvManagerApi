using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Models;
using FvManagerApi.Models.Query;

namespace FvManagerApi.Services
{
    public interface IProductService
    {
        public int Create(CreateProductDto dto);
        public ProductDto GetById(int productId);
        public PagetResult<ProductDto> GetAll(ProductQuery productQuery);
        public void Delete(int productId);
        public void Update(int id, UpdateProductDto dto);
    }
}
