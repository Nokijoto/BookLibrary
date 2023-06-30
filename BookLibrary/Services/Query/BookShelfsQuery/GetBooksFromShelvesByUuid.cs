using BookLibrary.Data;
using BookLibrary.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services.Query.BookShelfsQuery
{
    public class GetBooksFromShelvesByUuid
    {
        public class Query : IRequest<ICollection<BookDto>>
        {

            public ShelfDto Shelf { get; internal set; }
        }

        public class QueryHandler : IRequestHandler<Query, ICollection<BookDto>>
        {
            private readonly ApplicationDbContext _db;

            public QueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }

            public async Task<ICollection<BookDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                if (request.Shelf.ShelfUuid != null)
                {
                    var booksOnShelf = await _db.Books
                        .Include(b => b.BookShelves)
                        .ThenInclude(bs => bs.Shelf)
                        .Where(b => b.BookShelves.Any(bs => bs.Shelf.ShelfUuid == request.Shelf.ShelfUuid))
                        .ToListAsync(cancellationToken);

                    var bookDtos = booksOnShelf.Select(b => new BookDto
                    {
                        BookUuid = b.BookUuid,
                        Title = b.Title,
                        Description = b.Description,
                        TotalPages = b.TotalPages,
                        Rating = b.Rating,
                        PublishedDate = b.PublishedDate,
                        Isbn = b.Isbn,
                        ImageUrl = b.ImageUrl
                    }).ToList();

                    return bookDtos;
                }
                else
                {
                    throw new Exception("Shelf UUID not provided");
                }
            }

        }
    }
}
