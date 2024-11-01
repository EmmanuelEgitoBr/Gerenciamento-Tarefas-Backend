using System.Linq.Expressions;

namespace TasksTrackingApp.Infrastructure.Repository.UnitOfWork
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T commandCreate);
        T Update(T commandUpdate);
        Task Delete(Guid id);
    }
}
