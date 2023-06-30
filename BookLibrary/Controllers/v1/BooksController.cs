
using BookLibrary.Dtos;
using BookLibrary.Dtos.FormsRecivedDto;
using BookLibrary.Services;
using BookLibrary.Services.Commands.BooksCommands;
using BookLibrary.Services.Commands.BooksCommands.newer;
using BookLibrary.Services.Commands.BookShelvesCommands;
using BookLibrary.Services.Query.BookShelfsQuery;
using BookLibrary.Services.Query.BooksQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace BookLibrary.Controllers.v1
{
    public class BooksController : BaseApiController
    {
        private readonly ISender _mediator;

        public BooksController(ISender mediator)
        {
            _mediator = mediator;

        }


        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetBooks()
        {
            var query = new GetBooks.Query();
            return await _mediator.Send(new GetBooks.Query());
        }

        [HttpGet("{id}")]
        public async Task<BookDto> GetBookById(int id)
        {
            var bookD = new BookDto()
            {
                Id = id
            };
            return await _mediator.Send(new GetBookById.Query { book = bookD });
        }
        [HttpGet("{uuid}")]
        public async Task<BookDto> GetBookByUuid(Guid uuid)
        {
            var bookD = new BookDto()
            {
                BookUuid = uuid
            };
            return await _mediator.Send(new GetBookByUuid.Query { book = bookD });
        }


        [Authorize]
        [HttpGet("{uuid}")]
        public async Task<ICollection<BookDto>> GetBooksFromShelvesByUuid(Guid uuid)
        {
            var shelveD = new ShelfDto()
            {
                ShelfUuid = uuid
            };
            return await _mediator.Send(new GetBooksFromShelvesByUuid.Query { Shelf = shelveD });
        }





        [Authorize]
        [HttpPost]
        public async Task<Result> BindBookWithShelves([FromBody] NewBookShelvesDto bookShelf)
        {
            Console.WriteLine(bookShelf);
            var bookShelveD = new BookShelfDto()
            {
                Book = new BookDto()
                {
                    BookUuid = bookShelf.BookUuid
                },
                Shelf = new ShelfDto()
                {
                    ShelfUuid = bookShelf.ShelveUuid
                }
            };

            await _mediator.Send(new BindBookToShelf.Command { BookShelf = bookShelveD });
            return Result.Ok();
        }

        [Authorize]
        [HttpPost]
        public async Task<Result> UnBindBookWithShelves([FromBody] NewBookShelvesDto bookShelf)
        {
            Console.WriteLine(bookShelf.ToJson());
            var bookShelveD = new BookShelfDto()
            {
                Book = new BookDto()
                {
                    BookUuid = bookShelf.BookUuid
                },
                Shelf = new ShelfDto()
                {
                    ShelfUuid = bookShelf.ShelveUuid
                }
            };
            await _mediator.Send(new UnbindBookToShelf.Command { BookShelf = bookShelveD });
            return Result.Ok();
        }

        [Authorize]
        [HttpPost]
        public async Task AddBook([FromBody] NewBookDto newBook)
        {
            var bookD = new BookDto()
            {
                Id = newBook.Id,
                BookShelves = null,
                BookUuid = newBook.BookUuid,
                Description = newBook.Description,
                ImageUrl = newBook.ImageUrl,
                Isbn = newBook.Isbn,
                PublishedDate = newBook.PublishedDate,
                Rating = newBook.Rating,
                Title = newBook.Title,
                TotalPages = newBook.TotalPages


            };
            await _mediator.Send(new AddBook.Command { Book = bookD });
        }
        [Authorize]
        [HttpPost]
        public async Task AddBookv2([FromBody] NewBookDto newBook)
        {
            var bookD = new BookDto()
            {
                Id = newBook.Id,
                BookShelves = null,
                BookUuid = newBook.BookUuid,
                Description = newBook.Description,
                ImageUrl = newBook.ImageUrl,
                Isbn = newBook.Isbn,
                PublishedDate = newBook.PublishedDate,
                Rating = newBook.Rating,
                Title = newBook.Title,
                TotalPages = newBook.TotalPages


            };
            await _mediator.Send(new AddBookCommand { Book = bookD });
        }

        [Authorize]
        [HttpPut("{uuid}")]
        public async Task<Result> UpdateBook(Guid uuid, [FromBody] NewBookDto newBook)
        {
            Console.WriteLine(newBook.ToJson());
            var bookD = new BookDto()
            {
                Id = newBook.Id,
                BookShelves = null,
                BookUuid = uuid,
                Description = newBook.Description,
                ImageUrl = newBook.ImageUrl,
                Isbn = newBook.Isbn,
                PublishedDate = newBook.PublishedDate,
                Rating = newBook.Rating,
                Title = newBook.Title,
                TotalPages = newBook.TotalPages


            };
            await _mediator.Send(new UpdateBook.Command { Book = bookD });

            return Result.Ok();
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById(int id)
        {
            var bookD = new BookDto
            {
                Id = id
            };
            await _mediator.Send(new DeleteBook.Command { Book = bookD });
            return NoContent();
        }
        [Authorize]
        [HttpDelete("{uuid}")]
        public async Task<IActionResult> DeleteBookByUuid(Guid uuid)
        {

            var bookD = new BookDto
            {
                BookUuid = uuid
            };
            await _mediator.Send(new DeleteBook.Command { Book = bookD });
            return NoContent();
        }

    }

}