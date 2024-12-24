using Domain.DTO.Genericos;
using Domain.DTO.Response;
using Domain.Model;
using Infrastructure.Repository.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<AuthToken> _tokenRepository;
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuarioService;

        public AuthService(IUsuarioService usuarioService, IConfiguration configuration, IGenericRepository<AuthToken> tokenRepository)
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _tokenRepository = tokenRepository ?? throw new ArgumentNullException(nameof(tokenRepository));
        }

        public async Task<ApiResponse<LoginResponse>> LoginAsync(string email, string senha)
        {
            try
            {
                var usuario = await _usuarioService.GetByEmailAsync(email);
                if (usuario.Data.SenhaValida(senha))
                {
                    var token = GenerateJwtToken(usuario.Data);
                    if (token != null)
                    {
                        var adicicionado = await _tokenRepository.AddAsync(new AuthToken
                        {
                            Token = token,
                            ExpiryDate = new JwtSecurityTokenHandler().ReadJwtToken(token).ValidTo
                        });

                        return new ApiResponse<LoginResponse>(true, "Usuario Autenticado com sucesso!", new LoginResponse()
                        {
                            IdUser = usuario.Data.Id,
                            Token = token,
                            Nome = usuario.Data.Nome
                        });
                    }
                }
                return new ApiResponse<LoginResponse>(false, "Usuario Autenticado com sucesso!", default);
            }
            catch (Exception ex)
            {
                return new ApiResponse<LoginResponse>(false, ex.Message, default);
            }
        }

        public async Task<ApiResponse<bool>> LogoutAsync(string token)
        {
            try
            {
                var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);

                var tokenBd = await _tokenRepository.FirstOrDefaultAsync(x => x.Token == token);

                if (tokenBd != null)
                {
                    tokenBd.ExpiryDate = DateTime.UtcNow.AddMinutes(-1);
                    await _tokenRepository.UpdateAsync(tokenBd);
                }

                return new ApiResponse<bool>(true, "Usuario Deslogado com sucesso!", true);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>(false, ex.Message, false);
            }
        }

        private string? GenerateJwtToken(Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
                new Claim("id", usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ApiResponse<bool>> TokenIsValid(string token)
        {
            try
            {
                var invalidToken = await _tokenRepository.FirstOrDefaultAsync(t => t.Token == token);

                return invalidToken?.ExpiryDate > DateTime.UtcNow ?
                            new ApiResponse<bool>(true, "Token é Valido!", true) :
                            new ApiResponse<bool>(false, "Token Não é Valido!", false);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>(false, ex.Message, false);
            }
        }
    }
}
