using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Domain.Interfaces.IRepositories.Base;

namespace TasksTrackingApp.Domain.Interfaces.IRepositories
{
    public interface IWorkspaceRepository : IBaseRepository<Workspace>
    {
        Task<List<Workspace>> GetAllWorkspacesByUserIdAsync(Guid userId);
    }
}
