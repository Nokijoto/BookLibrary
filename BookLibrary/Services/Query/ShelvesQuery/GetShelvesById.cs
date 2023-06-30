
using BookLibrary.Data;
using BookLibrary.Dtos;
using MediatR;

namespace BookLibrary.Services.Query.ShelvesQuery
{
    public class GetShelvesById
    {
        public class Query : IRequest<ShelfDto>
        {
            public ShelfDto requestItem { get; set; }
        }
        public class QueryHandler : IRequestHandler<Query, ShelfDto>
        {
            private readonly ApplicationDbContext _db;
            public QueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }
            public async Task<ShelfDto> Handle(Query request, CancellationToken cancellationToken)
            {
                if (request.requestItem.ShelfId != null)
                {
                    var item = await _db.Shelfs.FindAsync(request.requestItem.ShelfId);
                    var itemDto = new ShelfDto
                    {
                        ShelfId = item.ShelfId,
                        ShelfName = item.ShelfName,
                        ShelfUuid = item.ShelfUuid
                    };
                    return itemDto;
                }
                else
                {
                    throw new Exception("Book not found");
                }
            }

        }
    }
}
