
using Book_Library_API.Services.Query.ShelvesQuery;
using BookLibrary.Dtos;
using BookLibrary.Dtos.FormsRecivedDto;
using BookLibrary.Models;
using BookLibrary.Services.Commands.ShelvesCommands;
using BookLibrary.Services.Query.BookShelfsQuery;
using BookLibrary.Services.Query.ShelvesQuery;
using BookLibrary.Services.Query.UsersShelfQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers.v1
{
    public class ShelvesController : BaseApiController
    {
        private readonly ISender _mediator;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ShelvesController(ISender mediator, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _mediator = mediator;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]

        public async Task<IEnumerable<ShelfDto>> GetShelves()
        {

            return await _mediator.Send(new GetShelves.Query());

        }

        [HttpGet("{id}")]
        public async Task<ShelfDto> GetShelvesById(int id)
        {
            var shelfD = new ShelfDto()
            {
                ShelfId = id
            };
            return await _mediator.Send(new GetShelvesById.Query { requestItem = shelfD });
        }
        [HttpGet("{uuid}")]
        public async Task<ShelfDto> GetShelvesByUuid(Guid uuid)
        {
            var shelfD = new ShelfDto()
            {
                ShelfUuid = uuid
            };
            return await _mediator.Send(new GetShelvesByUuid.Query { requestItem = shelfD });
        }
        [Authorize]
        [HttpGet("{uuid}")]
        public async Task<ICollection<BookDto>> GetBooksFromShelvesUuid(Guid uuid)
        {
            var shelfD = new ShelfDto()
            {
                ShelfUuid = uuid
            };
            return await _mediator.Send(new GetBooksFromShelvesByUuid.Query { Shelf = shelfD });
        }
        [Authorize]
        [HttpGet("{username}")]
        public async Task<ICollection<ShelfDto>> GetShelfsByUserName(string username)
        {
            var userD = new ApplicationUser()
            {
                UserName = username
            };
            return await _mediator.Send(new GetShelfsUserByUserName.Query { user = userD });
        }

        [Authorize]
        [HttpPost]
        public async Task AddShelves([FromBody] NewShelfDto shelf)
        {
            await _mediator.Send(new AddShelf.Command { Shelf = shelf });
        }

        [Authorize]
        [HttpPut("{uuid}")]
        public async Task UpdateShelves(Guid uuid, [FromBody] NewShelfDto newShelf)
        {
            var item = new ShelfDto()
            {
                ShelfUuid = uuid,
                CreatedByUN = newShelf.CreatedByUN,
                ShelfName = newShelf.ShelfName,

            };
            await _mediator.Send(new UpdateShelf.Command { Shelfs = item });
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task DeleteShelvesById(int id)
        {
            var shelfD = new ShelfDto()
            {
                ShelfId = id
            };
            await _mediator.Send(new DeleteShelf.Command { Shelf = shelfD });
        }
        [Authorize]
        [HttpDelete("{uuid}")]
        public async Task DeleteShelvesGuuid(Guid uuid)
        {
            Console.WriteLine(uuid.ToString());
            var shelfD = new ShelfDto()
            {
                ShelfUuid = uuid
            };
            await _mediator.Send(new DeleteShelf.Command { Shelf = shelfD });
        }
    }
}
