using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class AppSettings
    {
        public JwtSettings Jwt { get; set; }
        public RefreshTokenSettings RefreshToken { get; set; }
        public EmailSettings Email { get; set; }
        public string[] AllowedOrigins { get; set; }
    }

    public class JwtSettings
    {
        public string Secret { get; set; }
        public int ExpirationInMinutes { get; set; }
    }

    public class RefreshTokenSettings
    {
        public int ExpirationInDays { get; set; }
    }

    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string FromAddress { get; set; }
    }
}
