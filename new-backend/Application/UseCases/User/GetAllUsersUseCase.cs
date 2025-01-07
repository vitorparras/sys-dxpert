using Application.DTOs;
using Core.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.User
{
    public interface IGetAllUsersUseCase
    {
        Task<List<UserDto>> ExecuteAsync(UserFilterDto filters);
    }

    public class GetAllUsersUseCase : IGetAllUsersUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllUsersUseCase> _logger;

        public GetAllUsersUseCase(
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<GetAllUsersUseCase> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<UserDto>> ExecuteAsync(UserFilterDto filters)
        {
            _logger.LogInformation("Fetching all users with filters applied.");

            var users = await _userRepository.GetAllAsync(filters);
            if (users == null || !users.Any())
            {
                _logger.LogWarning("No users found for the provided filters.");
                return new List<UserDto>();
            }

            _logger.LogInformation($@"{users.Count} users found for the provided filters.");

            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
