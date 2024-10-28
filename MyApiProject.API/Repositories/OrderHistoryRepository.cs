using MyApiProject.API.Data;
using MyApiProject.API.Models;

namespace MyApiProject.API.Repositories
{
    public class OrderHistoryRepository : IOrderHistoryRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderHistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(OrderHistory entity)
        {
           await _context.AddAsync(entity);
        }

        public Task<IEnumerable<OrderHistory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderHistory> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(OrderHistory entity)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderHistory entity)
        {
            throw new NotImplementedException();
        }
    }
}
