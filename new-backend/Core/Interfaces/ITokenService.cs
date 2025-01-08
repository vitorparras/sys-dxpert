using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        Guid? ValidateToken(string token);
        RefreshToken GenerateRefreshToken(User user);
    }
}

