namespace BookLibrary.Dtos
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public Guid AuthorUuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

    }
}
