namespace MyApiProject.API.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
