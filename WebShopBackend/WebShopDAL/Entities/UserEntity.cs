namespace WebShopDAL.Entities
{
    public class UserEntity : BaseEntity
    {
        public virtual string Email { get; set; }
        public virtual string Username { get; set; }
        public virtual byte[] PasswordHash { get; set; }
        public virtual byte[] PasswordSalt { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set;}
        public virtual IList<RoleEntity> Roles { get; set; }
        public virtual string RefreshToken { get; set; }
        public UserEntity() 
        {
            Roles = new List<RoleEntity>();
        }
    }
}
