﻿using BookLibrary.Data;
using BookLibrary.Dtos;
using BookLibrary.Models.PageModels;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Services.Commands.BookShelvesCommands
{
    public class BindBookToShelf
    {
        public class Command : IRequest
        {
            public BookShelfDto BookShelf { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(command => command.BookShelf).NotNull().WithMessage("BookShelf cannot be null");
                RuleFor(command => command.BookShelf.Book.BookUuid).NotEmpty().WithMessage("BookUuid  is required");
                RuleFor(command => command.BookShelf.Shelf.ShelfUuid).NotEmpty().WithMessage("ShelfUuid  is required");
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
                    if (request.BookShelf.Shelf.ShelfUuid.Equals(null) || request.BookShelf.Book.BookUuid.Equals(null))
                    {
                        throw new Exception("Shelf or Book not found");
                    }

                    var shelf = await _db.Shelfs.FirstOrDefaultAsync(a => a.ShelfUuid.Equals(request.BookShelf.Shelf.ShelfUuid), cancellationToken);
                    var book = await _db.Books.FirstOrDefaultAsync(a => a.BookUuid.Equals(request.BookShelf.Book.BookUuid), cancellationToken);

                    if (shelf.Equals(null) || book.Equals(null))
                    {
                        throw new Exception("Shelf or Book not found");
                    }

                    var newBookShelf = new BookShelfs()
                    {
                        BookId = book.BookId,
                        ShelfId = shelf.ShelfId
                    };

                    _db.BookShelfs.Add(newBookShelf);

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
