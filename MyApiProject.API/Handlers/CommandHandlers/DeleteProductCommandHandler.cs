using MediatR;
using MyApiProject.API.Commands;
using MyApiProject.API.Data;

namespace MyApiProject.API.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);
            if (product == null) throw new Exception("Producto no encontrado");

            await _unitOfWork.Products.DeleteAsync(request.Id);
            await _unitOfWork.CompleteAsync();
            return Unit.Value;
        }
    }
}
