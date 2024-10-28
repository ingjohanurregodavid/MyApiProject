using MediatR;
using MyApiProject.API.Data;
using MyApiProject.API.Models;
using MyApiProject.API.Queries;

namespace MyApiProject.API.Handlers.QueryHandlers
{
    public class GetByIdProductsQueryHandler : IRequestHandler<GetByIdProductQuery, Product>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdProductsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Product> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Products.GetByIdAsync(request.Id);          
        }
    }
}
