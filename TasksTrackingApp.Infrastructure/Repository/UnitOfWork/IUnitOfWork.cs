using TasksTrackingApp.Infrastructure.Repository.IRepositories;

namespace TasksTrackingApp.Infrastructure.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IWorkspaceRepository WorkspaceRepository { get; }
        IListCardRepository ListCardRepository { get; }
        ICardRepository CardRepository { get; }
        public void Commit();
    }
}
