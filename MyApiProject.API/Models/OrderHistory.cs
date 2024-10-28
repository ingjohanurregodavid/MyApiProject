using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace MyApiProject.API.Models
{
    public class OrderHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [Required]
        public OrderStatus PreviousStatus { get; set; }

        [Required]
        public OrderStatus NewStatus { get; set; }


        [Required]
        public DateTime ChangedAt { get; set; }
    }
}
