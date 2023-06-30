
using BookLibrary.Data;
using BookLibrary.Dtos;
using MediatR;

namespace Book_Library_API.Services.Query.ShelvesQuery
{
    public class GetShelvesByUuid
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
                if (request.requestItem.ShelfUuid != null)
                {
                    var item = await _db.Shelfs.FindAsync(request.requestItem.ShelfUuid);
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
