using MediatR;
using MyApiProject.API.Commands;
using MyApiProject.API.Data;
using MyApiProject.API.DTOs;
using MyApiProject.API.Models;

namespace MyApiProject.API.Handlers.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // Crear la orden
            var order = new Order
            {
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                Items = new List<OrderItem>() // Inicializa la lista
            };

            // Validar y agregar cada producto solicitado
            foreach (var item in request.Items)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(item.ProductId);
                if (product == null)
                    throw new Exception($"Producto con ID {item.ProductId} no encontrado.");

                if (product.Stock < item.Quantity) // Validar stock
                    throw new Exception($"No hay suficiente stock para el producto con ID {item.ProductId}.");

                // Crear y agregar el ítem a la orden
                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };
                order.Items.Add(orderItem);

                // Decrementar el stock del producto
                product.Stock -= item.Quantity;
                await _unitOfWork.Products.UpdateAsync(product); // Asegúrate de marcar el producto como modificado
                await _unitOfWork.CompleteAsync();
            }

            // Agregar la orden a la base de datos
            await _unitOfWork.Orders.AddOrderAsync(order);
            await _unitOfWork.CompleteAsync();
            // Crear un historial de la orden
            var orderHistory = new OrderHistory
            {
                OrderId = order.Id,
                NewStatus = order.Status,
                PreviousStatus = OrderStatus.Pending,
                ChangedAt = DateTime.UtcNow
            };
            await _unitOfWork.OrderHistory.AddAsync(orderHistory);

            // Guardar todos los cambios en una sola transacción
            await _unitOfWork.CompleteAsync();
            var orderDto = new OrderDto
            {
                Id = order.Id,
                Items = order.Items.Select(i => new OrderItemDto
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };

            return orderDto;
        }
    }
}
