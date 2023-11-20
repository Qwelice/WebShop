namespace WebShopDAL.Mappings
{
    using FluentNHibernate.Mapping;
    using WebShopDAL.Entities;

    public class OrderMap : ClassMap<OrderEntity>
    {
        public OrderMap()
        {
            Table("orders");
            Id(x => x.Id)
                .GeneratedBy.Guid();
            Map(x => x.IsClosed);
            Map(x => x.ClosedDate);
            References(x => x.Owner);
            HasManyToMany(x => x.Products)
                .Inverse()
                .Cascade.All()
                .Table("orders_products");
        }
    }
}
