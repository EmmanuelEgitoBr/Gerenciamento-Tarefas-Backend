using TasksTrackingApp.Infrastructure.Repository.IRepositories;

namespace TasksTrackingApp.Infrastructure.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IWorkspaceRepository WorkspaceRepository { get; }
        public void Commit();
    }
}
