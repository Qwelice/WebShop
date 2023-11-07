namespace WebShopBLL.Services.Interfaces
{
    using System.Threading.Tasks;
    using WebShopBLL.DTO;

    public interface IUserService
    {
        public Task SaveUserAsync (UserDTO userDTO);
        public Task<UserDTO> GetUserByEmailAsync(string email);
    }
}
