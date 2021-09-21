using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FvManagerApi.Entities;
using FvManagerApi.Exceptions;
using FvManagerApi.Models;

namespace FvManagerApi.Services
{
    class ProductService : IProductService
    {
        private readonly FvManagerDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(FvManagerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(CreateProductDto dto)
        {
            var productEntity = _mapper.Map<Product>(dto);
            _dbContext.Product.Add(productEntity);
            _dbContext.SaveChanges();

            return productEntity.Id;

        }

        public ProductDto GetById(int productId)
        {
            var product = _dbContext.Product.FirstOrDefault(p => p.Id == productId);

            if (product is null)
            {
                throw new NotFoundException("Product not found");
            }

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public List<ProductDto> GetAll()
        {
            var products = _mapper.Map<List<ProductDto>>(_dbContext.Product);

            return products;
        }

        public void Delete(int productId)
        {
            var product = _dbContext.Product.FirstOrDefault(p => p.Id == productId);

            if (product is null)
            {
                throw new NotFoundException("Product not found");
            }

            _dbContext.Product.Remove(product);
            _dbContext.SaveChanges();
        }

        public void Update(int id, UpdateProductDto dto)
        {
            var product = _dbContext.Product.FirstOrDefault(p => p.Id == id);

            if (product is null)
            {
                throw new NotFoundException("Product not found");
            }

            if (dto.Name is not null && (dto.Name!="" || dto.Name!= " "))
            {
                product.Name = dto.Name;
            }
            if (dto.NetPrice > 0)
            {
                product.NetPrice = dto.NetPrice;
            }
            if(dto.TaxRate>0)
            {
                product.TaxRate = dto.TaxRate;
            }

            _dbContext.SaveChanges();
        }
    }
}
