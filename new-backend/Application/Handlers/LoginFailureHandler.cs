using Core.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class LoginFailureHandler
    {
        private readonly IAuditService _auditService;
        private readonly ILogger<LoginFailureHandler> _logger;

        public LoginFailureHandler(IAuditService auditService, ILogger<LoginFailureHandler> logger)
        {
            _auditService = auditService;
            _logger = logger;
        }

        public async Task HandleInvalidLoginAttemptAsync(string email)
        {
            // Auditar a falha
            _logger.LogWarning("Invalid login attempt for email: {Email}", email);
            await _auditService.RecordLoginFailure(email);

            // Proteger contra ataques de timing
            await Task.Delay(300); // Simular atraso
        }
    }
}
