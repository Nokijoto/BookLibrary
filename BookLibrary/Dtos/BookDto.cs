namespace BookLibrary.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public Guid BookUuid { get; set; }
        public string Title { get; set; } = null!;
        public int TotalPages { get; set; }
        public int Rating { get; set; }
        public string? Isbn { get; set; } = null!;
        public string PublishedDate { get; set; }
        public string? Description { get; set; } = null!;
        public string? ImageUrl { get; set; } = null!;
        public ICollection<BookShelfDto>? BookShelves { get; set; }
    }
}
