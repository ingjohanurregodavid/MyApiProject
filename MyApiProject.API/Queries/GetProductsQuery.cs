using MediatR;
using MyApiProject.API.DTOs;

namespace MyApiProject.API.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}
