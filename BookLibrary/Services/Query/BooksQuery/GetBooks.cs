
using BookLibrary.Data;
using BookLibrary.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services.Query.BooksQuery
{
    public partial class GetBooks
    {
        public class Query : IRequest<IEnumerable<BookDto>> { }
        public class QueryHandler : IRequestHandler<Query, IEnumerable<BookDto>>
        {
            private readonly ApplicationDbContext _db;
            public QueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }
            public async Task<IEnumerable<BookDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var books = await _db.Books.ToListAsync();
                var booksDto = new List<BookDto>();
                foreach (var item in books)
                {
                    booksDto.Add(new BookDto
                    {
                        Id = item.BookId,
                        BookUuid = item.BookUuid,
                        Description = item.Description,
                        ImageUrl = item.ImageUrl,
                        Isbn = item.Isbn,
                        Title = item.Title,
                        TotalPages = item.TotalPages,
                        Rating = item.Rating
                    });
                }
                return booksDto;
            }

        }

    }
}
