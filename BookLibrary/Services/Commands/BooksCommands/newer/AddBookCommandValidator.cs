using FluentValidation;

namespace BookLibrary.Services.Commands.BooksCommands.newer
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator()
        {
            RuleFor(x => x.Book).NotEmpty();
            RuleFor(x => x.Book.Title).NotEmpty();
            RuleFor(x => x.Book.Description).NotEmpty();
            RuleFor(x => x.Book.ImageUrl).NotEmpty();
            RuleFor(x => x.Book.Isbn).NotEmpty();

        }
    }
}
