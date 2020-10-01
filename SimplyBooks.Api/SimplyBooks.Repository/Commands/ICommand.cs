using SimplyBooks.Domain.QueryModels;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Commands
{
    public interface ICommand { }

    public interface ICommand<in TCommand> : ICommand
        where TCommand : class
    {
        Task<Result> Execute(TCommand command);
    }

    public interface ICommand<in TCommand, TValue> : ICommand
        where TCommand : class
    {
        Task<Result<TValue>> Execute(TCommand command);
    }
}
