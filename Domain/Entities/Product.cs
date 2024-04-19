using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopStyleAPI.Domain.Entities;

[Table("ProductsNew")]
public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string ProductName { get; set; } = null!;

    [Required]
    public string ProductDescription { get; set; } = null!;

    [Required]
    public decimal ProductPrice { get; set; }

    public string? ProductImage { get; set; }

    public virtual List<OrderProduct> OrderProducts { get; set; } = [];
}
