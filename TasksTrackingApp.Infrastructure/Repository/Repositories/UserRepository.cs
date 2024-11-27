using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Infrastructure.Persistence;
using TasksTrackingApp.Infrastructure.Repository.IRepositories;
using TasksTrackingApp.Infrastructure.Repository.UnitOfWork;

namespace TasksTrackingApp.Infrastructure.Repository.Repositories
{
    public class UserRepository(TasksDbContext tasksDbContext) : BaseRepository<User>(tasksDbContext), IUserRepository
    {
        private readonly TasksDbContext _tasksDbContext = tasksDbContext;



    }
}
