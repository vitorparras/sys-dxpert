using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AuthenticationService
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public async Task<bool> AuthenticateUser(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                return false;

            return _authService.ValidatePassword(password, user.PasswordHash.Value);
        }
    }
}
