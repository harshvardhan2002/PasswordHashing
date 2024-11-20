using PasswordHashing.DTOs;

namespace PasswordHashing.Services
{
    public interface IUserService
    {
        bool CheckPassword(LoginDTO loginDto);
        int Add(UserDTO userDto);
    }
}
