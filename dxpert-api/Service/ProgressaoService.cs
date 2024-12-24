using Domain.DTO.Genericos;
using Domain.DTO.Response;
using Domain.Model;
using Infrastructure.Repository.Interface;
using Service.Interfaces;

namespace Service
{
    public class ProgressaoService : IProgressaoService
    {
        private readonly IGenericRepository<Cadastro> _CadastroRepository;
        private readonly IGenericRepository<Usuario> _usuarioRepository;
        public ProgressaoService(IGenericRepository<Cadastro> cadastroRepository, IGenericRepository<Usuario> usuarioRepository)
        {
            _CadastroRepository = cadastroRepository ?? throw new ArgumentNullException(nameof(cadastroRepository));
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }

        public async Task<ApiResponse<IEnumerable<ProgressaoResponse>>> List(int idUser)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(idUser);

                var cads = (idUser != null) ?
                    await _CadastroRepository.FindAsync(x => x.IdUsuarioResponsavel == idUser) :
                    await _CadastroRepository.GetAllAsync();

                var response = cads.Select(x => new ProgressaoResponse()
                {
                    CadastroEmail = x.Email,
                    CadastroEtapa = x.Etapa,
                    CadastroId = x.Id.ToString(),
                    CadastroTelefone = x.Celular,
                    UserResponsavel = GetNomeUsuarioResponsavel(x.IdUsuarioResponsavel).Result,
                });

                return new ApiResponse<IEnumerable<ProgressaoResponse>>(true, "Progressoes Obtidas Com Sucesso!", response);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<ProgressaoResponse>>(false, ex.Message, default);
            }
        }

        private async Task<string> GetNomeUsuarioResponsavel(int idUser)
        {
            var user = await _usuarioRepository.FirstOrDefaultAsync(x => x.Id == idUser);
            return user.Nome;
        }
    }
}
