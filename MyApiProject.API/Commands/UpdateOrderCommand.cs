using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MyApiProject.API.Models;

namespace MyApiProject.API.Commands
{
    public class UpdateOrderCommand:IRequest<Unit>
    {
        public int OrderId { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}
