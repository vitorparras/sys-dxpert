using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using Core.Helpers;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginUserUseCase _loginUserUseCase;
        private readonly IRefreshTokenUseCase _refreshTokenUseCase;
        private readonly IRequestPasswordResetUseCase _requestPasswordResetUseCase;
        private readonly IResetPasswordUseCase _resetPasswordUseCase;
        private readonly IChangePasswordUseCase _changePasswordUseCase;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            ILoginUserUseCase loginUserUseCase,
            IRefreshTokenUseCase refreshTokenUseCase,
            IRequestPasswordResetUseCase requestPasswordResetUseCase,
            IResetPasswordUseCase resetPasswordUseCase,
            IChangePasswordUseCase changePasswordUseCase,
            ILogger<AuthController> logger)
        {
            _loginUserUseCase = loginUserUseCase;
            _refreshTokenUseCase = refreshTokenUseCase;
            _requestPasswordResetUseCase = requestPasswordResetUseCase;
            _resetPasswordUseCase = resetPasswordUseCase;
            _changePasswordUseCase = changePasswordUseCase;
            _logger = logger;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "User login", Description = "Authenticates a user using email and password and returns a JWT token.")]
        [SwaggerResponse(200, "Authentication successful", typeof(LoginResponseDto))]
        [SwaggerResponse(400, "Invalid login request.")]
        [SwaggerResponse(401, "Authentication failed.")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
                return ResponseHelper.CreateResponse("Invalid login request.", HttpStatusCode.BadRequest);

            var response = await _loginUserUseCase.ExecuteAsync(request);
            return ResponseHelper.CreateResponse("Authentication successful.", HttpStatusCode.OK, response);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Refresh JWT token", Description = "Generates a new JWT token using a valid refresh token.")]
        [SwaggerResponse(200, "Token refreshed successfully", typeof(LoginResponseDto))]
        [SwaggerResponse(400, "Invalid refresh token request.")]
        [SwaggerResponse(401, "Refresh token is invalid or expired.")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto request)
        {
            if (!ModelState.IsValid)
                return ResponseHelper.CreateResponse("Invalid refresh token request.", HttpStatusCode.BadRequest);

            var response = await _refreshTokenUseCase.ExecuteAsync(request.RefreshToken);
            return ResponseHelper.CreateResponse("Token refreshed successfully.", HttpStatusCode.OK, response);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Request password reset", Description = "Sends a password reset email to the user's registered email address.")]
        [SwaggerResponse(200, "Password reset token requested successfully.")]
        [SwaggerResponse(400, "Invalid password reset request.")]
        [SwaggerResponse(404, "Email not found.")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPasswordResetDto request)
        {
            if (!ModelState.IsValid)
                return ResponseHelper.CreateResponse("Invalid password reset request.", HttpStatusCode.BadRequest);

            await _requestPasswordResetUseCase.ExecuteAsync(request.Email);
            return ResponseHelper.CreateResponse("Password reset request submitted successfully.", HttpStatusCode.OK);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Reset user password", Description = "Resets the user's password using a valid reset token.")]
        [SwaggerResponse(200, "Password reset successfully.")]
        [SwaggerResponse(400, "Invalid reset password request.")]
        [SwaggerResponse(404, "Reset token not found or expired.")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto request)
        {
            if (!ModelState.IsValid)
                return ResponseHelper.CreateResponse("Invalid reset password request.", HttpStatusCode.BadRequest);

            await _resetPasswordUseCase.ExecuteAsync(request);
            return ResponseHelper.CreateResponse("Password reset successfully.", HttpStatusCode.OK);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Change password", Description = "Changes the user's password")]
        [SwaggerResponse(204, "Password changed successfully")]
        [SwaggerResponse(400, "Invalid password change request")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto request)
        {
            if (!ModelState.IsValid)
                return ResponseHelper.CreateResponse("Invalid password change request.", HttpStatusCode.BadRequest);

            await _changePasswordUseCase.ExecuteAsync(request);
            return ResponseHelper.CreateResponse("Password changed successfully.", HttpStatusCode.NoContent);
        }
    }

}
