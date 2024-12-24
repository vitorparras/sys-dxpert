using Domain.DTO.Genericos;
using Domain.DTO.Request;
using Domain.Model;
using Infrastructure.Repository.Interface;
using Service.Interfaces;

namespace Service
{
    public class CadastroService : ICadastroService
    {
        private readonly IGenericRepository<Cadastro> _CadastroRepository;

        public CadastroService(IGenericRepository<Cadastro> cadastroRepository)
        {
            _CadastroRepository = cadastroRepository ?? throw new ArgumentNullException(nameof(cadastroRepository));
        }

        public async Task<ApiResponse<Cadastro>> AddOrUpdate(Cadastro cadastro)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(cadastro);

                if (cadastro.Id != 0)
                {
                    var registroAlterado = await Update(cadastro);
                    return registroAlterado != null ?
                        new ApiResponse<Cadastro>(true, "Usuario Alterado Com Sucesso!", cadastro) :
                        new ApiResponse<Cadastro>(false, "Usuario Não Alterado!", cadastro);
                }
                else
                {
                    var registroAdicionado = await Add(cadastro);
                    return registroAdicionado != null ?
                      new ApiResponse<Cadastro>(true, "Usuario Adicionado Com Sucesso!", cadastro) :
                      new ApiResponse<Cadastro>(false, "Usuario Não Adicionado!", cadastro);
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<Cadastro>(false, ex.Message, default);
            }
        }

        public async Task<Cadastro> Update(Cadastro cadastro)
        {
            var cadastroexistente = await _CadastroRepository.FirstOrDefaultAsync(x => x.Id == cadastro.Id) ?? throw new ArgumentNullException();

            var alterado = _CadastroRepository.AtualizarPropriedades(cadastroexistente, cadastro);

            var registroSalvo = await _CadastroRepository.UpdateAsync(alterado);

            return registroSalvo;
        }

        public async Task<Cadastro> Add(Cadastro cadastro)
        {
            return await _CadastroRepository.AddAsync(cadastro);
        }

        public async Task<ApiResponse<IEnumerable<Cadastro>>> List() =>
            new ApiResponse<IEnumerable<Cadastro>>(false, "Itens Listados Com Sucesso!", await _CadastroRepository.GetAllAsync());

        public async Task<ApiResponse<bool>> AddDescendentes(DescendentesRequest desc) =>
            new ApiResponse<bool>(false, "Decendente Adicionado Com Sucesso!", true);
    }
}
