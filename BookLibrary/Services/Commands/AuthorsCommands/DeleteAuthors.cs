
using BookLibrary.Data;
using BookLibrary.Dtos;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace BookLibrary.Services.Commands.AuthorsCommands
{
    public class DeleteAuthors
    {
        public class Command : IRequest
        {
            public AuthorDto Author { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(command => command.Author).NotNull().WithMessage("Author cannot be null");
                RuleFor(command => command.Author.AuthorUuid).NotEmpty().WithMessage("Author Uuid is required");
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
                    if (request.Author.AuthorUuid != null)
                    {

                        Console.WriteLine(request.Author.ToJson());
                        var itemToDelete = await _db.Authors.Where(x => x.AuthorUuid == request.Author.AuthorUuid).FirstOrDefaultAsync();
                        Console.WriteLine(itemToDelete.ToJson());
                        if (itemToDelete != null)
                        {
                            _db.Authors.Remove(itemToDelete);
                        }
                    }
                    if (request.Author.AuthorId != null)
                    {
                        var itemToDelete = await _db.Authors.Where(x => x.AuthorId == request.Author.AuthorId).FirstOrDefaultAsync(); if (itemToDelete != null)
                        {
                            _db.Authors.Remove(itemToDelete);
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
