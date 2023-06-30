﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Models.PageModels;

[Table("shelfs")]
public partial class Shelfs
{
    [Key]
    [Column("shelf_id", TypeName = "int(11)")]
    public int ShelfId { get; set; }

    [Column("shelf_uuid")]
    public Guid ShelfUuid { get; set; }

    [Required]
    [Column("shelf_name")]
    [StringLength(50)]
    public string ShelfName { get; set; }
    [Required]
    [Column("created_by_un")]
    [StringLength(256)]
    public string? CreatedByUn { get; set; }
    public ICollection<BookShelfs> BookShelves { get; set; }
    public ICollection<UserShelfs> UserShelfs { get; set; }
}