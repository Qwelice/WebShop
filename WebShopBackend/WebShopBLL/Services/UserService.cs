namespace WebShopBLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using WebShopBLL.DTO;
    using WebShopBLL.Services.Interfaces;
    using WebShopDAL.Entities;
    using WebShopDAL.Enums;
    using WebShopDAL.Infrastructure;

    public class UserService : IUserService
    {
        private UnitOfWork _unitOfWork;

        public UserService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool Authenticate(UserDTO userDTO)
        {
            var user = _unitOfWork.Users.Find(entity => entity.Email == userDTO.Email).FirstOrDefault();
            if (user == null)
            {
                return false;
            }
            if (!VerifyPasswordHash(userDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                return false;
            }

            return true;
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var result = await _unitOfWork.Users.FindAsync(e => e.Email == email);
            var entity = result.FirstOrDefault();
            if (entity == null)
            {
                return new UserDTO { Email = email };
            }
            else
            {
                var user = new UserDTO
                {
                    Id = entity.Id,
                    Email = entity.Email,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Username = entity.Username,
                    RefreshToken = entity.RefreshToken,
                    RefreshTokenExpiryTime = entity.RefreshTokenExpiryTime
                };

                foreach(var role in  entity.Roles)
                {
                    user.Roles.Add(new RoleDTO(role.RoleType));
                }

                return user;
            }
        }

        public async Task<UserDTO?> GetUserByRefreshTokenAsync(string refreshToken)
        {
            var result = await _unitOfWork.Users.FindAsync(e => e.RefreshToken == refreshToken);
            var entity = result.FirstOrDefault();
            if(entity == null)
            {
                return null;
            }
            else
            {
                var user = new UserDTO()
                {
                    Id = entity.Id,
                    Email = entity.Email,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Username = entity.Username,
                    RefreshToken = entity.RefreshToken,
                    RefreshTokenExpiryTime = entity.RefreshTokenExpiryTime
                };

                foreach(var role in entity.Roles)
                {
                    user.Roles.Add(new RoleDTO(role.RoleType));
                }

                return user;
            }
        }

        public async Task<IList<RoleDTO>> GetUserRolesAsync(UserDTO userDTO)
        {
            var result = new List<RoleDTO>();
            if (userDTO.Id != Guid.Empty)
            {
                var entity = await _unitOfWork.Users.GetAsync(userDTO.Id);
                if(entity != null)
                {
                    foreach (var role in entity.Roles)
                    {
                        var roleDto = new RoleDTO(role.RoleType);
                        result.Add(roleDto);
                    }
                }
            }
            else
            {
                var resultSet = await _unitOfWork.Users.FindAsync(entity => entity.Email == userDTO.Email);
                var entity = resultSet.FirstOrDefault();
                if(entity != null)
                {
                    foreach (var role in entity.Roles)
                    {
                        var roleDto = new RoleDTO(role.RoleType);
                        result.Add(roleDto);
                    }
                }
            }
            return result;
        }

        public bool IsExists(UserDTO userDTO)
        {
            var user = _unitOfWork.Users.Find(entity => entity.Email == userDTO.Email).FirstOrDefault();
            return user != null;
        }

        public async Task SaveUserAsync(UserDTO userDTO)
        {
            var newUser = new { Email = userDTO.Email, Password = userDTO.Password };

            if (_unitOfWork.Users.Find(entity => entity.Email == newUser.Email).Any())
            {
                throw new ApplicationException("Пользователь с такой почтой уже существует");
            }

            byte[] passwordHash, passwordSalt;
            GeneratePasswordHash(newUser.Password, out passwordHash, out passwordSalt);

            if(!_unitOfWork.Roles.Find(role => role.RoleType == RoleTypes.User).Any())
            {
                await _unitOfWork.Roles.SaveAsync(new RoleEntity { RoleType = RoleTypes.User });
            }
            if (!_unitOfWork.Roles.Find(role => role.RoleType == RoleTypes.Admin).Any())
            {
                await _unitOfWork.Roles.SaveAsync(new RoleEntity { RoleType = RoleTypes.Admin });
            }

            var userRole = (await _unitOfWork.Roles.FindAsync(entity => entity.RoleType == RoleTypes.User)).First();
            var adminRole = (await _unitOfWork.Roles.FindAsync(entity => entity.RoleType == RoleTypes.Admin)).First();

            var newEntity = new UserEntity();
            newEntity.Email = userDTO.Email;
            newEntity.PasswordHash = passwordHash;
            newEntity.PasswordSalt = passwordSalt;
            newEntity.RefreshToken = userDTO.RefreshToken;
            newEntity.RefreshTokenExpiryTime = userDTO.RefreshTokenExpiryTime;
            newEntity.Roles.Add(userRole);
            if(userDTO.Email == "kamilzalyalov00@gmail.com")
            {
                newEntity.Roles.Add(adminRole);
            }
            await _unitOfWork.Users.SaveAsync(newEntity);
        }

        public async Task UpdateUserAsync(UserDTO userDTO)
        {
            var entity = await _unitOfWork.Users.GetAsync(userDTO.Id);
            entity.Email = userDTO.Email;
            entity.FirstName = userDTO.FirstName;
            entity.LastName = userDTO.LastName;
            entity.Username = userDTO.Username;
            entity.RefreshToken = userDTO.RefreshToken;
            entity.RefreshTokenExpiryTime = userDTO.RefreshTokenExpiryTime;
            entity.Roles.Clear();
            var roles = await _unitOfWork.Roles.FindAsync(re => userDTO.Roles.Select(t => t.Role).Contains(re.RoleType));
            foreach(var role in roles)
            {
                entity.Roles.Add(role);
            }
            await _unitOfWork.Users.UpdateAsync(entity);
        }

        private void GeneratePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (passwordHash.Length != 64) throw new ArgumentException("Некорректная длина хэша пароля (ожидалось 64)", "passwordHash");
            if (passwordSalt.Length != 128) throw new ArgumentException("Некорректная длина соли пароля (ожидалось 128)", "passwordSalt");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
