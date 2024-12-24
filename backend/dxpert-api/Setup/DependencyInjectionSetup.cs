using Infrastructure.Repository;
using Infrastructure.Repository.Interface;
using Service;
using Service.Calculos;
using Service.Interfaces;

namespace API.Setup
{
    public static class DependencyInjectionSetup
    {
        public static void ConfigureDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ICadastroService, CadastroService>();
            builder.Services.AddScoped<IConfiguracaoService, ConfiguracaoService>();
            builder.Services.AddScoped<IProgressaoService, ProgressaoService>();
            builder.Services.AddScoped<IRelatorioService, RelatorioService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();

            builder.Services.AddScoped<ICalculosService, CalculosService>();

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
