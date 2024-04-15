using System.ComponentModel.DataAnnotations;

namespace TopStyleAPI.Domain.Entities
{
    public class OrderProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
