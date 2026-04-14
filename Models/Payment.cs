using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PotteryAPI.Models;

public partial class Payment
{
    [Key]
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string? PaymentDate { get; set; }

    [Column(TypeName = "NUMERIC(10,2)")]
    public decimal Amount { get; set; }

    public string? PaymentStatus { get; set; }

    public string? TransactionId { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("Payments")]
    public virtual Order Order { get; set; } = null!;
}
