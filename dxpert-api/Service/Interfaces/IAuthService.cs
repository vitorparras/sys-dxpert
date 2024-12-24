using Domain.DTO.Genericos;
using Domain.DTO.Response;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<LoginResponse>> LoginAsync(string email, string senha);

        Task<ApiResponse<bool>> LogoutAsync(string token);

        Task<ApiResponse<bool>> TokenIsValid(string token);
    }
}
