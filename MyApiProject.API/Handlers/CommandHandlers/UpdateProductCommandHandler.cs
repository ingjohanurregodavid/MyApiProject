using MediatR;
using MyApiProject.API.Commands;
using MyApiProject.API.Data;

namespace MyApiProject.API.Handlers.CommandHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);
            if (product == null) throw new Exception("Producto no encontrado");

            product.Stock = request.Stock;
            product.Price = request.Price;
            product.Name = request.Name;
            await _unitOfWork.Products.UpdateAsync(product);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
