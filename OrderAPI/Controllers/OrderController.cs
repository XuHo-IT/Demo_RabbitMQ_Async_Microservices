using Microsoft.AspNetCore.Mvc;
using OrderAPI.Repository;
using Shared.DTOs;
using Shared.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrder orderInterface) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddOrder(Order order)
        {
            var response = await orderInterface.AddOrderAsync(order);
            return response.Flag ? Ok(response) : BadRequest(response);
        }
    }
}
