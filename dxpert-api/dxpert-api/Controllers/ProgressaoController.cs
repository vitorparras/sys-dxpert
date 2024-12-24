using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProgressaoController : ControllerBase
    {
        private readonly IProgressaoService _progressaoService;

        public ProgressaoController(IProgressaoService progressaoService)
        {
            _progressaoService = progressaoService;
        }

        [HttpGet]
        public async Task<IActionResult> Acompanhamentos(int idUser)
        {
            try
            {
                var response = await _progressaoService.List(idUser);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}
