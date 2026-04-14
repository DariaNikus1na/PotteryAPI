using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PotteryAPI.Models;

public partial class Author
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Bio { get; set; }

    public string? ImageUrl { get; set; }

    [InverseProperty("Author")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
