
using BookLibrary.Data;
using BookLibrary.Dtos;
using BookLibrary.Models.PageModels;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services.Commands.AuthorsCommands
{
    public class AddAuthors
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
                    var lastId = await _db.Authors.OrderByDescending(x => x.AuthorId).FirstOrDefaultAsync(cancellationToken);
                    if (request.Author == null)
                    {
                        throw new Exception("Author not found");
                    }
                    var newAuthor = new Authors()
                    {
                        AuthorId = lastId.AuthorId + 1,
                        AuthorUuid = Guid.NewGuid(),
                        FirstName = request.Author.FirstName,
                        LastName = request.Author.LastName,
                        BirthDate = request.Author.BirthDate,
                        Description = request.Author.Description,
                        ImageUrl = request.Author.ImageUrl,

                    };
                    _db.Authors.AddAsync(newAuthor, cancellationToken);
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
