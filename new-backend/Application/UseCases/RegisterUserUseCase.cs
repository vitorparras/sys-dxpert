using Application.DTOs;
using Core.Entities;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces;
using Core.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Application.UseCases
{
    public class RegisterUserUseCase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly ILogger<RegisterUserUseCase> _logger;

        public RegisterUserUseCase(IUserService userService, IAuthService authService, ILogger<RegisterUserUseCase> logger)
        {
            _userService = userService;
            _authService = authService;
            _logger = logger;
        }

        public async Task<UserDto> ExecuteAsync(RegisterUserDto request)
        {
            _logger.LogInformation("Attempting to register new user: {Email}", request.Email);

            if (request.Password != request.ConfirmPassword)
            {
                throw new DomainException("Password and confirmation password do not match.");
            }

            var email = Email.Create(request.Email);
            var passwordHash = PasswordHash.Create(_authService.HashPassword(request.Password));

            var user = new User(
                email,
                request.Name,
                request.CPF,
                passwordHash,
                Role.User,
                request.Phone
            );

            try
            {
                var createdUser = await _userService.CreateUserAsync(user);
                _logger.LogInformation("User registered successfully: {Email}", createdUser.Email.Value);

                return new UserDto
                {
                    Id = createdUser.Id,
                    Email = createdUser.Email.Value,
                    Name = createdUser.Name,
                    Phone = createdUser.Phone,
                    CPF = createdUser.CPF,
                    Role = createdUser.Role.ToString()
                };
            }
            catch (DomainException ex)
            {
                _logger.LogWarning(ex, "Failed to register user: {Email}", request.Email);
                throw;
            }
        }
    }
}

