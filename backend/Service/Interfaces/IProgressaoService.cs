using Domain.DTO.Genericos;
using Domain.DTO.Response;

namespace Service.Interfaces
{
    public interface IProgressaoService
    {
        Task<ApiResponse<IEnumerable<ProgressaoResponse>>> List(int idUser);
    }
}
