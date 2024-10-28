using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApiProject.API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [Range(0,int.MaxValue,ErrorMessage ="El stock no puede ser negativo")]
        public int Stock { get; set; }

        [Required]
        [Range(0,double.MaxValue,ErrorMessage ="El precio no  puede ser negativo")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
