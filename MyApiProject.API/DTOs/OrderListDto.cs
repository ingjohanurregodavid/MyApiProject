using MyApiProject.API.Models;

namespace MyApiProject.API.DTOs
{
    public class OrderListDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public OrderStatus status { get; set; }
    }
}
