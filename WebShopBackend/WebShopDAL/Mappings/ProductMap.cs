namespace WebShopDAL.Mappings
{
    using FluentNHibernate.Mapping;
    using WebShopDAL.Entities;

    public class ProductMap : ClassMap<ProductEntity>
    {
        public ProductMap()
        {
            Table("products");
            Id(x => x.Id)
                .GeneratedBy.Guid();
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.Price);
            Map(x => x.PriceFix);
            HasManyToMany(x => x.Categories)
                .Cascade.SaveUpdate()
                .Table("products_categories");
        }
    }
}
