using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Contracts
{
    public interface IJwtConfig
    {
        string SecretKey { get; }
        string Issuer { get; }
        string Audience { get; }
    }
}