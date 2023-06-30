
#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookLibrary.Models.PageModels;

[Table("authors")]
public partial class Authors
{
    [Key]
    [Column(TypeName = "int(11)")]
    public int AuthorId { get; set; }

    [Column("author_uuid")]
    public Guid AuthorUuid { get; set; }

    [Required]
    [Column("first_name")]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [Column("last_name")]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    [Column("birth_date")]
    [StringLength(50)]
    public string BirthDate { get; set; }

    [Required]
    [Column("description")]
    [StringLength(500)]
    public string Description { get; set; }

    [Required]
    [Column("imageUrl")]
    [StringLength(1000)]
    public string ImageUrl { get; set; }
}