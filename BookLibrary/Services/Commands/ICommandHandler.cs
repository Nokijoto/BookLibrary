namespace BookLibrary.Services.Commands
{
    public interface ICommandHandler<in TCommand> : ICommand
    {
        Task Handle(TCommand command, CancellationToken cancellationToken);
    }
}
