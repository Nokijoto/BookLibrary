using BookLibrary.Data;
using BookLibrary.Dtos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services.Commands.AuthorsCommands
{
    public class UpdateAuthors
    {
        public class Command : IRequest
        {
            public AuthorDto Author { get; internal set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(command => command.Author).NotNull().WithMessage("Author cannot be null");
                RuleFor(command => command.Author.FirstName).NotEmpty().WithMessage("First name is required");
                RuleFor(command => command.Author.LastName).NotEmpty().WithMessage("Last name is required");
                RuleFor(command => command.Author.BirthDate).NotNull().WithMessage("Birth date is required");
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
                    var ifExist = await _db.Authors.Where(x => x.AuthorUuid == request.Author.AuthorUuid).FirstOrDefaultAsync(cancellationToken);
                    if (ifExist == null)
                    {
                        throw new Exception("Author not found");
                    }
                    else
                    {
                        ifExist.FirstName = request.Author.FirstName;
                        ifExist.LastName = request.Author.LastName;
                        ifExist.BirthDate = request.Author.BirthDate;
                        ifExist.Description = request.Author.Description;
                        ifExist.ImageUrl = request.Author.ImageUrl;
                    };
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
