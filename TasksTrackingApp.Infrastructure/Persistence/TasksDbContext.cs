using Microsoft.EntityFrameworkCore;
using TasksTrackingApp.Domain.Entities;

namespace TasksTrackingApp.Infrastructure.Persistence
{
    public class TasksDbContext(DbContextOptions<TasksDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Workspace> Workspaces { get; set; }
        public DbSet<ListCard> Cards { get; set; }
        public DbSet<Card> Columns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TasksDbContext).Assembly);
        }
    }
}
