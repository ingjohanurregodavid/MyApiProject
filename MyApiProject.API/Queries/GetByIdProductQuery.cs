using MediatR;
using MyApiProject.API.Models;

namespace MyApiProject.API.Queries
{
    public class GetByIdProductQuery:IRequest<Product>
    {
        public int Id { get; set; }

        public GetByIdProductQuery(int id)
        {
            Id = id;
        }
    }
}
