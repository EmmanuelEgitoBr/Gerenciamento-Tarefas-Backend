using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TasksTrackingApp.Infrastructure.Persistence;

namespace TasksTrackingApp.Infrastructure.Repository.UnitOfWork
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly TasksDbContext _tasksDbContext;

        public BaseRepository(TasksDbContext tasksDbContext)
        {
            _tasksDbContext = tasksDbContext;
        }

        public async Task<T> CreateAsync(T commandCreate)
        {
            await _tasksDbContext.Set<T>().AddAsync(commandCreate);
            _tasksDbContext.SaveChanges();
            return commandCreate;
        }

        public Task Delete(T entity)
        {
            _tasksDbContext.Set<T>().Remove(entity);
            _tasksDbContext?.SaveChanges();
            return Task.CompletedTask;
        }

        public Task DeleteById(Guid Id)
        {
            _tasksDbContext.Remove(Id);
            _tasksDbContext?.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task DeleteRange(List<T> range)
        {
            _tasksDbContext.Set<T>().RemoveRange(range);
            await _tasksDbContext.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _tasksDbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _tasksDbContext.Set<T>().ToListAsync();
        }

        public T Update(T commandUpdate)
        {
            _tasksDbContext.Set<T>().Update(commandUpdate);
            _tasksDbContext.SaveChanges();
            return commandUpdate;
        }
    }
}
