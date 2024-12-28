using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracaoController : ControllerBase
    {
        private readonly IConfiguracaoService _configuracaoService;

        public ConfiguracaoController(IConfiguracaoService configuracaoService)
        {
            _configuracaoService = configuracaoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _configuracaoService.List();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] Configuracao config)
        {
            try
            {
                var response = await _configuracaoService.Update(config);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
