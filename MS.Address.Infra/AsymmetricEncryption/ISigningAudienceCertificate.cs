using Microsoft.IdentityModel.Tokens;
using MS.Address.Domain.Enum;

namespace MS.Address.Infra.AsymmetricEncryption
{
    public interface ISigningAudienceCertificate
    {
        SigningCredentials GetAudienceSigningKey(JwtCertified jwtCertified);
    }
}
