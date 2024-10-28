using MediatR;
using MyApiProject.API.Commands;
using MyApiProject.API.Data;
using MyApiProject.API.Models;

namespace MyApiProject.API.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock
            };

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            return product.Id; // Indica que el comando se ejecutó correctamente
        }
    }
}
