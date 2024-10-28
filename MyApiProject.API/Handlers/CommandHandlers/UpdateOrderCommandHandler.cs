using MediatR;
using MyApiProject.API.Commands;
using MyApiProject.API.Data;

namespace MyApiProject.API.Handlers.CommandHandlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Orders.UpdateOrderStatusAsync(request.OrderId, request.NewStatus);
            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
