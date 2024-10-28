using MediatR;

namespace MyApiProject.API.Commands
{
    public class UpdateProductCommand:IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public UpdateProductCommand(int id, string name, decimal price, int stock)
        {
            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }
    }
}
