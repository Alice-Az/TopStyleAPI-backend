﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopStyleAPI.Domain.Entities;

[Table("OrdersNew")]
public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    public decimal OrderPrice { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }

    public virtual List<OrderProduct> OrderProducts { get; set; } = [];

    public virtual User User { get; set; } = null!;
}
