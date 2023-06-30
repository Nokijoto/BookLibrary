
using BookLibrary.Data;
using BookLibrary.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services.Query.BooksQuery
{
    public class GetBookByUuid
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
                if (request.book.BookUuid != null)
                {
                    var books = await _db.Books.Where(x => x.BookUuid == request.book.BookUuid).FirstOrDefaultAsync(cancellationToken);
                    var bookDto = new BookDto
                    {
                        Id = books.BookId,
                        BookUuid = books.BookUuid,
                        Description = books.Description,
                        ImageUrl = books.ImageUrl,
                        Isbn = books.Isbn,
                        Title = books.Title,
                        TotalPages = books.TotalPages,
                        Rating = books.Rating

                    };
                    return bookDto;

                }
                else
                {
                    throw new Exception("Book not found");
                }


            }

        }
    }
}
