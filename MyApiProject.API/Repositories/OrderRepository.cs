using Microsoft.EntityFrameworkCore;
using MyApiProject.API.Data;
using MyApiProject.API.Models;

namespace MyApiProject.API.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetByIdWithItemsAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
        {
            return await _context.Orders
                .Where(o => o.Status == status)
                .Include(o => o.Items)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Orders
                .Where(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate)
                .Include(o => o.Items)
                .ToListAsync();
        }

        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null) throw new Exception($"Orden con ID {orderId} no encontrada.");

            // Crear un registro de historial solo si el estado cambia
            if (order.Status != newStatus)
            {
                var history = new OrderHistory
                {
                    OrderId = orderId,
                    PreviousStatus = order.Status,
                    NewStatus = newStatus,
                    ChangedAt = DateTime.UtcNow
                };

                order.Status = newStatus;
                order.UpdatedAt = DateTime.UtcNow;

                _context.orderHistories.Add(history);
            }

            _context.Orders.Update(order);
        }

        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }
    }
}
