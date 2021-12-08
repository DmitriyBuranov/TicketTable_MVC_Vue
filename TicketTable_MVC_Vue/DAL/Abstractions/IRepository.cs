

using System.Linq.Expressions;

namespace TicketTable_MVC_Vue.Dal.Abstractions
{
    public interface IRepository<T> 
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task RemoveAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);

    }
}
