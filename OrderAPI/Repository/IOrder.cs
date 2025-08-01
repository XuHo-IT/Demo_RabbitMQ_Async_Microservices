using Shared.DTOs;
using Shared.Models;

namespace OrderAPI.Repository
{
    public interface IOrder
    {
        Task<ServiceResponse> AddOrderAsync(Order order);
        Task<List<Order>> GetAllOrderAsync();
        Task<OrderSummary> GetOrderSummaryAsync();
    }
}
