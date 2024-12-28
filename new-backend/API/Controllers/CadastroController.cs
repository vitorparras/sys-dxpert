using Domain.DTO.Request;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroService _cadastroService;

        public CadastroController(ICadastroService cadastroService)
        {
            _cadastroService = cadastroService ?? throw new ArgumentNullException(nameof(cadastroService));
        }

        [HttpPut]
        public async Task<IActionResult> AddOrUpdate(Cadastro cadastro)
        {
            try
            {
                var response = await _cadastroService.AddOrUpdate(cadastro);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddDescendentes(DescendentesRequest req)
        {
            try
            {
                var response = await _cadastroService.AddDescendentes(req);
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
                var response = await _cadastroService.List();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
