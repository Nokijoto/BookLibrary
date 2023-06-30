
using BookLibrary.Data;
using BookLibrary.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services.Query.Query.AuthorQuery
{
    public class GetAuthorsByUuid
    {
        public class Query : IRequest<AuthorDto>
        {
            public AuthorDto? Author { get; internal set; }
        }
        public class QueryHandler : IRequestHandler<Query, AuthorDto>
        {
            private readonly ApplicationDbContext _db;
            public QueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }
            public async Task<AuthorDto> Handle(Query request, CancellationToken cancellationToken)
            {
                if (request.Author.AuthorUuid != null)
                {
                    var author = await _db.Authors.Where(x => x.AuthorUuid == request.Author.AuthorUuid).FirstOrDefaultAsync(cancellationToken);
                    var authorDto = new AuthorDto
                    {
                        AuthorId = author.AuthorId,
                        AuthorUuid = author.AuthorUuid,
                        BirthDate = author.BirthDate,
                        Description = author.Description,
                        FirstName = author.FirstName,
                        LastName = author.LastName,
                        ImageUrl = author.ImageUrl

                    };
                    return authorDto;
                }
                else
                {
                    throw new Exception("Book not found");
                }

            }

        }
    }
}
