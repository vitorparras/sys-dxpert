using Domain.Model;

namespace Service.Interfaces
{
    public interface IRelatorioService
    {
        Task<Relatorio> GetRelatorio(int idCadastro);
    }
}
