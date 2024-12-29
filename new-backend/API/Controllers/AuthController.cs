using Application.DTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoginUserUseCase _loginUserUseCase;
        private readonly RefreshTokenUseCase _refreshTokenUseCase;
        private readonly RegisterUserUseCase _registerUserUseCase;
        private readonly RequestPasswordResetUseCase _requestPasswordResetUseCase;
        private readonly ResetPasswordUseCase _resetPasswordUseCase;

        public AuthController(
            LoginUserUseCase loginUserUseCase,
            RefreshTokenUseCase refreshTokenUseCase,
            RegisterUserUseCase registerUserUseCase,
            RequestPasswordResetUseCase requestPasswordResetUseCase,
            ResetPasswordUseCase resetPasswordUseCase)
        {
            _loginUserUseCase = loginUserUseCase;
            _refreshTokenUseCase = refreshTokenUseCase;
            _registerUserUseCase = registerUserUseCase;
            _requestPasswordResetUseCase = requestPasswordResetUseCase;
            _resetPasswordUseCase = resetPasswordUseCase;
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token
        /// </summary>
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
        {
            var response = await _loginUserUseCase.ExecuteAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Refreshes an expired JWT token
        /// </summary>
        [HttpPost("refresh-token")]
        public async Task<ActionResult<LoginResponseDto>> RefreshToken([FromBody] RefreshTokenRequestDto request)
        {
            var response = await _refreshTokenUseCase.ExecuteAsync(request.RefreshToken);
            return Ok(response);
        }

        /// <summary>
        /// Registers a new user
        /// </summary>
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterUserDto request)
        {
            var response = await _registerUserUseCase.ExecuteAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Requests a password reset token
        /// </summary>
        [HttpPost("request-password-reset")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPasswordResetDto request)
        {
            await _requestPasswordResetUseCase.ExecuteAsync(request.Email);
            return Ok();
        }

        /// <summary>
        /// Resets the user's password using a reset token
        /// </summary>
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto request)
        {
            await _resetPasswordUseCase.ExecuteAsync(request);
            return Ok();
        }
    }
}
