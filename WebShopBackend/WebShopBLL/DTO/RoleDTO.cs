namespace WebShopBLL.DTO
{
    using WebShopDAL.Enums;

    public class RoleDTO
    {
        public RoleTypes Role { get; set; }
        public string Name { get; set; }

        public RoleDTO(RoleTypes role) 
        {
            Role = role;
            switch (Role)
            {
                case RoleTypes.User:
                    Name = "user";
                    break;
                case RoleTypes.Admin:
                    Name = "admin";
                    break;
                default:
                    Name = "user";
                    break;
            }
        }
    }
}
