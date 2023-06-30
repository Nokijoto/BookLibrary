
using BookLibrary.Data;
using BookLibrary.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services.Query.ShelvesQuery
{
    public class GetShelves
    {
        public class Query : IRequest<ICollection<ShelfDto>> { }
        public class QueryHandler : IRequestHandler<Query, ICollection<ShelfDto>>
        {
            private readonly ApplicationDbContext _db;
            public QueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }
            public async Task<ICollection<ShelfDto>> Handle(Query request, CancellationToken cancellationToken)
            {

                var items = await _db.Shelfs.ToListAsync();
                var itemsDto = new List<ShelfDto>();
                foreach (var item in items)
                {
                    itemsDto.Add(new ShelfDto
                    {
                        ShelfId = item.ShelfId,
                        ShelfUuid = item.ShelfUuid,
                        ShelfName = item.ShelfName,
                    });
                }
                return itemsDto;
            }

        }
    }
}
