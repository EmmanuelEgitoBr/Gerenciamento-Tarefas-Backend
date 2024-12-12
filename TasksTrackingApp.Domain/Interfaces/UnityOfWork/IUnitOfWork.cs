using TasksTrackingApp.Domain.Interfaces.IRepositories;

namespace TasksTrackingApp.Domain.Interfaces.UnityOfWork
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
