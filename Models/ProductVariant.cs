using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PotteryAPI.Models;

[Index("Sku", IsUnique = true)]
[Index("ProductId", Name = "IX_ProductVariants_ProductId")]
[Index("StockQuantity", Name = "IX_ProductVariants_StockQuantity")]
[Index("ProductId", Name = "UQ_ProductVariants_DefaultPerProduct", IsUnique = true)]
public partial class ProductVariant
{
    [Key]
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string? VariantName { get; set; }

    [Column("SKU")]
    public string? Sku { get; set; }

    [Column(TypeName = "NUMERIC(10,2)")]
    public decimal? Price { get; set; }

    public int StockQuantity { get; set; }

    public string? ImageUrl { get; set; }

    public int? IsDefaultVariant { get; set; }

    public string? Material { get; set; }

    public int? VolumeMl { get; set; }

    [Column(TypeName = "NUMERIC(5,2)")]
    public decimal? HeightCm { get; set; }

    [Column(TypeName = "NUMERIC(5,2)")]
    public decimal? DiameterCm { get; set; }

    [InverseProperty("Variant")]
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    [InverseProperty("Variant")]
    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    [InverseProperty("Variant")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [ForeignKey("ProductId")]
    [InverseProperty("ProductVariant")]
    public virtual Product Product { get; set; } = null!;
}
