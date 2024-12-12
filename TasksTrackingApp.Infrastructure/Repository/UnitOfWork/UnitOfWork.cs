using TasksTrackingApp.Domain.Interfaces.IRepositories;
using TasksTrackingApp.Domain.Interfaces.UnityOfWork;
using TasksTrackingApp.Infrastructure.Persistence;
using TasksTrackingApp.Infrastructure.Repository.Repositories;

namespace TasksTrackingApp.Infrastructure.Repository.UnitOfWork
{
    public class UnitOfWork(TasksDbContext context, 
                            IUserRepository userRepository,
                            IWorkspaceRepository workspaceRepository,
                            IListCardRepository listCardRepository,
                            ICardRepository cardRepository) : IUnitOfWork
    {
        private readonly TasksDbContext _context = context;

        public IUserRepository UserRepository => userRepository ?? new UserRepository(context);
        public IWorkspaceRepository WorkspaceRepository => workspaceRepository ?? new WorkspaceRepository(context);
        public IListCardRepository ListCardRepository => listCardRepository ?? new ListCardRepository(context);
        public ICardRepository CardRepository => cardRepository ?? new CardRepository(context);
        
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
