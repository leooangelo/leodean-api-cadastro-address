using System;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MS.Address.Domain.Enum;
using MS.Address.Infra.AsymmetricEncryption;

namespace MS.Address.AsymmetricEncryption
{
    public class SigningAudienceCertificate : ISigningAudienceCertificate, IDisposable
    {
        private readonly RSA rsa;
        private readonly IConfiguration _configuration;

        public SigningAudienceCertificate(IConfiguration configuration)
        {
            rsa = RSA.Create();
            _configuration = configuration;
        }

        public SigningCredentials GetAudienceSigningKey(JwtCertified jwtCertified)
        {
            var privateKeyDirPath = string.Empty;

            switch (jwtCertified)
            {
                case JwtCertified.User:
                    privateKeyDirPath = _configuration["JwtUser:PrivateKeyDir"];
                    break;
                case JwtCertified.Address:
                    privateKeyDirPath = _configuration["JwtAddress:PrivateKeyDir"];
                    break;
            }

            string privateXmlKey = File.ReadAllText(privateKeyDirPath);
            rsa.FromXmlString(privateXmlKey);

            return new SigningCredentials(
                key: new RsaSecurityKey(rsa),
                algorithm: SecurityAlgorithms.RsaSha256);
        }

        public void Dispose()
        {
            rsa?.Dispose();
        }
    }
}
