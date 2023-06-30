
using BookLibrary.Dtos;
using BookLibrary.Services.Commands;
using MediatR;

namespace BookLibrary.Services.Commands.BooksCommands.newer
{
    public class AddBookCommand : ICommand, IRequest
    {
        public BookDto Book { get; set; }
    }
}
