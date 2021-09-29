using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FvManagerApi.Models;
using FvManagerApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FvManagerApi.Controllers
{
    [Route("api/fvmanager/product")]
    [ApiController]
    [Authorize(Policy = "IsUserAccoundActive")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> GetAll([FromQuery] string searchName)
        {
            var result = _productService.GetAll(searchName);

            return Ok(result);
        }

        [HttpGet("{productId}")]
        public ActionResult<ProductDto> GetById([FromRoute] int productId)
        {
            var result = _productService.GetById(productId);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] CreateProductDto dto)
        {
            var id = _productService.Create(dto);

            return Created($"api/fvmanager/product/{id}", null);
        }

        [HttpDelete("{productId}")]
        public ActionResult Delete([FromRoute] int productId)
        {
            _productService.Delete(productId);

            return NoContent();
        }

        [HttpPut("{productId}")]
        public ActionResult Update([FromRoute] int productId, [FromBody] UpdateProductDto dto)
        {
            _productService.Update(productId, dto);

            return Ok();
        }
    }
}
