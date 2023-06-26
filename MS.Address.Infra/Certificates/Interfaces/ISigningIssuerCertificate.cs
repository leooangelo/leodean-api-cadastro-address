using Microsoft.IdentityModel.Tokens;
using MS.Address.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Address.Infra.Certificates.Interfaces
{
    public interface ISigningIssuerCertificate
    {
        RsaSecurityKey GetIssuerSigningKey(JwtCertified jwtCertified);
    }
}
