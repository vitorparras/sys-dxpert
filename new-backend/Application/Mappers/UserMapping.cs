using Application.DTOs;
using AutoMapper;

namespace Application.Mappers
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
          /*  CreateMap<User, UserDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value));

            CreateMap<User, UserDetailsDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value));

            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => Email.Create(src.Email)))
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => Email.Create(src.Email)))
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Role.User));*/
        }
    }
}
