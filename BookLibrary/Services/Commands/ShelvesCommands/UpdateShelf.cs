
using BookLibrary.Data;
using BookLibrary.Dtos;
using BookLibrary.Models.PageModels;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services.Commands.ShelvesCommands
{
    public class UpdateShelf
    {
        public class Command : IRequest
        {
            public ShelfDto Shelfs { get; internal set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(command => command.Shelfs).NotNull().WithMessage("Shelf cannot be null");
                RuleFor(command => command.Shelfs.ShelfName).NotEmpty().WithMessage("ShelfName  is required");
                RuleFor(command => command.Shelfs.CreatedByUN).NotEmpty().WithMessage("CreatedByUN  is required");

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
                    var ifExist = await _db.Shelfs.Where(x => x.ShelfUuid == request.Shelfs.ShelfUuid).FirstOrDefaultAsync(cancellationToken);
                    if (ifExist == null)
                    {
                        throw new Exception("Book not found");
                    }
                    else
                    {
                        var newShelf = new Shelfs()
                        {
                            ShelfUuid = ifExist.ShelfUuid,
                            ShelfName = request.Shelfs.ShelfName,
                        };
                        _db.Shelfs.Update(newShelf);
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
