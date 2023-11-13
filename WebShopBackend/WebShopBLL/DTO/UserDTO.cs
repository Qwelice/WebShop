namespace WebShopBLL.DTO
{
    using System;

    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<RoleDTO> Roles { get; set; }
        public UserDTO() 
        {
            Roles = new List<RoleDTO>();
        }
    }
}
