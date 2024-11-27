using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Infrastructure.Repository.UnitOfWork;

namespace TasksTrackingApp.Infrastructure.Repository.IRepositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
