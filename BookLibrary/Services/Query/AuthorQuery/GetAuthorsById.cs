
using BookLibrary.Data;
using BookLibrary.Dtos;
using MediatR;

namespace BookLibrary.Services.Query.AuthorQuery
{
    public class GetAuthorsById
    {
        public class Query : IRequest<AuthorDto>
        {
            public AuthorDto author { get; set; }
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
                if (request.author.AuthorUuid != null)
                {
                    var author = await _db.Authors.FindAsync(request.author.AuthorId);
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