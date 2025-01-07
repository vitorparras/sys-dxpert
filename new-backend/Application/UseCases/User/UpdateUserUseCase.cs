using Application.DTOs;
using Application.DTOs.User;
using AutoMapper;
using Core.Exceptions;
using Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.User
{
    public interface IUpdateUserUseCase
    {
        Task<UserDto> ExecuteAsync(Guid userId, UpdateUserDto request);
    }

    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUserUseCase> _logger;

        public UpdateUserUseCase(
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<UpdateUserUseCase> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDto> ExecuteAsync(Guid userId, UpdateUserDto request)
        {
            _logger.LogInformation("Initiating update for user ID: {UserId}", userId);

            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("User update failed: user not found (ID: {UserId})", userId);
                throw new UserNotFoundException("User not found.");
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                var existingUser = await _userRepository.GetByEmailAsync(request.Email);
                if (existingUser != null && existingUser.Id != userId)
                {
                    _logger.LogWarning("User update failed: email already in use ({Email})", request.Email);
                    throw new ConflictException("The provided email is already in use.");
                }
            }

            user.UpdateInformation(
                request.Name ?? user.Name,
                request.Email ?? user.Email
            );

            await _userRepository.UpdateAsync(user);

            _logger.LogInformation("User successfully updated with ID: {UserId}", userId);

            return _mapper.Map<UserDto>(user);
        }
    }
}
