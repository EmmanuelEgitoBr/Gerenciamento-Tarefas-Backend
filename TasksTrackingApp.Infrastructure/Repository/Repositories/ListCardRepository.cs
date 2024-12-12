using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Domain.Interfaces.IRepositories;
using TasksTrackingApp.Infrastructure.Persistence;
using TasksTrackingApp.Infrastructure.Repository.Repositories.Base;

namespace TasksTrackingApp.Infrastructure.Repository.Repositories
{
    public class ListCardRepository(TasksDbContext tasksDbContext) : BaseRepository<ListCard>(tasksDbContext), IListCardRepository
    {
        private readonly TasksDbContext _tasksDbContext = tasksDbContext;
    }
}
