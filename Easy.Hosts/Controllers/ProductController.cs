using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.Product;
using Easy.Hosts.Core.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            return Ok();
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
