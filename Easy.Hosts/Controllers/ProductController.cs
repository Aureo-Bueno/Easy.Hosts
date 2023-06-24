using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.ProductDto;
using Easy.Hosts.Core.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.Hosts.Controllers
{
    [Route("api/easyhosts/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Product> product = await _productRepository.FindAllAsync();
            return Ok(product);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            Product product = await _productRepository.GetByIdAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ProductCreate productCreate)
        {
            await _productRepository.InsertAsync(productCreate);
            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update()
        {
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}
