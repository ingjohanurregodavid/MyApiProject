using MediatR;
using MyApiProject.API.DTOs;

namespace MyApiProject.API.Queries
{
    public class GetOrdersQuery : IRequest<IEnumerable<OrderListDto>>
    {
    }
}
