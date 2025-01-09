using Infrastructure.ExternalServices.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            _logger.LogInformation("Simulating email sending to: {To}", to);
            await Task.Delay(500); // Simulação de tempo de envio de email
            _logger.LogInformation("Email sent to: {To}", to);
        }
    }
}
