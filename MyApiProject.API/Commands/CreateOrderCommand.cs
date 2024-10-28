using MediatR;
using MyApiProject.API.DTOs;
using MyApiProject.API.Models;

namespace MyApiProject.API.Commands
{
    public class CreateOrderCommand:IRequest<OrderDto>
    {
        public List<OrderItemDto> Items { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
