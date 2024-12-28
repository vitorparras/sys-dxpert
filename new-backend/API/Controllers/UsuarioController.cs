using Domain.DTO.Request;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(UsuarioRequest usuario)
        {
            try
            {
                var response = await _usuarioService.AddAsync(usuario);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit(UsuarioRequest usuario)
        {
            try
            {
                var response = await _usuarioService.UpdateAsync(usuario);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _usuarioService.DeleteAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var response = await _usuarioService.GetByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> FindByEmail(string email)
        {
            try
            {
                var response = await _usuarioService.GetByEmailAsync(email);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var response = await _usuarioService.ListAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
