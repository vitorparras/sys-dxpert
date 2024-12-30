using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UserService(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var existingUser = await _userRepository.GetByEmailAsync(user.Email.Value);
            if (existingUser != null)
            {
                throw new DomainException("User with this email already exists");
            }

            existingUser = await _userRepository.GetByCPFAsync(user.CPF);
            if (existingUser != null)
            {
                throw new DomainException("User with this CPF already exists");
            }

            return await _userRepository.CreateAsync(user);
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _userRepository.GetByIdAsync(user.Id);
            if (existingUser == null)
            {
                throw new NotFoundException("User not found");
            }

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            await _userRepository.DeleteAsync(user);
        }
    }
}
