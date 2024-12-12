using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Domain.Interfaces.IRepositories;
using TasksTrackingApp.Infrastructure.Persistence;
using TasksTrackingApp.Infrastructure.Repository.Repositories.Base;

namespace TasksTrackingApp.Infrastructure.Repository.Repositories
{
    public class UserRepository(TasksDbContext tasksDbContext) : BaseRepository<User>(tasksDbContext), IUserRepository
    {
        private readonly TasksDbContext _tasksDbContext = tasksDbContext;



    }
}
