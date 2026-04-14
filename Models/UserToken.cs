using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PotteryAPI.Models;

[Index("RefreshToken", IsUnique = true)]
[Index("UserId", Name = "IX_UserTokens_UserId")]
public partial class UserToken
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public string RefreshToken { get; set; } = null!;

    public string ExpiresAt { get; set; } = null!;

    public string? CreatedAt { get; set; }

    public string? RevokedAt { get; set; }

    public string? DeviceInfo { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserTokens")]
    public virtual User User { get; set; } = null!;
}
