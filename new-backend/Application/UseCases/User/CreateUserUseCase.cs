using Application.DTOs;
using Application.DTOs.User;
using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Core.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.User
{
    public interface ICreateUserUseCase
    {
        Task<UserDto> ExecuteAsync(CreateUserDto request);
    }

    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserUseCase> _logger;

        public CreateUserUseCase(
            IUserRepository userRepository,
            IAuthService authService,
            IMapper mapper,
            ILogger<CreateUserUseCase> logger)
        {
            _userRepository = userRepository;
            _authService = authService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDto> ExecuteAsync(CreateUserDto request)
        {
            _logger.LogInformation("Initiating user creation process for email: {Email}", request.Email);

            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                _logger.LogWarning("User creation failed: email already exists ({Email}).", request.Email);
                throw new ConflictException("A user with the provided email already exists.");
            }

            if (!_authService.IsPasswordComplexEnough(request.Password))
            {
                _logger.LogWarning("User creation failed: weak password for email ({Email}).", request.Email);
                throw new WeakPasswordException("The provided password does not meet the complexity requirements.");
            }

            var passwordHash = _authService.HashPassword(request.Password);

            var newUser = new User(request.Name, request.Email, PasswordHash.Create(passwordHash));

            await _userRepository.CreateAsync(newUser);

            _logger.LogInformation("User successfully created with ID: {UserId}", newUser.Id);

            return _mapper.Map<UserDto>(newUser);
        }
    }
}
