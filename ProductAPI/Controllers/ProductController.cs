using Microsoft.AspNetCore.Mvc;
using ProductAPI.Repository;
using Shared.DTOs;
using Shared.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProduct productInterface) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddProduct(Product product)
        {
            var response = await productInterface.AddProductAsync(product);
            return response.Flag ? Ok(response) : BadRequest(response);
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() => await productInterface.GetAllProductAsync();
    }
}
