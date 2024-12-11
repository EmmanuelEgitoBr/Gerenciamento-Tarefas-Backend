using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Infrastructure.Persistence;
using TasksTrackingApp.Infrastructure.Repository.IRepositories;
using TasksTrackingApp.Infrastructure.Repository.UnitOfWork;

namespace TasksTrackingApp.Infrastructure.Repository.Repositories
{
    public class WorkspaceRepository(TasksDbContext context) : BaseRepository<Workspace>(context), IWorkspaceRepository
    {
    }
}
