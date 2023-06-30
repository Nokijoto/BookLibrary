﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Models.PageModels;
[Keyless]
[Table("book_shelfs")]
[Index("BookId", Name = "book_id")]
[Index("ShelfId", Name = "shelf_id")]
public partial class BookShelfs
{
    [Column("shelf_id", TypeName = "int(11)")]
    public int ShelfId { get; set; }

    [Column("book_id", TypeName = "int(11)")]
    public int BookId { get; set; }

    [ForeignKey("BookId")]
    public virtual Books Book { get; set; }

    [ForeignKey("ShelfId")]
    public virtual Shelfs Shelf { get; set; }
}