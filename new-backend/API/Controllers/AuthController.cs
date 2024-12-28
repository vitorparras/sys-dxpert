using Domain.DTO.Request;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            try
            {
                var token = Request.GetJwtFromHeader();
                var response = await _authService.LogoutAsync(token);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao fazer logout: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> TokenIsValid()
        {
            try
            {
                var token = Request.GetJwtFromHeader();
                var response = await _authService.TokenIsValid(token);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao fazer Validar o token: {ex.Message}");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = await _authService.LoginAsync(request.Email, request.Senha);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao fazer Login: {ex.Message}");
            }
        }
    }
}
