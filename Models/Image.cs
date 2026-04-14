using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PotteryAPI.Models;

[Index("VariantId", "IsPrimary", Name = "IX_Images_IsPrimary")]
[Index("VariantId", Name = "IX_Images_VariantId")]
public partial class Image
{
    [Key]
    public int Id { get; set; }

    public int VariantId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int? SortOrder { get; set; }

    public int? IsPrimary { get; set; }

    [ForeignKey("VariantId")]
    [InverseProperty("Images")]
    public virtual ProductVariant Variant { get; set; } = null!;
}
