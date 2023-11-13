namespace WebShopDAL.Mappings
{
    using FluentNHibernate.Mapping;
    using WebShopDAL.Entities;

    public class UserMap : ClassMap<UserEntity>
    {
        public UserMap() 
        {
            Table("users");
            Id(x => x.Id)
                .GeneratedBy.Guid();
            Map(x => x.Email).Not.Nullable();
            Map(x => x.Username).Nullable();
            Map(x => x.PasswordHash).Not.Nullable();
            Map(x => x.PasswordSalt).Not.Nullable();
            Map(x => x.FirstName).Nullable();
            Map(x => x.LastName).Nullable();
            Map(x => x.RefreshToken).Not.Nullable();
            Map(x => x.RefreshTokenExpiryTime).Not.Nullable();
            HasManyToMany(x => x.Roles)
                .Cascade.SaveUpdate()
                .Table("users_roles");
        }
    }
}
