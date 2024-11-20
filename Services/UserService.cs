using AutoMapper;
using PasswordHashing.DTOs;
using PasswordHashing.Exceptions;
using PasswordHashing.Models;
using PasswordHashing.Repositories;

namespace PasswordHashing.Services
{
    public class UserService:IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int Add(UserDTO userDto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(userDto.Password);

            User user = _mapper.Map<User>(userDto);
            user.PasswordHash = hashedPassword;

            _repository.Add(user);

            return user.Id;
        }

        public bool CheckPassword(LoginDTO loginDto)
        {
            var user = _repository.GetAll().FirstOrDefault(u => u.UserName == loginDto.UserName);
            if (user == null)
                throw new UserNotFoundException("Invalid credentials");
            

            return BCrypt.Net.BCrypt.EnhancedVerify(loginDto.Password, user.PasswordHash);
        }
    }
}
