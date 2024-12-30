using Application.DTOs;
using Application.UseCases;
using Application.UseCases.Login;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoginUserUseCase _loginUserUseCase;
        private readonly RefreshTokenUseCase _refreshTokenUseCase;
        private readonly RequestPasswordResetUseCase _requestPasswordResetUseCase;
        private readonly ResetPasswordUseCase _resetPasswordUseCase;
        public AuthController(
            LoginUserUseCase loginUserUseCase,
            RefreshTokenUseCase refreshTokenUseCase,
            RequestPasswordResetUseCase requestPasswordResetUseCase,
            ResetPasswordUseCase resetPasswordUseCase)
        {
            _loginUserUseCase = loginUserUseCase;
            _refreshTokenUseCase = refreshTokenUseCase;
            _requestPasswordResetUseCase = requestPasswordResetUseCase;
            _resetPasswordUseCase = resetPasswordUseCase;
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token.
        /// </summary>
        [HttpPost("login")]
        [SwaggerOperation(Summary = "User login", Description = "Authenticates a user using email and password and returns a JWT token.")]
        [SwaggerResponse(200, "Authentication successful", typeof(LoginResponseDto))]
        [SwaggerResponse(400, "Invalid login request.")]
        [SwaggerResponse(401, "Authentication failed.")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _loginUserUseCase.ExecuteAsync(request);

            return Ok(new
            {
                Message = "Authentication successful.",
                Data = response
            });
        }

        /// <summary>
        /// Refreshes an expired JWT token.
        /// </summary>
        [HttpPost("refresh-token")]
        [SwaggerOperation(Summary = "Refresh JWT token", Description = "Generates a new JWT token using a valid refresh token.")]
        [SwaggerResponse(200, "Token refreshed successfully", typeof(LoginResponseDto))]
        [SwaggerResponse(400, "Invalid refresh token request.")]
        [SwaggerResponse(401, "Refresh token is invalid or expired.")]
        public async Task<ActionResult<LoginResponseDto>> RefreshToken([FromBody] RefreshTokenRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _refreshTokenUseCase.ExecuteAsync(request.RefreshToken);

            return Ok(new
            {
                Message = "Token refreshed successfully.",
                Data = response
            });
        }

        /// <summary>
        /// Requests a password reset token.
        /// </summary>
        [HttpPost("request-password-reset")]
        [SwaggerOperation(Summary = "Request password reset", Description = "Sends a password reset email to the user's registered email address.")]
        [SwaggerResponse(200, "Password reset token requested successfully.")]
        [SwaggerResponse(400, "Invalid password reset request.")]
        [SwaggerResponse(404, "Email not found.")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPasswordResetDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _requestPasswordResetUseCase.ExecuteAsync(request.Email);

            return Ok(new { Message = "Password reset request submitted successfully." });
        }

        /// <summary>
        /// Resets the user's password using a reset token.
        /// </summary>
        [HttpPost("reset-password")]
        [SwaggerOperation(Summary = "Reset user password", Description = "Resets the user's password using a valid reset token.")]
        [SwaggerResponse(200, "Password reset successfully.")]
        [SwaggerResponse(400, "Invalid reset password request.")]
        [SwaggerResponse(404, "Reset token not found or expired.")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _resetPasswordUseCase.ExecuteAsync(request);

            return Ok(new { Message = "Password reset successfully." });
        }
    }
}
