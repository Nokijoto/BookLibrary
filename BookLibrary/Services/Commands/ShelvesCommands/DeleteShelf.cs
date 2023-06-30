
using BookLibrary.Data;
using BookLibrary.Dtos;
using FluentValidation;
using MediatR;

namespace BookLibrary.Services.Commands.ShelvesCommands
{
    public class DeleteShelf
    {
        public class Command : IRequest
        {
            public ShelfDto Shelf { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(command => command.Shelf).NotNull().WithMessage("Book cannot be null");
                RuleFor(command => command.Shelf.ShelfUuid).NotEmpty().WithMessage("BookUuid  is required");
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
                    if (!(request.Shelf.ShelfUuid.Equals(null)))
                    {
                        var itemToDelete = _db.Shelfs.Where(s => s.ShelfUuid.Equals(request.Shelf.ShelfUuid)).FirstOrDefault();
                        if (!(itemToDelete.Equals(null)))
                        {
                            _db.Shelfs.Remove(itemToDelete);
                        }
                    }
                    _db.SaveChanges();
                    _db.Dispose();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

        }
    }
}
