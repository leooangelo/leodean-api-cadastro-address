using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MS.Address.Domain.Enum;
using MS.Address.Infra.Certificates.Interfaces;
using System.IO;

namespace MS.Address.Infra.Certificates
{
    public class SigningIssuerCertificate : ISigningIssuerCertificate, IDisposable
    {
        private readonly RSA rsa;
        private readonly IConfiguration _configuration;

        public SigningIssuerCertificate(IConfiguration configuration)
        {
            rsa = RSA.Create();
            _configuration = configuration;
        }

        public RsaSecurityKey GetIssuerSigningKey(JwtCertified jwtCertified)
        {
            var publicKeyDirPath = string.Empty;

            switch (jwtCertified)
            {
                case JwtCertified.Address:
                    publicKeyDirPath = _configuration["JwtAddress:PrivateKeyDir"];
                    break;
            }

            string publicXmlKey = File.ReadAllText(publicKeyDirPath);
            rsa.FromXmlString(publicXmlKey);

            return new RsaSecurityKey(rsa);
        }

        public void Dispose()
        {
            rsa?.Dispose();
        }
    }
}
