
using BookLibrary.Data;
using BookLibrary.Dtos;
using BookLibrary.Models.PageModels;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace BookLibrary.Services.Commands.BooksCommands
{
    public class AddBook
    {
        public class Command : IRequest
        {
            public BookDto Book { get; internal set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(command => command.Book).NotNull().WithMessage("Book cannot be null");
                RuleFor(command => command.Book.Title).NotEmpty().WithMessage("Title  is required");
                RuleFor(command => command.Book.PublishedDate).NotEmpty().WithMessage("PublishedDate  is required");
                RuleFor(command => command.Book.Isbn).NotNull().WithMessage("Isbn is required");
                RuleFor(command => command.Book.TotalPages).NotEmpty().WithMessage("TotalPages is required");
                RuleFor(command => command.Book.Description).NotEmpty().WithMessage("Description is required");
            }
        }
        public class CommandHandler : IRequestHandler<Command>
        {
            private readonly ApplicationDbContext _db;
            public CommandHandler(ApplicationDbContext db)
            {
                _db = db;
            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {

                var validator = new CommandValidator();
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }
                try
                {
                    var lastId = await _db.Books.OrderByDescending(x => x.BookId).FirstOrDefaultAsync(cancellationToken);
                    if (request.Book == null)
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
                    await _db.Books.FindAsync(newBook.BookId, cancellationToken);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

        }
    }
}
