using Domain.DTO.Genericos;
using Domain.DTO.Request;
using Domain.Model;

namespace Service.Interfaces
{
    public interface ICadastroService
    {
        Task<ApiResponse<Cadastro>> AddOrUpdate(Cadastro cadastro);

        Task<ApiResponse<IEnumerable<Cadastro>>> List();

        Task<ApiResponse<bool>> AddDescendentes(DescendentesRequest desc);
    }
}
