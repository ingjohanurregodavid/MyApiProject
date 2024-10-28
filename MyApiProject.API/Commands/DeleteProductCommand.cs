using MediatR;
using System.Security.Principal;

namespace MyApiProject.API.Commands
{
    public class DeleteProductCommand:IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
                Id = id;
        }
    }
}
