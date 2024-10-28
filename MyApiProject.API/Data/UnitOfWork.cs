using MyApiProject.API.Repositories;

namespace MyApiProject.API.Data
{
    public class UnitOfWork: IUnitOfWork
    {
        public readonly ApplicationDbContext _context;
       
        public UnitOfWork(ApplicationDbContext context) { 
            _context = context;
            Products = new ProductRepository(context);
            Orders = new OrderRepository(context);
            OrderHistory = new OrderHistoryRepository(context);
        }

        public IProductRepository Products { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IOrderHistoryRepository OrderHistory { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
