using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.DTOs.User;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailsDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserDetailsDto> GetUserByIdAsync(Guid id);
        Task<IEnumerable<UserDetailsDto>> GetAllUsersAsync();
        Task UpdateUserAsync(Guid id, UpdateUserDto updateUserDto);
        Task DeleteUserAsync(Guid id);
    }
}
