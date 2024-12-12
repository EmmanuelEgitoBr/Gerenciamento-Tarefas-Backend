using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Domain.Interfaces.IRepositories.Base;

namespace TasksTrackingApp.Domain.Interfaces.IRepositories
{
    public interface IListCardRepository : IBaseRepository<ListCard>
    {
        Task<List<ListCard>> GetAllCardListByWorkspaceId(Guid workspaceId);
    }
}
