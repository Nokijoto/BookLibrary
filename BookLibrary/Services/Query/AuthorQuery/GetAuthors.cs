
using BookLibrary.Data;
using BookLibrary.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services.Query.AuthorQuery
{
    public class GetAuthors
    {
        public class Query : IRequest<ICollection<AuthorDto>> { }
        public class QueryHandler : IRequestHandler<Query, ICollection<AuthorDto>>
        {
            private readonly ApplicationDbContext _db;
            public QueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }
            public async Task<ICollection<AuthorDto>> Handle(Query request, CancellationToken cancellationToken)
            {

                var authors = await _db.Authors.ToListAsync();
                var authorsDto = new List<AuthorDto>();
                foreach (var item in authors)
                {
                    authorsDto.Add(new AuthorDto
                    {
                        AuthorId = item.AuthorId,
                        AuthorUuid = item.AuthorUuid,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        BirthDate = item.BirthDate,
                        Description = item.BirthDate,
                        ImageUrl = item.ImageUrl,
                    });
                }


                return authorsDto;
            }

        }
    }
}
