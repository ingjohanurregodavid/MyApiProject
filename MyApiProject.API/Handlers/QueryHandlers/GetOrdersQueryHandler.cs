using MediatR;
using MyApiProject.API.Data;
using MyApiProject.API.DTOs;
using MyApiProject.API.Queries;

namespace MyApiProject.API.Handlers.QueryHandlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<OrderListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetOrdersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<OrderListDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.Orders.GetAllAsync();
            return products.Select(p => new OrderListDto
            {
                Id = p.Id,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                status = p.Status,
            }).ToList();
        }
    }
}
