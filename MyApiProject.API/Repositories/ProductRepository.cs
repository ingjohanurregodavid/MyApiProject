using Microsoft.EntityFrameworkCore;
using MyApiProject.API.Data;
using MyApiProject.API.Models;

namespace MyApiProject.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) { 
            _context = context;
        }
         
        public async Task AddAsync(Product product)
        {
           await _context.Products.AddAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null) { 
                _context.Products.Remove(product);
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product= await _context.Products.FindAsync(id);
            if (product == null) throw new Exception("Producto no encontrado");

            return product;
        }

        public async Task UpdateAsync(Product product)
        {
           _context.Products.Update(product);
        }
    }
}
