namespace WebShopDAL.Entities
{
    using WebShopDAL.Enums;

    public class RoleEntity : BaseEntity
    {
        public virtual RoleTypes RoleType { get; set; }
        public virtual IList<UserEntity> Users { get; set; }
        public RoleEntity() 
        {
            Users = new List<UserEntity>();
        }
    }
}
