using SimplyBooks.Domain.QueryModels;
using System.Threading.Tasks;

namespace SimplyBooks.Repository.Queries
{
    public interface IQuery { }

    public interface IQuery<TResult, in TCriteria> : IQuery
    {
        Task<TResult> Execute(TCriteria criteria);
    }

    public interface IQuery<TResult> : IQuery
    {
        Task<TResult> Execute();
    }

    public interface IPagedQuery<TResult, in TCriteria> : IQuery<TResult, TCriteria>
        where TCriteria : PagedCriteria
    {

    }
}
