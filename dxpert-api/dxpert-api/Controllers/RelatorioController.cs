using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatorioController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService ?? throw new ArgumentNullException(nameof(relatorioService));
        }

        [HttpGet]
        public async Task<IActionResult> GetRelatorio(int cadastro)
        {
            var data = await _relatorioService.GetRelatorio(cadastro);
            return Ok(data);
        }
    }
}
