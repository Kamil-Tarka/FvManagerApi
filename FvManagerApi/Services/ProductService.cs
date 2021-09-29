using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using FvManagerApi.Entities;
using FvManagerApi.Exceptions;
using FvManagerApi.Models;
using FvManagerApi.Models.Query;

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

        public PagetResult<ProductDto> GetAll(ProductQuery productQuery)
        {
            var baseQuery = _dbContext.Product
                .Where(p => productQuery.SearchName == null || p.Name.Contains(productQuery.SearchName));

            if (!string.IsNullOrEmpty(productQuery.SortBy))
            {

                var columnsSekectors = new Dictionary<string, Expression<Func<Product, object>>>
                {
                    { nameof(Product.Name), p => p.Name },
                    { nameof(Product.NetPrice), p => p.NetPrice }
                };

                var selectedColumn = columnsSekectors[productQuery.SortBy];

                baseQuery = productQuery.SortDirection == SortDirection.ASC
                    ? baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var products = baseQuery
                .Skip(productQuery.PageSize * (productQuery.PageNumber - 1))
                .Take(productQuery.PageSize)
                .ToList();

            var productsDto = _mapper.Map<List<ProductDto>>(products);

            var result = new PagetResult<ProductDto>(productsDto, baseQuery.Count(), productQuery.PageSize, productQuery.PageNumber);

            return result;
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

            if (dto.Name is not null && (dto.Name != "" || dto.Name != " "))
            {
                product.Name = dto.Name;
            }
            if (dto.NetPrice > 0)
            {
                product.NetPrice = dto.NetPrice;
            }
            if (dto.TaxRate > 0)
            {
                product.TaxRate = dto.TaxRate;
            }

            _dbContext.SaveChanges();
        }
    }
}
