using Domain.DTO.Genericos;
using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Model;

namespace Service.Interfaces
{
    public interface IUsuarioService
    {
        Task<ApiResponse<Usuario>> GetByEmailAsync(string email);
        Task<ApiResponse<UsuarioResponse>> GetByIdAsync(int id);
        Task<ApiResponse<IEnumerable<UsuarioResponse>>> ListAsync();
        Task<ApiResponse<UsuarioResponse>> AddAsync(UsuarioRequest usuario);
        Task<ApiResponse<UsuarioResponse>> UpdateAsync(UsuarioRequest usuario);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}
