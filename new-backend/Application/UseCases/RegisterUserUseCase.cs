using Application.DTOs;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Core.ValueObjects;

namespace Application.UseCases
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public RegisterUserUseCase(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<UserDto> ExecuteAsync(RegisterUserDto request)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User with this email already exists");
            }

            var passwordHash = _authService.HashPassword(request.Password);
            var user = new User(Email.Create(request.Email), Core.ValueObjects.PasswordHash.Create(passwordHash) , Role.User);

            await _userRepository.CreateAsync(user);

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email.Value,
                Role = user.Role.ToString()
            };
        }
    }
}

