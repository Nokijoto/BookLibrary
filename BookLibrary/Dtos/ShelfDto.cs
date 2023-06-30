namespace BookLibrary.Dtos
{
    public class ShelfDto
    {
        public int ShelfId { get; set; }
        public Guid ShelfUuid { get; set; }
        public string ShelfName { get; set; }
        public string? CreatedByUN { get; set; }
        //public string? CreatedById { get; set; }

        public ICollection<BookShelfDto> BookShelves { get; set; }
    }
}
