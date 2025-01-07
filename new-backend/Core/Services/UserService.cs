using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IAuthService authService, IMapper mapper)
        {
            _userRepository = userRepository;
            _authService = authService;
            _mapper = mapper;
        }

        public async Task<UserDetailsDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(createUserDto.Email);
            if (existingUser != null)
            {
                throw new DomainException("User with this email already exists");
            }

            existingUser = await _userRepository.GetByCPFAsync(createUserDto.CPF);
            if (existingUser != null)
            {
                throw new DomainException("User with this CPF already exists");
            }

            var user = _mapper.Map<User>(createUserDto);
            user.PasswordHash = Core.ValueObjects.PasswordHash.Create(_authService.HashPassword(createUserDto.Password));

            var createdUser = await _userRepository.CreateAsync(user);
            return _mapper.Map<UserDetailsDto>(createdUser);
        }

        public async Task<UserDetailsDto> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            return _mapper.Map<UserDetailsDto>(user);
        }

        public async Task<IEnumerable<UserDetailsDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDetailsDto>>(users);
        }

        public async Task UpdateUserAsync(Guid id, UpdateUserDto updateUserDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }

            _mapper.Map(updateUserDto, user);
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
