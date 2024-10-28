using MyApiProject.API.Models;

namespace MyApiProject.API.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdWithItemsAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status);
        Task<IEnumerable<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus);
        Task AddOrderAsync(Order order);
        Task<IEnumerable<Order>> GetAllAsync();

    }
}
