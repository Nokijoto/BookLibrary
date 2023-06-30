
#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models.PageModels;

[Table("books")]
public partial class Books
{
    [Key]
    [Column("book_id", TypeName = "int(11)")]
    public int BookId { get; set; }

    [Column("book_uuid")]
    public Guid BookUuid { get; set; }

    [Required]
    [Column("title")]
    [StringLength(100)]
    public string Title { get; set; }

    [Column("total_pages", TypeName = "int(11)")]
    public int TotalPages { get; set; }

    [Column("rating", TypeName = "int(11)")]
    public int Rating { get; set; }

    [Required]
    [Column("isbn")]
    [StringLength(30)]
    public string Isbn { get; set; }

    [Required]
    [Column("published_date")]
    [StringLength(50)]
    public string PublishedDate { get; set; }

    [Required]
    [Column("description")]
    [StringLength(500)]
    public string Description { get; set; }

    [Required]
    [Column("imageUrl")]
    [StringLength(1000)]
    public string ImageUrl { get; set; }
    public ICollection<BookShelfs> BookShelves { get; set; }
}