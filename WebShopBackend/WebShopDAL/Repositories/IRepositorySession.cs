namespace WebShopDAL.Repositories
{
    using System.Threading.Tasks;
    public interface IRepositorySession
    {
        void BeginTransaction();
        void CloseTransaction();
        void Commit();
        Task CommitAsync();
        void Rollback();
        Task RollbackAsync();
    }
}
