using Microsoft.Extensions.DependencyInjection;

using System.IdentityModel.Tokens.Jwt;
using MS.Address.CrossCutting;
using MS.Address.CrossCutting.Services;
using MS.Address.Infra.AsymmetricEncryption;
using MS.Address.AsymmetricEncryption;
using MS.Address.Infra.Certificates.Interfaces;
using MS.Address.Infra.Certificates;
using MS.Address.Infra.DataAccess.Context;
using MS.Address.Service.Interfaces;
using MS.Address.Service;
using MS.Address.Infra.DataAccess.Repositories;

namespace MS.Address.Infra
{
    public static class DependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<AddressContext>();

            //services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<JwtSecurityTokenHandler>();

            services.AddScoped<IDateTimeNowProvider, DateTimeNowProvider>();

            services.AddScoped<ISigningAudienceCertificate, SigningAudienceCertificate>();
            services.AddScoped<ISigningIssuerCertificate, SigningIssuerCertificate>();

            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressRepository, AddressRepository>();
        }
    }
}
