using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PotteryAPI.Models;

[Index("Sku", IsUnique = true)]
[Index("CategoryId", Name = "IX_Products_CategoryId")]
[Index("IsActive", Name = "IX_Products_IsActive")]
[Index("Price", Name = "IX_Products_Price")]
public partial class Product
{
    [Key]
    public int Id { get; set; }

    [Column("SKU")]
    public string? Sku { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [Column(TypeName = "NUMERIC(10,2)")]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public int? AuthorId { get; set; }

    public string? CreatedAt { get; set; }

    public int? IsActive { get; set; }

    [Column(TypeName = "NUMERIC(2,1)")]
    public decimal? Rating { get; set; }

    [ForeignKey("AuthorId")]
    [InverseProperty("Products")]
    public virtual Author? Author { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ProductVariant? ProductVariant { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
