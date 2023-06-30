
using BookLibrary.Data;
using BookLibrary.Dtos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace BookLibrary.Services.Commands.BooksCommands
{
    public class DeleteBook
    {
        public class Command : IRequest
        {
            public BookDto Book { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(command => command.Book).NotNull().WithMessage("Book cannot be null");
                RuleFor(command => command.Book.BookUuid).NotEmpty().WithMessage("BookUuid  is required");
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
                    Console.WriteLine(request.Book.ToJson());
                    if (request.Book.BookUuid != null)
                    {
                        var itemToDelete = await _db.Books.Where(x => x.BookUuid == request.Book.BookUuid).FirstOrDefaultAsync(cancellationToken);
                        Console.WriteLine(itemToDelete.ToJson());
                        if (itemToDelete != null)
                        {
                            _db.Books.Remove(itemToDelete);
                        }
                    }
                    else if (request.Book.Id != null || request.Book.Id != 0)
                    {
                        var itemToDelete = await _db.Books.FindAsync(request.Book.Id);
                        if (itemToDelete != null)
                        {
                            _db.Books.Remove(itemToDelete);
                        }
                    }


                    await _db.SaveChangesAsync();
                    await _db.DisposeAsync();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }

        }
    }
}

