using Application.DTOs;
using Core.Entities;

namespace Application.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email.Value,
                Role = user.Role.ToString()
            };
        }
    }
}
