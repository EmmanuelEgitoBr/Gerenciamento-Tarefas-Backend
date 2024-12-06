using TasksTrackingApp.Infrastructure.Repository.IRepositories;

namespace TasksTrackingApp.Infrastructure.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        public void Commit();
    }
}
