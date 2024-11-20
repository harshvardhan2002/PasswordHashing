using AutoMapper;
using PasswordHashing.DTOs;
using PasswordHashing.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PasswordHashing.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>();//maps UserDTO to User model for adding a user
        }
    }
}
