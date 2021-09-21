using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Models;

namespace FvManagerApi.Services
{
    public interface IProductService
    {
        public int Create(CreateProductDto dto);
        public ProductDto GetById(int productId);
        public List<ProductDto> GetAll();
        public void Delete(int productId);
        public void Update(int id, UpdateProductDto dto);
    }
}
