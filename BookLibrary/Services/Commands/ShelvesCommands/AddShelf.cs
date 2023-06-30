
using BookLibrary.Data;
using BookLibrary.Dtos.FormsRecivedDto;
using BookLibrary.Models.PageModels;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace BookLibrary.Services.Commands.ShelvesCommands
{
    public class AddShelf
    {
        public class Command : IRequest
        {
            public NewShelfDto Shelf { get; internal set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(command => command.Shelf).NotNull().WithMessage("Shelf cannot be null");
                RuleFor(command => command.Shelf.ShelfName).NotEmpty().WithMessage("ShelfName  is required");
                RuleFor(command => command.Shelf.CreatedByUN).NotEmpty().WithMessage("CreatedByUN  is required");

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
                    Console.WriteLine(request.Shelf.ToJson());
                    var lastId = await _db.Shelfs.OrderByDescending(x => x.ShelfId).FirstOrDefaultAsync(cancellationToken);
                    if (request.Shelf == null)
                    {
                        throw new Exception("Shelf not found");
                    }
                    var newShelf = new Shelfs()
                    {
                        ShelfId = lastId.ShelfId + 1,
                        ShelfUuid = Guid.NewGuid(),
                        ShelfName = request.Shelf.ShelfName,
                        CreatedByUn = request.Shelf.CreatedByUN
                    };
                    _db.Shelfs.AddAsync(newShelf, cancellationToken);
                    _db.SaveChanges();
                    await _db.Books.FindAsync(newShelf.ShelfId, cancellationToken);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

        }
    }
}
