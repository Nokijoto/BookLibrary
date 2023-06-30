using BookLibrary.Data;
using BookLibrary.Dtos;
using BookLibrary.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services.Query.UsersShelfQuery
{
    public class GetShelfsUserByUserName
    {
        public class Query : IRequest<ICollection<ShelfDto>>
        {
            public ApplicationUser user { get; set; }
        }
        public class QueryHandler : IRequestHandler<Query, ICollection<ShelfDto>>
        {
            private readonly ApplicationDbContext _db;
            public QueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }
            public async Task<ICollection<ShelfDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                if (request.user.UserName != null)
                {
                    var items = await _db.Shelfs
                    .Where(s => s.CreatedByUn == request.user.UserName)
                    .ToListAsync();
                    var shelves = new List<ShelfDto>();
                    foreach (var item in items)
                    {
                        shelves.Add(new ShelfDto
                        {
                            ShelfName = item.ShelfName,
                            CreatedByUN = item.CreatedByUn,
                            ShelfUuid = item.ShelfUuid
                        });
                    }
                    return shelves;

                }
                else
                {
                    throw new Exception("Shelf not found");
                }

            }
        }
    }

}
