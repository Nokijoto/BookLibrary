
using BookLibrary.Dtos;
using BookLibrary.Dtos.FormsRecivedDto;
using BookLibrary.Services.Commands.AuthorsCommands;
using BookLibrary.Services.Query.AuthorQuery;
using BookLibrary.Services.Query.Query.AuthorQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace BookLibrary.Controllers.v1
{

    public class AuthorsController : BaseApiController
    {
        private readonly ISender _mediator;
        public AuthorsController(ISender mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]

        public async Task<ICollection<AuthorDto>> GetAuthors()
        {
            return await _mediator.Send(new GetAuthors.Query());
        }

        [HttpGet("{id}")]
        public async Task<AuthorDto> GetAuthorsById(int id)
        {
            var authorD = new AuthorDto()
            {
                AuthorId = id
            };
            return await _mediator.Send(new GetAuthorsById.Query { author = authorD });
        }
        [HttpGet("{uuid}")]
        public async Task<AuthorDto> GetAuthorsByUuid(Guid uuid)
        {
            var authorD = new AuthorDto()
            {
                AuthorUuid = uuid
            };
            return await _mediator.Send(new GetAuthorsByUuid.Query { Author = authorD });
        }

        [Authorize]
        [HttpPost]
        public async Task AddAuthor([FromBody] NewAuthorDto newauthor)
        {
            var authorD = new AuthorDto()
            {
                AuthorId = newauthor.AuthorId,
                AuthorUuid = Guid.NewGuid(),
                BirthDate = newauthor.BirthDate,
                Description = newauthor.Description,
                FirstName = newauthor.FirstName,
                ImageUrl = newauthor.ImageUrl,
                LastName = newauthor.LastName

            };
            await _mediator.Send(new AddAuthors.Command { Author = authorD });
        }
        [Authorize]
        [HttpPut("{uuid}")]
        public async Task UpdateAuthor(Guid uuid, [FromBody] AuthorDto newauthor)
        {
            Console.WriteLine(newauthor.ToJson());
            var authorD = new AuthorDto()
            {
                AuthorId = newauthor.AuthorId,
                AuthorUuid = uuid,
                BirthDate = newauthor.BirthDate,
                Description = newauthor.Description,
                FirstName = newauthor.FirstName,
                ImageUrl = newauthor.ImageUrl,
                LastName = newauthor.LastName

            };
            await _mediator.Send(new UpdateAuthors.Command { Author = authorD });
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task DeleteAuthorById(int id)
        {
            var authorD = new AuthorDto()
            {
                AuthorId = id
            };
            await _mediator.Send(new DeleteAuthors.Command { Author = authorD });
            await Task.CompletedTask;
        }
        [Authorize]
        [HttpDelete("{uuid}")]
        public async Task DeleteAuthorGuuid(Guid uuid)
        {
            var authorD = new AuthorDto()
            {
                AuthorUuid = uuid
            };
            await _mediator.Send(new DeleteAuthors.Command { Author = authorD });
            await Task.CompletedTask;
        }

    }
}
