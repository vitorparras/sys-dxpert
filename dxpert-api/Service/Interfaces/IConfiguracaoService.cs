using Domain.DTO.Genericos;
using Domain.Model;

namespace Service.Interfaces
{
    public interface IConfiguracaoService
    {
        Task<ApiResponse<IEnumerable<Configuracao>>> List();

        Task<ApiResponse<bool>> Update(Configuracao configuracao);
    }
}
