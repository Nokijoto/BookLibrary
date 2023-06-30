
using BookLibrary.Data;
using BookLibrary.Dtos;
using MediatR;

namespace BookLibrary.Services.Query.BooksQuery
{
    public class GetBookById
    {
        public class Query : IRequest<BookDto>
        {
            public BookDto book { get; set; }
        }
        public class QueryHandler : IRequestHandler<Query, BookDto>
        {
            private readonly ApplicationDbContext _db;
            public QueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }
            public async Task<BookDto> Handle(Query request, CancellationToken cancellationToken)
            {

                var book = await _db.Books.FindAsync(request.book.Id, cancellationToken);
                var bookDto = new BookDto
                {
                    Id = book.BookId,
                    BookUuid = book.BookUuid,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl,
                    Isbn = book.Isbn,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    Rating = book.Rating

                };
                return bookDto;
            }

        }
    }
}
