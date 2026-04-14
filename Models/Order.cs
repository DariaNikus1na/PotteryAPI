using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PotteryAPI.Models;

[Index("OrderDate", Name = "IX_Orders_OrderDate")]
[Index("UserId", Name = "IX_Orders_UserId")]
[Index("UserId", "OrderDate", Name = "IX_Orders_UserId_OrderDate")]
public partial class Order
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? OrderDate { get; set; }

    public string? Status { get; set; }

    [Column(TypeName = "NUMERIC(10,2)")]
    public decimal TotalAmount { get; set; }

    public string ShippingAddress { get; set; } = null!;

    public string? PaymentMethod { get; set; }

    public string? DeliveryMethod { get; set; }

    public string? Comment { get; set; }

    [InverseProperty("Order")]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    [InverseProperty("Order")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    [ForeignKey("UserId")]
    [InverseProperty("Orders")]
    public virtual User User { get; set; } = null!;
}
