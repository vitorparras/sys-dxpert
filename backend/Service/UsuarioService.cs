using Domain.DTO.Genericos;
using Domain.DTO.Request;
using Domain.DTO.Response;
using Domain.Model;
using Infrastructure.Repository.Interface;
using Microsoft.Extensions.Configuration;
using Service.Interfaces;

namespace Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _usuarioRepository;
        private readonly IConfiguration _configuration;

        public UsuarioService(
            IGenericRepository<Usuario> usuarioRepository,
            IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<ApiResponse<Usuario>> GetByEmailAsync(string email)
        {
            try
            {
                var response = await _usuarioRepository.FirstOrDefaultAsync(x => x.Email.Contains(email));

                return new ApiResponse<Usuario>(true, "Registro Obtido Com Sucesso!", response);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Usuario>(false, ex.Message, default);
            }
        }

        public async Task<ApiResponse<UsuarioResponse>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _usuarioRepository.GetByIdAsync(id);

                var response = new UsuarioResponse()
                {
                    Email = result.Email,
                    Id = result.Id,
                    Nome = result.Nome,
                    Permissao = result.Permissao,
                    Telefone = result.Telefone
                };

                return result != null ?
                    new ApiResponse<UsuarioResponse>(true, "Registros Obtidos Com Sucesso!", response) :
                    new ApiResponse<UsuarioResponse>(false, "Registros Não Foram Obtido!", default);
            }
            catch (Exception ex)
            {
                return new ApiResponse<UsuarioResponse>(false, ex.Message, default);
            }
        }

        public async Task<ApiResponse<IEnumerable<UsuarioResponse>>> ListAsync()
        {
            try
            {
                var result = await _usuarioRepository.GetAllAsync();

                var response = result.Select(x => new UsuarioResponse()
                {
                    Email = x.Email,
                    Id = x.Id,
                    Nome = x.Nome,
                    Permissao = x.Permissao,
                    Telefone = x.Telefone
                }).ToList();

                return result != null ?
                    new ApiResponse<IEnumerable<UsuarioResponse>>(true, "Registros Obtidos Com Sucesso!", response) :
                    new ApiResponse<IEnumerable<UsuarioResponse>>(false, "Registros Não Foram Obtido!", default);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IEnumerable<UsuarioResponse>>(false, ex.Message, default);
            }
        }

        public async Task<ApiResponse<UsuarioResponse>> AddAsync(UsuarioRequest usuario)
        {
            try
            {
                var user = await _usuarioRepository.AddAsync(new Usuario()
                {
                    Telefone = usuario.Telefone,
                    Permissao = usuario.Permissao,
                    Nome = usuario.Nome,
                    Senha = usuario.Senha,
                    Email = usuario.Email,
                });

                return user != null ?
                    new ApiResponse<UsuarioResponse>(true, "Registro Adicionado Com Sucesso!", new UsuarioResponse()
                    {
                        Email = user.Email,
                        Id = user.Id,
                        Nome = user.Nome,
                        Permissao = user.Permissao,
                        Telefone = user.Telefone
                    }) :
                    new ApiResponse<UsuarioResponse>(false, "Registro Não Foi Adicionado!", default);
            }
            catch (Exception ex)
            {
                return new ApiResponse<UsuarioResponse>(false, ex.Message, default);
            }
        }

        public async Task<ApiResponse<UsuarioResponse>> UpdateAsync(UsuarioRequest usuario)
        {
            try
            {
                var userExistente = await _usuarioRepository.GetByIdAsync(usuario.Id);

                if (userExistente != null)
                {
                    userExistente.Senha = usuario.Senha;
                    userExistente.Permissao = usuario.Permissao;
                    userExistente.Telefone = usuario.Telefone;
                    userExistente.Email = usuario.Email;
                    userExistente.Nome = usuario.Nome;

                    userExistente = await _usuarioRepository.UpdateAsync(userExistente);
                }

                return new ApiResponse<UsuarioResponse>(true, "Registro Alterado Com Sucesso!", new UsuarioResponse()
                {
                    Email = userExistente.Email,
                    Id = userExistente.Id,
                    Nome = userExistente.Nome,
                    Permissao = userExistente.Permissao,
                    Telefone = userExistente.Telefone
                });
            }
            catch (Exception ex)
            {
                return new ApiResponse<UsuarioResponse>(false, ex.Message, default);
            }
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            try
            {
                var user = await _usuarioRepository.GetByIdAsync(id);
                if (user != null)
                {
                    await _usuarioRepository.RemoveAsync(user);
                }

                return new ApiResponse<bool>(true, "Registro Deletado Com Sucesso!", true);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>(false, ex.Message, false);
            }
        }
    }
}
