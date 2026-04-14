using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PotteryAPI.Models;

[Table("Cart")]
[Index("UserId", Name = "IX_Cart_UserId")]
public partial class Cart
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int VariantId { get; set; }

    public int Quantity { get; set; }

    public string? AddedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Carts")]
    public virtual User User { get; set; } = null!;

    [ForeignKey("VariantId")]
    [InverseProperty("Carts")]
    public virtual ProductVariant Variant { get; set; } = null!;
}
