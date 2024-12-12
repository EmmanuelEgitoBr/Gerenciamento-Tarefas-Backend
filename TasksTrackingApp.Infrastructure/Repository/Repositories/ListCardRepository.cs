using Microsoft.EntityFrameworkCore;
using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Domain.Interfaces.IRepositories;
using TasksTrackingApp.Infrastructure.Persistence;
using TasksTrackingApp.Infrastructure.Repository.Repositories.Base;

namespace TasksTrackingApp.Infrastructure.Repository.Repositories
{
    public class ListCardRepository(TasksDbContext tasksDbContext) : BaseRepository<ListCard>(tasksDbContext), IListCardRepository
    {
        private readonly TasksDbContext _tasksDbContext = tasksDbContext;

        public async Task<List<ListCard>> GetAllCardListByWorkspaceId(Guid workspaceId)
        {
            return await tasksDbContext.CardLists.Where(w => w.WorkspaceId == workspaceId).ToListAsync();
        }
    }
}
