using Microsoft.EntityFrameworkCore.Migrations;
using MyApiProject.API.Repositories;

namespace MyApiProject.API.Data
{
    public interface IUnitOfWork:IDisposable
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
        IOrderHistoryRepository OrderHistory { get; }
        Task<int> CompleteAsync();
    }
}
