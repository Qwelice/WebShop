namespace WebShopDAL.Repositories
{
    using NHibernate;
    using WebShopDAL.Entities;

    public class OrderRepository : BaseRepository<OrderEntity>
    {
        public OrderRepository(ISession session) : base(session)
        {
        }
    }
}
