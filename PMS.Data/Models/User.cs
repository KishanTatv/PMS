using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PMS.Data.Models;

[Table("User")]
public partial class User
{
    [Key]
    [StringLength(20)]
    public string Id { get; set; } = null!;

    [StringLength(30)]
    public string? FirstName { get; set; }

    [StringLength(30)]
    public string? LastName { get; set; }

    [StringLength(20)]
    public string? PhoneNo { get; set; }

    [StringLength(20)]
    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }
}
