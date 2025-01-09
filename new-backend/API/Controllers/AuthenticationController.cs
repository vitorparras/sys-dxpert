using Application.Commands.Authentication;
using Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    /// <summary>
    /// Controller responsible for handling user authentication and security management.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IMediator mediator, ILogger<AuthenticationController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Authenticates a user and generates a JWT token for secure system access.
        /// </summary>
        /// <param name="request">User credentials (email and password).</param>
        /// <returns>A JWT token and expiration details.</returns>
        /// <response code="200">Successfully authenticated and token generated.</response>
        /// <response code="400">Invalid request data.</response>
        /// <response code="401">Unauthorized: Invalid email or password.</response>
        [HttpPost("login")]
        [SwaggerOperation(Summary = "User Login", Description = "Authenticates a user and returns a JWT token for secure access.")]
        [SwaggerResponse(200, "Successful authentication", typeof(LoginResponseDto))]
        [SwaggerResponse(400, "Invalid input data.")]
        [SwaggerResponse(401, "Invalid credentials.")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            _logger.LogInformation("Login attempt for user {Email}", request.Email);

            var command = new LoginCommand(request.Email, request.Password);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        /// <summary>
        /// Refreshes the user's JWT token using a valid refresh token.
        /// </summary>
        /// <param name="request">A valid refresh token.</param>
        /// <returns>New JWT token and expiration details.</returns>
        /// <response code="200">Token successfully refreshed.</response>
        /// <response code="400">Invalid token format.</response>
        /// <response code="401">Expired or invalid refresh token.</response>
        [HttpPost("refresh-token")]
        [SwaggerOperation(Summary = "Refresh Token", Description = "Generates a new JWT token using a valid refresh token.")]
        [SwaggerResponse(200, "Token refreshed successfully", typeof(LoginResponseDto))]
        [SwaggerResponse(400, "Invalid refresh token format.")]
        [SwaggerResponse(401, "Refresh token expired or invalid.")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto request)
        {
            var command = new RefreshTokenCommand(request.RefreshToken);
            var response = await _mediator.Send(command);

            return Ok(response);
        }
        
        /// <summary>
        /// Sends an email with a password reset link to the registered email address.
        /// </summary>
        /// <param name="request">The user's registered email.</param>
        /// <returns>A confirmation message indicating the email was sent.</returns>
        /// <response code="200">Password reset email sent successfully.</response>
        /// <response code="404">User with the provided email not found.</response>
        [HttpPost("request-password-reset")]
        [SwaggerOperation(Summary = "Request Password Reset", Description = "Sends a password reset email to the provided email address.")]
        [SwaggerResponse(200, "Password reset email sent successfully.")]
        [SwaggerResponse(404, "Email not found.")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPasswordResetDto request)
        {
            var command = new RequestPasswordResetCommand(request.Email);
            await _mediator.Send(command);

            return Ok("Password reset request submitted successfully.");
        }
        
        /// <summary>
        /// Resets a user's password using a valid token.
        /// </summary>
        /// <param name="request">Token and new password.</param>
        /// <returns>Confirmation of successful password reset.</returns>
        /// <response code="200">Password reset successfully.</response>
        /// <response code="400">Invalid reset token.</response>
        [HttpPost("reset-password")]
        [SwaggerOperation(Summary = "Reset Password", Description = "Resets a user's password using a valid reset token.")]
        [SwaggerResponse(200, "Password reset successfully.")]
        [SwaggerResponse(400, "Invalid token format.")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto request)
        {
            var command = new ResetPasswordCommand(request.Token, request.NewPassword);
            await _mediator.Send(command);

            return Ok("Password has been reset successfully.");
        }

        /// <summary>
        /// Changes the current password for an authenticated user.
        /// </summary>
        /// <param name="request">User's current and new password.</param>
        /// <returns>No content if password changed successfully.</returns>
        /// <response code="204">Password changed successfully.</response>
        /// <response code="400">Invalid password format.</response>
        [HttpPost("change-password")]
        [SwaggerOperation(Summary = "Change Password", Description = "Changes the password of an authenticated user.")]
        [SwaggerResponse(204, "Password changed successfully.")]
        [SwaggerResponse(400, "Invalid password format.")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto request)
        {
            var command = new ChangePasswordCommand(request.UserId, request.CurrentPassword, request.NewPassword);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
