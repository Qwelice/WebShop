namespace WebShopBLL.Services.Interfaces
{
    using System.Threading.Tasks;
    using WebShopBLL.DTO;

    public interface IUserService
    {
        public Task SaveUserAsync (UserDTO userDTO);
        public Task<UserDTO> GetUserByEmailAsync(string email);
        public Task<UserDTO?> GetUserByRefreshTokenAsync(string refreshToken);
        public Task UpdateUserAsync(UserDTO userDTO);
        public bool Authenticate(UserDTO userDTO);
        public bool IsExists(UserDTO userDTO);
    }
}
