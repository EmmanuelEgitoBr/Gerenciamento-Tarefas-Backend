using Microsoft.EntityFrameworkCore;
using TasksTrackingApp.Domain.Entities;

namespace TasksTrackingApp.Infrastructure.Persistence
{
    public class TasksDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<ListCard> Cards { get; set; }
        public DbSet<Card> Columns { get; set; }
    }
}
