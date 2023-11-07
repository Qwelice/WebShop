namespace WebShopDAL.Mappings
{
    using FluentNHibernate.Mapping;
    using WebShopDAL.Entities;

    public class RoleMap : ClassMap<RoleEntity>
    {
        public RoleMap()
        {
            Table("roles");
            Id(x => x.Id)
                .GeneratedBy.Guid();
            Map(x => x.RoleType).Not.Nullable();
            HasManyToMany(x => x.Users)
                .Inverse().Cascade.All()
                .Table("users_roles");
        }
    }
}
