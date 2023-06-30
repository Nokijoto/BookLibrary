
using BookLibrary.Data;
using BookLibrary.Dtos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace BookLibrary.Services.Commands.BooksCommands
{
    public class UpdateBook
    {
        public class Command : IRequest
        {
            public BookDto? Book { get; internal set; }
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
                    var item = await _db.Books.Where(x => x.BookUuid == request.Book.BookUuid).FirstOrDefaultAsync(cancellationToken);
                    var ifExist = await _db.Books.Where(x => x.BookUuid == request.Book.BookUuid).FirstOrDefaultAsync(cancellationToken);
                    if (item == null)
                    {
                        throw new Exception("Book not found");
                    }
                    else
                    {
                        item.BookId = item.BookId;
                        item.BookUuid = item.BookUuid;
                        item.Rating = request.Book.Rating;
                        item.Title = request.Book.Title;
                        item.Description = request.Book.Description;
                        item.ImageUrl = request.Book.ImageUrl;
                        item.TotalPages = request.Book.TotalPages;
                        item.BookShelves = null;
                        item.Isbn = request.Book.Isbn;
                        item.PublishedDate = request.Book.PublishedDate;
                        item.BookShelves = null;
                        Console.WriteLine(item.ToJson());
                        _db.Books.Update(item);
                        _db.SaveChanges();

                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

        }
    }
}
