namespace WebShopDAL.Mappings
{
    using FluentNHibernate.Mapping;
    using WebShopDAL.Entities;

    public class CategoryMap : ClassMap<CategoryEntity>
    {
        public CategoryMap()
        {
            Table("categories");
            Id(x => x.Id)
                .GeneratedBy.Guid();
            Map(x => x.Name);
            HasManyToMany(x => x.Products)
                .Inverse().Cascade.All()
                .Table("products_categories");
        }
    }
}
