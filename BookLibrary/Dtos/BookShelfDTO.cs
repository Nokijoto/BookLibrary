namespace BookLibrary.Dtos
{
    public class BookShelfDto
    {
        public int ShelfId { get; set; }
        public ShelfDto Shelf { get; set; }

        public int BookId { get; set; }
        public BookDto Book { get; set; }
    }
}
