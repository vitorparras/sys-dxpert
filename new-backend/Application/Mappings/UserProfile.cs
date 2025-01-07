using Application.DTOs;
using AutoMapper;
using Core.Entities;

namespace Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>(); // Mapeia de entidade User para DTO
            CreateMap<UserDto, User>(); // Opcional: se precisar mapear de volta
        }
    }
}
