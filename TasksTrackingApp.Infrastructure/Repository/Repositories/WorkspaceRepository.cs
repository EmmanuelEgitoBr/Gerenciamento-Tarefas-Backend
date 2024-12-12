using Microsoft.EntityFrameworkCore;
using TasksTrackingApp.Domain.Entities;
using TasksTrackingApp.Domain.Interfaces.IRepositories;
using TasksTrackingApp.Infrastructure.Persistence;
using TasksTrackingApp.Infrastructure.Repository.Repositories.Base;

namespace TasksTrackingApp.Infrastructure.Repository.Repositories
{
    public class WorkspaceRepository(TasksDbContext context) : BaseRepository<Workspace>(context), IWorkspaceRepository
    {
        private readonly TasksDbContext _context = context;

        public async Task<List<Workspace>> GetAllWorkspacesByUserIdAsync(Guid userId)
        {
            return await _context.Workspaces.Where(w => w.UserId == userId).ToListAsync();
        }
    }
}
