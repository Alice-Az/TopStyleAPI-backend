using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopStyleAPI.Domain.Entities;

[Table("UsersNew")]
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserEmail { get; set; } = null!;

    [Required]
    public string UserPassword { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
