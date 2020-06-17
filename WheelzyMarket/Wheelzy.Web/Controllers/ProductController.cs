using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wheelzy.Models.Dto;
using Wheelzy.Services.Contracts;

namespace Wheelzy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        //[Route("/{CategoryId}/{SubCategoryId}/{Description}")]
        public async Task<IActionResult> Get()
        {
            var response = await _productService.GetProduct();

            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllAvailables")]
        public async Task<IActionResult> GetAvailables()
        {
            var response = await _productService.GetProductAvailable();

            return Ok(response);
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] ProductDto req)
        {
            var response = await _productService.GetProductById(req.Id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductDto req)
        {
            var response = await _productService.SaveProduct(req);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProductDto req)
        {
            var response = await _productService.UpdateProduct(req);

            return Ok(response);
        }

        [HttpPut]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] ProductDto req)
        {
            var response = await _productService.DeleteProduct(req);

            return Ok(response);
        }
    }
}
