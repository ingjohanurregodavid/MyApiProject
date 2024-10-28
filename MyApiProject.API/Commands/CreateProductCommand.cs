using MediatR;

namespace MyApiProject.API.Commands
{
    public class CreateProductCommand: IRequest<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public CreateProductCommand(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
    }
}
