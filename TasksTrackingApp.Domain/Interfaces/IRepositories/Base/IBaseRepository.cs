using System.Linq.Expressions;

namespace TasksTrackingApp.Domain.Interfaces.IRepositories.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T commandCreate);
        T Update(T commandUpdate);
        Task Delete(T entity);
        Task DeleteById(Guid Id);
        Task DeleteRange(List<T> range);
    }
}
