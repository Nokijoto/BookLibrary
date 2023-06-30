
using BookLibrary.Data;
using BookLibrary.Models.PageModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services.Commands.BooksCommands.newer
{
    public class AddBookCommandHandler : ICommandHandler<AddBookCommand>, IRequestHandler<AddBookCommand>
    {
        private readonly ApplicationDbContext _db;
        public AddBookCommandHandler(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task Handle(AddBookCommand request, CancellationToken cancellationToken)
        {

            try
            {
                //var validationResult = new AddBookCommandValidator().Validate();
                //if (!validationResult.IsValid)
                //{
                //    return Result.Fail(validationResult);
                //}

                var lastId = await _db.Books.OrderByDescending(x => x.BookId).FirstOrDefaultAsync(cancellationToken);
                if (request.Book == null)
                {
                    throw new Exception("Book not found");
                }
                var isExist = _db.Books.Any(x => x.BookUuid == request.Book.BookUuid);
                if (isExist)
                {
                    throw new Exception("Book not found");
                }
                var newBook = new Books()
                {
                    BookId = lastId.BookId + 1,
                    BookUuid = Guid.NewGuid(),
                    Title = request.Book.Title,
                    Description = request.Book.Description,
                    ImageUrl = request.Book.ImageUrl,
                    Isbn = request.Book.Isbn,
                    PublishedDate = request.Book.PublishedDate,
                    Rating = request.Book.Rating,
                    TotalPages = request.Book.TotalPages
                };
                _db.Books.AddAsync(newBook, cancellationToken);
                _db.SaveChanges();


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }


}
