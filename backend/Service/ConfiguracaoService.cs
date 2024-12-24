using Domain.DTO.Genericos;
using Domain.Model;
using Infrastructure.Repository.Interface;
using Service.Interfaces;

namespace Service
{
    public class ConfiguracaoService : IConfiguracaoService
    {
        private readonly IGenericRepository<Configuracao> _ConfigRepository;

        public ConfiguracaoService(IGenericRepository<Configuracao> configRepository)
        {
            _ConfigRepository = configRepository ?? throw new ArgumentNullException(nameof(configRepository));
        }

        public async Task<ApiResponse<IEnumerable<Configuracao>>> List() =>
           new ApiResponse<IEnumerable<Configuracao>>(false, "Itens Listados Com Sucesso!", await _ConfigRepository.GetAllAsync());


        public async Task<ApiResponse<bool>> Update(Configuracao config)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(config);

                var configuracao = await _ConfigRepository.FirstOrDefaultAsync(x => x.Id == config.Id);

                if (configuracao.Id != 0)
                {
                    configuracao.Valor = config.Valor;
                    configuracao.Nome = config.Nome;
                    await _ConfigRepository.UpdateAsync(configuracao);

                    return new ApiResponse<bool>(true, "Configuracao Alterado Com Sucesso!", true);
                }
                return new ApiResponse<bool>(false, "Configuracao Não Alterada!", false);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>(false, ex.Message, false);
            }
        }
    }
}
